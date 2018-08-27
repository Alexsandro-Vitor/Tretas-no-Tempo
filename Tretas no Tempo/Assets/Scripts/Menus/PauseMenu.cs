using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public static bool isPaused;
	[Tooltip("Tela de pausa")][SerializeField] private GameObject contents;
	[Tooltip("Tela de continuar")][SerializeField] private Button btnContinue;
	[Tooltip("Tela de reiniciar fase")][SerializeField] private Button btnRestart;
	[Tooltip("Tela de voltar pro menu")][SerializeField] private Button btnBackMenu;

	void Awake() {
		contents.SetActive(false);
		isPaused = false;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (contents.activeInHierarchy) Resume();
			else Pause();
		}
		
		btnContinue.onClick.AddListener(Resume);
		btnRestart.onClick.AddListener(ResetLevel);
		btnBackMenu.onClick.AddListener(BackMenu);
	}

	void Pause() {
		contents.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
	}

	void Resume() {
		contents.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
	}

	public void ResetLevel() {
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void BackMenu() {
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenuScene");
}
}
