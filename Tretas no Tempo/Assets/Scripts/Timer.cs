using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float minutos = 5, segundos = 0;
    string zero;

    [SerializeField]
    Text texto;
    
	// Update is called once per frame
	void Update ()
    {
        segundos -= Time.deltaTime;
        if (segundos <= 0) { minutos--; segundos = 60; }

        if (segundos < 10) zero = "0";
        else zero = null;
        texto.text = "0" + minutos + ":" + zero + (int)segundos;
	}
}
