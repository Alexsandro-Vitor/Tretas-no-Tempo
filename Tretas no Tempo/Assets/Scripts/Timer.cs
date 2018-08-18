using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float minutos = 5, segundos = 0;
    string zero;

    [SerializeField]
    Text texto;
	public Image win;
    
	// Update is called once per frame
	void Update ()
    {
		vitoria ();
	}


	void vitoria(){
		segundos -= Time.deltaTime;
		Debug.Log ("Minutos:"+minutos+"  Segundos:"+segundos);

		if (minutos <= 0 && segundos <= 0) {
			Player.playerG.GetComponent<Player>().vivo = false;
			texto.text = "";
			win.gameObject.SetActive(true);
		} else 
		{
			if (segundos <= 0) { minutos--; segundos = 60; }

			if (segundos < 10) zero = "0";
			else zero = null;
			texto.text = "0" + minutos + ":" + zero + (int)segundos;
		}
	}
}
