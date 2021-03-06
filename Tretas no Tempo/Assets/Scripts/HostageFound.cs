﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HostageFound : MonoBehaviour {


	public Image win;
	bool subindo;
	float velocidade = 1.0f ;
	AudioSource gerenciadorHostage;
	public AudioClip audioWin;


	void Start()
	{
		gerenciadorHostage = gameObject.GetComponent<AudioSource> ();
		gerenciadorHostage.Play ();

	}

	void Update()
	{
		if (subindo)
		{
			transform.Translate (Vector3.up*velocidade * Time.deltaTime);
		}
	}

	// Use this for initialization
	void OnTriggerEnter(Collider collider)
	{


		if(collider.CompareTag("Player"))
		{
			
			subindo = true;
			win.gameObject.SetActive(true);
			GetComponent<Animator>().SetTrigger("Found");
			gerenciadorHostage.PlayOneShot (audioWin,1);
			collider.gameObject.GetComponent<Player> ().gerenciadorDeSom.Stop ();
		}

	}
}
