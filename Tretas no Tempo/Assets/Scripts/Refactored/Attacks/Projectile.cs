using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
/// <summary>Class for damaging projectiles</summary>
public class Projectile : MonoBehaviour {
	[Tooltip("Dano do projétil")][SerializeField] private int damage = 1;
	[Tooltip("Velocidade do projétil")][SerializeField] private float speed = 10f;
	[Tooltip("Tempo de existencia do projétil")][SerializeField] private float timeSpan = 1.5f;

	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		Destroy(this.gameObject, timeSpan);
	}

	void OnTriggerEnter(Collider other) {
		IAttackable target = other.GetComponent<IAttackable>();
		if (target != null) target.TakeDamage(damage);
		Destroy(this.gameObject);
	}
}
