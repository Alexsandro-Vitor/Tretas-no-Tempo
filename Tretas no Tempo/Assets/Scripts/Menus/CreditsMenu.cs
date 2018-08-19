using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour {
	[Tooltip("Botão de Voltar")][SerializeField] private Button btnBack;

	void Start () {
		btnBack.onClick.AddListener(Back);
	}

	void Back() {
		SceneManager.LoadScene("MainMenuScene");
	}
}
