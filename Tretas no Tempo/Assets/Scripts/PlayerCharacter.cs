using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour {
    
    public static PlayerCharacter instance;

	public Image mira;
	public Image label;

	public Text info;
    
    [SerializeField]
    float veloc;

    [SerializeField]
    GerenciadorVida gerenciadorV;

    [SerializeField]
    GameObject tiro;

    Rigidbody rb;

    [SerializeField]
    Camera[] cameras;

    int vidas = 3;

	public bool vivo = true;

    bool dano;

    Animator anim;

    [SerializeField]
    Transform origin;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Movimento();
        Anim();
	}

    void MudarCamera()
    {
        cameras[0].enabled = !cameras[0].enabled; cameras[1].enabled = !cameras[1].enabled;
    }

    void Update()
    {
        if (Input.GetKeyDown("t")) { MudarCamera(); }
		if (vivo && Input.GetKeyDown(KeyCode.Space)) Instantiate(tiro, origin);
    }


    void Anim()
    {
        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0) anim.SetFloat("Veloc", 1);
        else anim.SetFloat("Veloc", 0);

        if (vidas == 0) anim.SetBool("Morreu", true);
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
		info.text = "Wasted";
		Invoke("RecarregaCena", 5);
		mira.enabled = false;
		label.gameObject.SetActive(true);
		label.color = new Color(255,0,0,0.5f);

	}

	void RecarregaCena(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}