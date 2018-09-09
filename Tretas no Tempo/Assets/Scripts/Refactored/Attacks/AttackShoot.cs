using UnityEngine;

/// <summary>Code for attacking by shooting stuff</summary>
[RequireComponent (typeof(Animator))]
public class AttackShoot : MonoBehaviour {
	[Tooltip("O que será atirado")][SerializeField] private Projectile projectile;
	[Tooltip("Tempo entre disparos")][SerializeField] private float coolDownTime;
	[Tooltip("De onde o projétil é disparado")][SerializeField] private Transform origin;
	private float lastShot;

	private Animator anim;

	void Awake() {
		anim = GetComponent<Animator>();
	}

	public void Shoot() {
		if (Time.time > coolDownTime + lastShot) {
			GameObject bullet = GameObject.Instantiate(projectile.gameObject);
			bullet.transform.position = origin.position;
			bullet.transform.rotation = transform.rotation;
			lastShot = Time.time;
			anim.SetTrigger(Constants.AnimParamShooting);
		}
	}
}
