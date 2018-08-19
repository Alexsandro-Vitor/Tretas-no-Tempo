using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextColorPulse : MonoBehaviour {
	[SerializeField] private Color colorA = Color.white;
	[SerializeField] private Color colorB = new Color(1f, 1f, 1f, 0f);
	[SerializeField] private float period = 1f;
	private Text text;

	void Start() {
		text = GetComponent<Text>();
	}

	void Update () {
		float sine = (Mathf.Sin(Time.time * 2 * Mathf.PI / period) + 1) / 2;
		text.color = Color.Lerp(colorA, colorB, sine);
	}
}
