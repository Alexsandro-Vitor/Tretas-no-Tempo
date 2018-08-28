using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	private static bool isPaused;
	/// <summary>
	/// O jogo está pausado?
	/// </summary>
	public static bool Paused {
		get {
			return isPaused;
		}
	}
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

	/// <summary>
	/// Pausa o jogo
	/// </summary>
	void Pause() {
		contents.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
		Cursor.visible = true;
	}

	/// <summary>
	/// Continua o jogo
	/// </summary>
	void Resume() {
		contents.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
		Cursor.visible = false;
	}

	/// <summary>
	/// Reinicia a fase
	/// </summary>
	public void ResetLevel() {
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void BackMenu() {
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenuScene");
	}
}