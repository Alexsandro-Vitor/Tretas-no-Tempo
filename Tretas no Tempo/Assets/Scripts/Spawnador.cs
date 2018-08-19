using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Spawnador : MonoBehaviour {
	
    [SerializeField]
    GameObject[] spawns;
    [SerializeField]
    GameObject dino;


	public Text contadorDinos;

	static int  QUANT_MAX_DINOS = 5;



	// Use this for initialization
	void Start ()
    {
		InvokeRepeating ("SetarDinossauro", 5, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!Player.playerG.GetComponent<Player>().vivo ) { CancelInvoke(); }


    }

    void SetarDinossauro()
	{


		if (FindObjectsOfType<Dinossauro> ().Length < QUANT_MAX_DINOS) {
			int n = Random.Range (1, 5);

			dino.transform.position = spawns [n - 1].transform.position;
			// Mudar a aceleração se o spawn for o número 2
			//Debug.Log("Spwan number:"+ (n - 1));
			if ((n - 1) == 2 || (n - 1) == 0) {
				dino.gameObject.GetComponent<NavMeshAgent> ().speed = 2.5f;
			} else {
				dino.gameObject.GetComponent<NavMeshAgent> ().speed = 1.5f;
			}
			Instantiate (dino);
		}

	}
}