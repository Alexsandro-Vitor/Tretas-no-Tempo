using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class TimerHUD : MonoBehaviour {
	[Tooltip("Contagem de tempo restante")][SerializeField] private float timeCount;
	[Tooltip("AbstractActions que serão ativadas quando o tempo acabar")][SerializeField] private AbstractAction[] actions;

	private Text text;

	void Awake() {
		text = GetComponent<Text>();
	}

	void Update() {
		ReduceTime(Time.deltaTime);
	}

	/// <summary>Reduce the remaining time, if there is time remaining.</summary>
    /// <param name="seconds">Time in seconds to be reduced from the time count.</param>
	public void ReduceTime(float seconds) {
		if (timeCount <= .0f) return;
		timeCount -= seconds;
		if (timeCount > .0f) {
			text.text = ((int)timeCount / 60).ToString("00") + ":"+ ((int)timeCount % 60).ToString("00");
		} else {
			text.text = "00:00";
			TimeIsOver();
		}
	}

	/// <summary>Code which runs when the time count is over</summary>
	private void TimeIsOver() {
		foreach (AbstractAction action in actions) action.Activate();
	}
}