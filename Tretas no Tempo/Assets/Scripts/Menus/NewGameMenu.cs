using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameMenu : MonoBehaviour {
	[SerializeField] private RectTransform dialogues;
	private int currdialogue = 0;

	void Start () {
		foreach (RectTransform child in dialogues) child.gameObject.SetActive(false);
		dialogues.GetChild(0).gameObject.SetActive(true);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("SampleScene");
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (currdialogue == 0) SceneManager.LoadScene("MainMenuScene");
			dialogues.GetChild(currdialogue).gameObject.SetActive(false);
			currdialogue--;
			dialogues.GetChild(currdialogue).gameObject.SetActive(true);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if (currdialogue == dialogues.childCount - 1) SceneManager.LoadScene("SampleScene");
			dialogues.GetChild(currdialogue).gameObject.SetActive(false);
			currdialogue++;
			dialogues.GetChild(currdialogue).gameObject.SetActive(true);
		}
	}
}
