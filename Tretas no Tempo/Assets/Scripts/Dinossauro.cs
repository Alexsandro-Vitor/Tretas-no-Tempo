using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dinossauro : MonoBehaviour {

    Animator anim;

    NavMeshAgent agent;

    [SerializeField]
    Vector3 pos;

    bool morreu;

    int vidas = 3;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if(Player.playerG.GetComponent<Player>().vivo  && agent.enabled)
        {
            pos = Player.playerG.transform.position;
            agent.SetDestination(pos);
        }
        else
        {
            agent.enabled = false;
        }
	}

    void Dano()
    {
        vidas--;
        if (vidas <= 0) { agent.enabled = false; anim.SetTrigger("Morreu"); Destroy(gameObject, 1.5f); }
    }

    void OnCollisionEnter(Collision colider)
    {
        if(colider.gameObject.tag == "Tiro") { Destroy(colider.gameObject); Dano(); }
    }
}