using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dinossauro : MonoBehaviour {

    public Timer timer;

    Animator anim;

    NavMeshAgent agent;

	public BonusTime bonus;

	ParticleSystem sangue;

    public CapsuleCollider capsule;
    public SphereCollider sphere;

    [SerializeField]
    Vector3 pos;

    public bool tRex;

    bool morreu;

    int vidas = 3;

<<<<<<< HEAD
=======
	AudioSource gerenciadorAudioDino;
	public AudioClip dinoSom2;



>>>>>>> 8939c4be3c508804f25aa904f5b6805f45bba151
	//GameObject bonus;// Mudar para o Objeto Bonnus

	Player player;

	// Use this for initialization
	void Start ()
    {
<<<<<<< HEAD
		player = Player.playerG.GetComponent<Player>();
        anim = GetComponent<Animator>();
=======
		player = FindObjectOfType<Player> ();

		gerenciadorAudioDino = gameObject.GetComponent<AudioSource> ();
		//gerenciadorAudio.clip = dinoSom1;
        
		anim = GetComponent<Animator>();

>>>>>>> 8939c4be3c508804f25aa904f5b6805f45bba151
        agent = GetComponent<NavMeshAgent>();
		sangue = GetComponent<ParticleSystem>();
        if (tRex) { vidas = 50; agent.speed = 3.5f; }
    }
	
    void Update()
    {
<<<<<<< HEAD
        if (Vector3.Distance(new Vector3(player.gameObject.transform.position.x, 0, player.gameObject.transform.position.z), new Vector3(transform.position.x, 0, transform.position.z)) < 2.5f) anim.SetTrigger("Ataque");
=======
        if (Vector3.Distance(Player.playerG.transform.position, transform.position) < 1.5f) anim.SetTrigger("Ataque");

		if (!gerenciadorAudioDino.isPlaying) {
			gerenciadorAudioDino.PlayDelayed(5.0f);
		} else if (!player.vivo) {
			gerenciadorAudioDino.Stop ();
		}
		//gerenciadorAudio.PlayDelayed (5.0f);
>>>>>>> 8939c4be3c508804f25aa904f5b6805f45bba151
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
		if(Player.playerG.GetComponent<Player>().vivo && agent.enabled  && Player.playerG!=null)
        {
			agent.enabled = true;
            pos = Player.playerG.transform.position;
            agent.SetDestination(pos);
        }
        else
        {
            agent.enabled = false;
        }
	}

	public void Dano()
    {
		sangue.Play();
        vidas--;
        if (vidas <= 0 && !tRex) { capsule.enabled = false; sphere.enabled = false; agent.enabled = false; anim.SetTrigger("Morreu"); Destroy(gameObject, 1.5f); }
        else if(vidas <= 0 && tRex) { GetComponent<BoxCollider>().enabled = false; timer.minutos -= 2; agent.enabled = false; anim.SetTrigger("Morreu"); Destroy(gameObject, 1.5f); }
        player.contBonus++;
		contDinos ();
    }
	public void contDinos(){

		// cria o bonus quando o dinossauro de indice aux é morto

		if (player.contBonus == player.aux) {
			bonus.transform.position = transform.position;
			Instantiate (bonus);
			player.aux = Random.Range (player.DINO_BONUS * 3, (player.DINO_BONUS * 2) + 5); // atualiza o índice, para que nos próximos 10 apareça outro timer bonus
		}
	}

    //void OnCollisionEnter(Collision colider)
    //{
      //  if(colider.gameObject.tag == "Tiro") { Destroy(colider.gameObject); Dano(); }
    //}
}