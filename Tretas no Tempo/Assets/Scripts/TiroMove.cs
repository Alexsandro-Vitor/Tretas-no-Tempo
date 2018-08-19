using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroMove : MonoBehaviour {

    [SerializeField]
    float veloc;
    bool colidiu;
    Rigidbody rb;
    public GameObject explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!colidiu)
        {
            transform.Translate(Vector3.forward * veloc * Time.deltaTime);
            Destroy(gameObject, 1.5f);
        }
    }

    void OnCollisionEnter(Collision colider)
    {
        GameObject support = Instantiate(explosion, transform);
        support.transform.parent = null;
    }

    void OnTriggerEnter(Collider collider)
    {
		Dinossauro dino = collider.GetComponent<Dinossauro> ();
		if (dino != null) {
			dino.Dano ();
		}
		Destroy (gameObject);
        colidiu = true;
        rb.useGravity = true;
    }
}