using UnityEngine;

/// <summary>Class for moving characters</summary>
[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Animator))]
public class Movement : MonoBehaviour {
	[Header("Camera")]
	[Tooltip("O máximo que a câmera pode virar para cima ou para baixo")][SerializeField] private float maxPitch = 80f;
	[Header("Movement")]
	[Tooltip("Velocidade de movimento")][SerializeField] private float movespeed = 3f;

	private Rigidbody rb;
	private Animator anim;

	void Awake() {
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}

	public void Camera(float yaw, float pitch) {
		float realPitch;
		if (transform.eulerAngles.x < 180f)
			realPitch = Mathf.Clamp(transform.eulerAngles.x - pitch, -maxPitch, maxPitch);
		else
			realPitch = Mathf.Clamp(transform.eulerAngles.x - pitch, 360f - maxPitch, 360f + maxPitch);
		transform.eulerAngles = new Vector3(realPitch, transform.eulerAngles.y + yaw, 0.0f);
	}

	public void Move(float frontBack, float leftRight) {
		Vector3 direction = frontBack * transform.forward + leftRight * transform.right;
		direction.y = 0f;
		rb.velocity = direction.normalized * movespeed + new Vector3(0f, rb.velocity.y, 0f);
		anim.SetFloat(Constants.AnimParamSpeed, direction.magnitude);
	}
}