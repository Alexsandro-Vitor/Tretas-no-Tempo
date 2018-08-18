using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Player.playerG.GetComponent<Player>().mesh.enabled == false) { CancelInvoke(); }

    }

    void SetarDinossauro()
    {
        int n = Random.Range(1, 5);

        dino.transform.position = spawns[n-1].transform.position;
        Instantiate(dino);
    }
}