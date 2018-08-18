using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public MeshRenderer mesh;

    public static GameObject playerG;

    [SerializeField]
    float veloc;

    [SerializeField]
    GerenciadorVida gerenciadorV;

    [SerializeField]
    GameObject tiro;

    Rigidbody rb;

    int vidas = 3;

    bool dano;

    void Awake()
    {
        playerG = gameObject;
    }

	// Use this for initialization
	void Start ()
    {
        mesh = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Movimento();
	}

    void Update()
    {
        if (Input.GetKeyDown("f")) Instantiate(tiro, transform);
    }

    void Movimento()
    {
        //MovimentaçãoX
        if (Input.GetAxis("Horizontal") > 0) { transform.Translate(Vector2.right * veloc * Time.deltaTime); }
        else if (Input.GetAxis("Horizontal") < 0) { transform.Translate(Vector2.left * veloc * Time.deltaTime); }
        //MovimentaçãoZ
        if (Input.GetAxis("Vertical") > 0) { transform.Translate(Vector3.forward * veloc * Time.deltaTime); }
        else if (Input.GetAxis("Vertical") < 0) { transform.Translate(Vector3.back * veloc * Time.deltaTime); }
        //GirarCamera
        if (Input.GetKey("right")) { transform.Rotate(Vector2.up * (veloc * 30) * Time.deltaTime); }
        else if (Input.GetKey("left")) { transform.Rotate(Vector2.down * (veloc * 30) * Time.deltaTime); }
    }

    void AtivarDano() { dano = false; }

    void OnCollisionEnter(Collision colider)
    {
        if (colider.gameObject.tag == "Inimigo" && !dano)
        {
            dano = true;
            gerenciadorV.SetarVida(vidas, false);
            vidas--;
            if (vidas == 0) { mesh.enabled = false; }
            Invoke("AtivarDano", 1); }
    }
}