using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bussola : MonoBehaviour {

	[SerializeField]
	Player player;

	public GameObject hostage;

	// Update is called once per frame
	void Update () {
		if (hostage) {
			Vector3 vector = hostage.transform.position - player.transform.position;
			float Z = Vector3.SignedAngle (vector, player.transform.forward, Vector3.up);
			transform.eulerAngles = new Vector3 (0, 0, Z);
			Debug.Log ("Z"+ Z);
		}
	}
}
