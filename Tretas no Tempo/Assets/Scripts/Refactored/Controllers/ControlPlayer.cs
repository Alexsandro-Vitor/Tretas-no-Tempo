using UnityEngine;

[RequireComponent (typeof(AttackShoot))]
[RequireComponent (typeof(CameraChange))]
[RequireComponent (typeof(Life))]
[RequireComponent (typeof(Movement))]
/// <summary>Class for controlling the player</summary>
public class ControlPlayer : MonoBehaviour {
	[Tooltip("Velocidade de rotação pelas setas do teclado")][SerializeField] float speedKeyH = 90f;
    [Tooltip("Velocidade de rotação horizontal pelo mouse")][SerializeField] float speedMouseH = 4.0f;
    [Tooltip("Velocidade de rotação vertical pelo mouse")][SerializeField] float speedMouseV = 2.0f;

	private AttackShoot attackShoot;
	private CameraChange cameras;
	private Life life;
	private Movement movement;

	private bool changedCamera = false;

	void Start () {
		attackShoot = GetComponent<AttackShoot>();
		cameras = GetComponent<CameraChange>();
		life = GetComponent<Life>();
		movement = GetComponent<Movement>();
	}

	void Update () {
		if (life.Alive && !PauseMenu.Paused) {
			// Shooting
			if (Input.GetAxisRaw(Constants.AxisFire1) > 0f) attackShoot.Shoot();

			// Change Cameras
			if (Input.GetAxisRaw(Constants.AxisChangeCamera) > 0f) {
				if (!changedCamera) {
					cameras.ChangeCamera();
					changedCamera = true;
				}
			} else changedCamera = false;

			//Walking
			movement.Move(
				Input.GetAxisRaw(Constants.AxisVertical),
				Input.GetAxisRaw(Constants.AxisSideWalk)
			);

			// Orientation movement
			if (Input.GetAxisRaw(Constants.AxisHorizontal) != 0) {
				movement.Camera(
					Input.GetAxis(Constants.AxisHorizontal) * speedKeyH * Time.deltaTime,
					speedMouseV * Input.GetAxis(Constants.AxisMouseY)
				);
			} else {
				movement.Camera(
					speedMouseH * Input.GetAxis(Constants.AxisMouseX),
					speedMouseV * Input.GetAxis(Constants.AxisMouseY)
				);
			}
		}
	}
}
