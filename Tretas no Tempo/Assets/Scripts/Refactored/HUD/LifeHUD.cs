using UnityEngine;
using UnityEngine.UI;

public class LifeHUD : MonoBehaviour {
	[Tooltip("A vida do jogador")][SerializeField] private Life player;

	[Header("Blood Screen")]
	[Tooltip("Imagem do sangue")][SerializeField] private Image bloodScreen;
	[Tooltip("Cor da tela")][SerializeField] private Color bloodColor;
	[Tooltip("Cor da tela")][SerializeField] private float bloodTime = 1f;

	[Header("Life Bar")]
	[Tooltip("Barra / Ícone de Vida")][SerializeField] private RectTransform lifeBar;

	void Awake () {
		player.DamageTaken.AddListener(TakeDamage);
	}

	void Update() {
		if (bloodScreen.color.a > 0) {
			Color temp = bloodScreen.color;
			temp.a -= Time.deltaTime / bloodTime;
			bloodScreen.color = temp;
		}
	}

	void TakeDamage() {
		bloodScreen.color = bloodColor;
		lifeBar.localScale = Vector3.one * player.HP / player.MaxHP;
	}
}
