using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorVida : MonoBehaviour {

    [SerializeField]
    Image[] coracoes;
    [SerializeField]
    Color corSombra, corNormal;
    int life = 3;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("q")) SetarVida(life - 1, false);
        if (Input.GetKeyDown("e")) SetarVida(life + 1, true);
    }

    public void SetarVida(int vidas, bool aumento)
    {
        if (!aumento) life -= 1;

        if(life != 0 || life == 0 && aumento)
        {
            if (vidas == 3) { coracoes[0].color = corNormal; coracoes[1].color = corNormal; coracoes[2].color = corNormal; }
            else if (vidas == 2) { coracoes[0].color = corSombra; coracoes[1].color = corNormal; coracoes[2].color = corNormal; }
            else if (vidas == 1) { coracoes[0].color = corSombra; coracoes[1].color = corSombra; coracoes[2].color = corNormal; }
            else { coracoes[0].color = corSombra; coracoes[1].color = corSombra; coracoes[2].color = corSombra; }
        }
    }
}
