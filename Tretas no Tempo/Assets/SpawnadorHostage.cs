﻿using System.Collections;
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

	public void SetarHostage()
	{
		int n = Random.Range (1, 5);
		hostage.transform.position = spawns [n - 1].transform.position;
		Instantiate (hostage).GetComponent<HostageFound>().win = win;
	}
}
