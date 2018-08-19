using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnadorHostage : MonoBehaviour {

	[SerializeField]
	GameObject hostage;
	[SerializeField]
	GameObject[] spawns;

	[SerializeField]
	Image win;

	[SerializeField]
	Bussola bussola;

	public void SetarHostage()
	{
		int n = Random.Range (1, spawns.Length);
		hostage.transform.position = spawns [n - 1].transform.position;
		GameObject go = Instantiate (hostage);
		go.GetComponent<HostageFound>().win = win;
		bussola.hostage = go;
		bussola.gameObject.SetActive (true);
	}
}
