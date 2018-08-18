using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroMove : MonoBehaviour {

    [SerializeField]
    float veloc;
    bool colidiu;
    Rigidbody rb;

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
        colidiu = true;
        rb.useGravity = true;
    }
}