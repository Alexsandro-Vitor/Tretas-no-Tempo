using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dinossauro : MonoBehaviour {

    Animator anim;

    NavMeshAgent agent;

	public BonusTime bonus;

	ParticleSystem sangue;

    public CapsuleCollider capsule;
    public SphereCollider sphere;

    [SerializeField]
    Vector3 pos;

    bool morreu;

    int vidas = 3;

	AudioSource gerenciadorAudioDino;
	public AudioClip dinoSom2;



	//GameObject bonus;// Mudar para o Objeto Bonnus


	Player player;


	// Use this for initialization
	void Start ()
    {
		player = FindObjectOfType<Player> ();

		gerenciadorAudioDino = gameObject.GetComponent<AudioSource> ();
		//gerenciadorAudio.clip = dinoSom1;
        
		anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
		sangue = GetComponent<ParticleSystem>();
	}
	
    void Update()
    {
        if (Vector3.Distance(Player.playerG.transform.position, transform.position) < 1.5f) anim.SetTrigger("Ataque");

		if (!gerenciadorAudioDino.isPlaying) {
			gerenciadorAudioDino.PlayDelayed(10.0f);
		} else if (!player.vivo) {
			gerenciadorAudioDino.Stop ();
		}
		//gerenciadorAudio.PlayDelayed (5.0f);
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
        if (vidas <= 0) { capsule.enabled = false; sphere.enabled = false; agent.enabled = false; anim.SetTrigger("Morreu"); Destroy(gameObject, 1.5f); }
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