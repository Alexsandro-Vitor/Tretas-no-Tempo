using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	[Tooltip("Botão de Novo Jogo")][SerializeField] private Button btnNewGame;
	[Tooltip("Botão de Configurações")][SerializeField] private Button btnOptions;
	[Tooltip("Botão de Créditos")][SerializeField] private Button btnCredits;
	[Tooltip("Botão de Sair")][SerializeField] private Button btnExit;

	// Use this for initialization
	void Start () {
		btnNewGame.onClick.AddListener(NewGame);
		btnOptions.onClick.AddListener(Options);
		btnCredits.onClick.AddListener(Credits);
		btnExit.onClick.AddListener(Exit);
	}

	void NewGame() {
		SceneManager.LoadScene("SampleScene");
	}

	void Options() {
		SceneManager.LoadScene("OptionsScene");
	}

	void Credits() {
		SceneManager.LoadScene("CreditsScene");
	}

	void Exit() {
		Application.Quit();
}
}
