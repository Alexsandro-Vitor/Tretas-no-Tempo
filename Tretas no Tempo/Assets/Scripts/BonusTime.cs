using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTime : MonoBehaviour {
	
	// Use this for initialization
	int yRotation =0;
	int zRotation =0;
	Timer tempo;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		yRotation++;
		zRotation+=2;
		transform.eulerAngles = new Vector3(10, yRotation, zRotation);
		//gameObject.transform.Rotate(Vector3.right * Time.deltaTime);
	}
}
