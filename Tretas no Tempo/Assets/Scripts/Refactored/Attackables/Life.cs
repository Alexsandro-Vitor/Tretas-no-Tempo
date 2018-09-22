using UnityEngine;
using UnityEngine.Events;

/// <summary>Class for managing the character's life</summary>
[RequireComponent (typeof(Animator))]
public class Life : MonoBehaviour, IAttackable {
	[SerializeField] private int hp;
	[SerializeField] private int maxHP;
	public int HP {
		get {
			return hp;
		}
	}
	public int MaxHP {
		get {
			return maxHP;
		}
	}
	public bool Alive {
		get {
			return hp > 0;
		}
	}
	public UnityEvent DamageTaken = new UnityEvent();

	private Animator anim;

	void Awake () {
		hp = maxHP;
		anim = GetComponent<Animator>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.X)) {
			TakeDamage(1);
		}
	}
	
	public void TakeDamage(int damage) {
		hp -= damage;
		if (hp <= 0) {
			hp = 0;
			anim.SetBool(Constants.AnimParamDead, true);
		} else {
			anim.SetTrigger(Constants.AnimParamHit);
		}
		DamageTaken.Invoke();
	}
}
