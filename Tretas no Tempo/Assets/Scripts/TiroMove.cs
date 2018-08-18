using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroMove : MonoBehaviour {
	[SerializeField] float speed;

	void Start() {
		GetComponent<Rigidbody>().velocity = transform.parent.forward * speed;
	}

    void OnTriggerEnter(Collider other) {
        Dinossauro dino = other.GetComponent<Dinossauro>();
		if (dino != null) dino.Dano();
		Destroy(gameObject);
    }
}