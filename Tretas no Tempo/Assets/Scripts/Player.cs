using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    
    public static GameObject playerG;

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
    CameraMove cameraS;

	public Timer tempo;
    [SerializeField]
    Camera[] cameras;

    int vidas = 3;

	public bool vivo = true;

    bool dano;

    Animator anim;

	public Text texto;

	public int aux;
	public int contBonus = 0;
	public int DINO_BONUS = 5; // A cada 10 dinossauros mortos, aparece um bonus de tempo

    [SerializeField]
    Transform origin;

    public float shootDelay = 0.2f;

	float lastShoot = 0f;


	//Audio
	public AudioSource gerenciadorDeSom;
	AudioSource gerenciadorAudioPLayer;
	public AudioClip tiroSound,andandoSound,bonusSound,audioMorreu,danoSound;
	bool correndo;

    void Awake()
    {
        playerG = gameObject;

    }

	// Use this for initialization
	void Start ()
    {
		gerenciadorAudioPLayer = gameObject.GetComponent<AudioSource> ();
        aux = Random.Range(DINO_BONUS,DINO_BONUS+5);
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
        cameraS.enabled = cameras[1];
    }

    void Update()
    {
        if (Input.GetKeyDown("t")) { MudarCamera(); }
		if (!PauseMenu.isPaused) {
			if (vivo && (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && Time.time > lastShoot + shootDelay){
				Instantiate(tiro, origin);
				gerenciadorDeSom.PlayOneShot (tiroSound);
				lastShoot = Time.time;
				anim.SetBool("Shoot", true);
			}
			if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)){
				anim.SetBool("Shoot", false);
			}
		}
    }


    void Anim()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) anim.SetFloat("Veloc", 1);
        else anim.SetFloat("Veloc", 0);

        if (vidas == 0) anim.SetBool("Morreu", true);
    }

    void Movimento()
    {
		if(vivo){
	        //MovimentaçãoX
			if (Input.GetAxis ("Horizontal") > 0) {
				transform.Translate (Vector2.right * veloc * Time.deltaTime);
				if (!gerenciadorAudioPLayer.isPlaying) {
					gerenciadorAudioPLayer.Play ();
				}
			} else if (Input.GetAxis ("Horizontal") < 0) {
				transform.Translate (Vector2.left * veloc * Time.deltaTime);
				if (!gerenciadorAudioPLayer.isPlaying) {
					gerenciadorAudioPLayer.Play ();
				}
			} 
	        //MovimentaçãoZ
			else if (Input.GetAxis("Vertical") > 0) { transform.Translate(Vector3.forward * veloc * Time.deltaTime);
				if (!gerenciadorAudioPLayer.isPlaying) {
					gerenciadorAudioPLayer.Play ();
				}
			}
			else if (Input.GetAxis("Vertical") < 0) {
			
				transform.Translate(Vector3.back * veloc * Time.deltaTime);
				if (!gerenciadorAudioPLayer.isPlaying) {
					gerenciadorAudioPLayer.Play ();
				}
			}
			else 
			{
				gerenciadorAudioPLayer.Stop ();
			}
	        //GirarCamera
			if (Input.GetKey("right")) { transform.Rotate(Vector2.up * (veloc * 30) * Time.deltaTime); }
			else if (Input.GetKey("left")) { transform.Rotate(Vector2.down * (veloc * 30) * Time.deltaTime); }

            if (Input.GetKey(KeyCode.LeftShift)) veloc = 5;
            else veloc = 3;
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
			gerenciadorDeSom.PlayOneShot (danoSound, 1);
            if (vidas == 0) { 

				gerenciadorAudioPLayer.volume = 0.5f;
				gerenciadorDeSom.priority = 1;
				gerenciadorDeSom.PlayOneShot(audioMorreu,1);
				//gerenciadorDeSom.Play ();

				Morre();
			}
            Invoke("AtivarDano", 2); 
			anim.SetTrigger("Atingido");
		}
		
    }

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "Bonus")
		{
			Destroy (collider.gameObject);
			tempo.segundos -= 15;
			tempo.setTextColor ();
			gerenciadorDeSom.PlayOneShot (bonusSound);

		}
	}

	void Morre(){
		vivo = false;  
		info.gameObject.SetActive(true);
		info.text = "Missão Falhou";
		Invoke("RecarregaCena", 5);
		mira.enabled = false;
		label.gameObject.SetActive(true);
		label.color = new Color(255,0,0,0.5f);

		gerenciadorAudioPLayer.Stop ();

	}

	void RecarregaCena(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}