using UnityEngine;

/// <summary>Code for camera to follow player</summary>
public class CameraFollow : MonoBehaviour {
	[Tooltip("Posição relativa ao objeto seguido")][SerializeField] private Vector3 position;
	
	void Update () {
		Vector3 temp = position;
		temp.Scale(transform.parent.localScale);
		transform.position = transform.parent.position + temp;
		transform.rotation = Quaternion.LookRotation(Vector3.down, transform.parent.forward);
	}
}
