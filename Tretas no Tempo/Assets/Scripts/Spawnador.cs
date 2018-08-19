using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Spawnador : MonoBehaviour {
	
    [SerializeField]
    GameObject[] spawns;
    [SerializeField]
    GameObject dino, dino2, dinoAtual;
    
	public Text contadorDinos;

	static int QUANT_MAX_DINOS = 25;

	// Use this for initialization
	void Start ()
    {
		InvokeRepeating ("SetarDinossauro", 5, 1.5f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Player.playerG != null)
        {
            if (!Player.playerG.GetComponent<Player>().vivo) { CancelInvoke(); }
        }
    }

    void SetarDinossauro()
	{
        if(Player.playerG != null)
        {
            if (FindObjectsOfType<Dinossauro>().Length < QUANT_MAX_DINOS)
            {
                int n1 = Random.Range(1, 3);
                if (n1 == 1) dinoAtual = dino;
                else dinoAtual = dino2;
                    
                int n = Random.Range(1, 17);
                int especial = Random.Range(1, 11)
                    ;
                if (Vector3.Distance(Player.playerG.transform.position, spawns[n - 1].transform.position) > 15 && Vector3.Distance(Player.playerG.transform.position, spawns[n - 1].transform.position) < 55)
                {
                    dino.transform.position = spawns[n - 1].transform.position;
                    // Mudar a aceleração se o spawn for o número 2
                    //Debug.Log("Spwan number:"+ (n - 1));
                    if (especial == 1)
                    {
                        if(n1 == 1) dinoAtual.gameObject.GetComponent<NavMeshAgent>().speed = 4f;
                        else dinoAtual.gameObject.GetComponent<NavMeshAgent>().speed = 4.5f;
                    }
                    else
                    {
                        if(n1 == 1) dinoAtual.gameObject.GetComponent<NavMeshAgent>().speed = 5f;
                        else dinoAtual.gameObject.GetComponent<NavMeshAgent>().speed = 5.5f;
                    }
                    Instantiate(dinoAtual);
                }
            }
        }
	}
}