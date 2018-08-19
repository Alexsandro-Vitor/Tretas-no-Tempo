using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HostageFound : MonoBehaviour {


	public Image win;
	bool subindo;
	float velocidade = 1.0f ;

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
			Debug.Log ("Entrou no Trigger");
			win.gameObject.SetActive(true);
		}

	}
}
