using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawnador : MonoBehaviour {
	
    [SerializeField]
    GameObject[] spawns;
    [SerializeField]
    GameObject dino;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SetarDinossauro", 5, 2);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!Player.playerG.GetComponent<Player>().vivo ) { CancelInvoke(); }

    }

    void SetarDinossauro()
    {
        int n = Random.Range(1, 5);

        dino.transform.position = spawns[n-1].transform.position;
		// Mudar a aceleração se o spawn for o número 2
		//Debug.Log("Spwan number:"+ (n - 1));
		if ((n - 1) == 2 || (n - 1) == 0) {
			dino.gameObject.GetComponent<NavMeshAgent> ().speed = 2.5f;
		} else 
		{
			dino.gameObject.GetComponent<NavMeshAgent> ().speed = 1.5f;
		}
        Instantiate(dino);
    }
}