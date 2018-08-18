using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dinossauro : MonoBehaviour {

    NavMeshAgent agent;

    [SerializeField]
    Vector3 pos;

    int vidas = 3;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(Player.playerG.GetComponent<Player>().mesh.enabled)
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

    }

    void OnCollisionEnter(Collision colider)
    {
        if(colider.gameObject.tag == "Tiro") { Destroy(colider.gameObject); Destroy(gameObject); }
    }
}