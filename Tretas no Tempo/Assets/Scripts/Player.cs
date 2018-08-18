using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public MeshRenderer mesh;

	//public Timer t;

    public static GameObject playerG;

	public Text info;

    [SerializeField]
    float veloc;

    [SerializeField]
    GerenciadorVida gerenciadorV;

    [SerializeField]
    GameObject tiro;

    Rigidbody rb;

    int vidas = 3;

	public bool vivo = true;

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
		if (vivo && Input.GetKeyDown(KeyCode.Space)) Instantiate(tiro, transform);
    }


    void Movimento()
    {
		if(vivo){
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
    }

    void AtivarDano() { dano = false; }

    void OnCollisionEnter(Collision colider)
    {
        if (colider.gameObject.tag == "Inimigo" && !dano)
        {
            dano = true;
            gerenciadorV.SetarVida(vidas, false);
            vidas--;
            if (vidas == 0) { 
				Morre();
			}
            Invoke("AtivarDano", 1); }
    }

	void Morre(){
		vivo = false;  
		info.gameObject.SetActive(true);
		Invoke("RecarregaCena", 5);
		mesh.enabled = false;
	}

	void RecarregaCena(){
		info.text = "recarrega";
	}
}