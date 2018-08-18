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
    [SerializeField]
    Animator anim;

	// Use this for initialization
	void Start ()
    {
        life = 3;
        anim.SetInteger("Vida", life);
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

        anim.SetInteger("Vida", life);
    }
}
