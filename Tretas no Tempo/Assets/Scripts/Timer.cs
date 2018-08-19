using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float minutos = 0, segundos = 0;
    string zero;

    [SerializeField]
    Text texto;

	float contCor;
	[SerializeField]
	Spawnador spawnador;
	[SerializeField]
	SpawnadorHostage spawnHostage;

	bool spawnNo = true;
    
	// Update is called once per frame
	void Update ()
    {
		vitoria ();
	}


	void vitoria(){
		segundos -= Time.deltaTime;
		contCor += Time.deltaTime;


		if (texto.color == Color.blue && (int)contCor == 5) {
			texto.color = Color.green;	
			contCor = 0;
		}
		//Debug.Log ("Minutos:"+minutos+"  Segundos:"+segundos);

		if (minutos <= 0 && segundos <= 0) {

			if (spawnNo) {
				spawnNo = false;
				spawnador.CancelInvoke ();
				spawnHostage.SetarHostage ();
				spawnHostage.enabled = false;
			}
			/** Ao matar o Boss
			Player.playerG.GetComponent<Player>().vivo = false;
			texto.text = "";
			if(win!=null)
				win.gameObject.SetActive(true);
		*/
		} else 
		{
			if (segundos <= 0) { minutos--; segundos = 60; }

			if (segundos < 10) zero = "0";
			else zero = null;
			texto.text = "0" + minutos + ":" + zero + (int)segundos;
		}
	}

	public void setTextColor(){
		
		texto.color = Color.blue;
		contCor = 0;
	}
}
