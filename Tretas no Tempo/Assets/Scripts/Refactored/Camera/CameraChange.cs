using UnityEngine;

/// <summary>Code that changes the active camera from an array of them.</summary>
public class CameraChange : MonoBehaviour {
	[Tooltip("As câmeras que podem ser trocadas")][SerializeField] private Camera[] cameras;
	[Tooltip("A câmera atual")][SerializeField] private int current = 0;

	void Awake() {
		current %= cameras.Length;
		foreach (Camera cam in cameras)
			cam.enabled = false;
		cameras[current].enabled = true;
	}

	/// <summary>Changes the currently enabled camera.</summary>
	public void ChangeCamera() {
		cameras[current].enabled = false;
		current = (current + 1) % cameras.Length;
		cameras[current].enabled = true;
	}
}