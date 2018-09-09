using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
[RequireComponent (typeof(Animator))]
public class AttackContact : MonoBehaviour {
	[Tooltip("Dano do ataque")][SerializeField] private int damage = 1;
	private Animator anim;

	void Awake() {
		anim = GetComponent<Animator>();
	}
	
	void OnCollisionEnter(Collision other) {
		IAttackable target = other.gameObject.GetComponent<IAttackable>();
		if (target != null) {
			target.TakeDamage(damage);
			anim.SetTrigger(Constants.AnimParamContact);
		}
	}
}
