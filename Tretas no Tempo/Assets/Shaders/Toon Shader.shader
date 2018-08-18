Shader "Custom/Toon/Cel Shading" {
    Properties {
        // Not showing texture tiling/offset at material inspector
        [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
		_Cuts ("Cuts", int) = 2
		_MinLight ("Minimum lighting", Range(0.0, 1.0)) = 0.2

		_BumpScale("Normal Scale", Float) = 1.0
        [NoScaleOffset] _BumpMap("Normal Map", 2D) = "bump" {}
    }
    SubShader {
        Pass {
            Tags {"LightMode"="ForwardBase"}
			
            CGPROGRAM
			#pragma vertex vert		// use "vert" function as the vertex shader
            #pragma fragment frag	// use "frag" function as the pixel (fragment) shader
            #include "UnityCG.cginc"				// for UnityObjectToWorldNormal
            #include "UnityLightingCommon.cginc"	// for _LightColor0

            // vertex shader outputs / fragment shader inputs ("vertex to fragment")
            struct v2f {
				float2 uv : TEXCOORD0; // texture coordinate
                half3 tspace0 : TEXCOORD1; // tangent.x, bitangent.x, normal.x
                half3 tspace1 : TEXCOORD2; // tangent.y, bitangent.y, normal.y
                half3 tspace2 : TEXCOORD3; // tangent.z, bitangent.z, normal.z
                float4 vertex : SV_POSITION; // clip space position
            };

            // vertex shader
            v2f vert (float4 vertex : POSITION, float3 normal : NORMAL, float4 tangent : TANGENT, float2 uv : TEXCOORD0)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(vertex);	// transform position to clip space
                o.uv = uv;	// just pass the texture coordinate

                half3 wNormal = UnityObjectToWorldNormal(normal);
                half3 wTangent = UnityObjectToWorldDir(tangent.xyz);
                // compute bitangent from cross product of normal and tangent
                half tangentSign = tangent.w * unity_WorldTransformParams.w;
                half3 wBitangent = cross(wNormal, wTangent) * tangentSign;
                // output the tangent space matrix
                o.tspace0 = half3(wTangent.x, wBitangent.x, wNormal.x);
                o.tspace1 = half3(wTangent.y, wBitangent.y, wNormal.y);
                o.tspace2 = half3(wTangent.z, wBitangent.z, wNormal.z);
                return o;
            }
            
            // texture we will sample
            sampler2D _MainTex;

			int _Cuts;
			fixed _MinLight;
			
			float _BumpScale;
            sampler2D _BumpMap;

            // pixel shader; returns low precision ("fixed4" type)
            // color ("SV_Target" semantic)
            fixed4 frag (v2f i) : SV_Target {
 				// sample the normal map, and decode from the Unity encoding
                half3 tnormal = UnpackNormal(tex2D(_BumpMap, i.uv));
				tnormal.xy *= _BumpScale;
                // transform normal from tangent to world space
                half3 worldNormal;
                worldNormal.x = dot(i.tspace0, tnormal);
                worldNormal.y = dot(i.tspace1, tnormal);
                worldNormal.z = dot(i.tspace2, tnormal);
				half nl = dot(worldNormal, _WorldSpaceLightPos0.xyz);

                // sample texture
                fixed4 col = tex2D(_MainTex, i.uv);
				// multiply by lighting
				col *= clamp(ceil(nl * _Cuts) / _Cuts, 0, 1) * (1 - _MinLight) + _MinLight;
                return col;
            }
            ENDCG
        }
    }
}