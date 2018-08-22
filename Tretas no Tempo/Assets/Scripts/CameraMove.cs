using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    
	[Tooltip("Velocidade de rotação pelas setas do teclado")] [SerializeField] float speedKeyH = 90f;
    [Tooltip("Velocidade de rotação horizontal pelo mouse")] [SerializeField] float speedMouseH = 4.0f;
    [Tooltip("Velocidade de rotação vertical pelo mouse")] [SerializeField] float speedMouseV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start() {
        Cursor.visible = false;
    }

    void Update() {
		//GirarCamera
		if (Input.GetKey(KeyCode.RightArrow)) yaw += speedKeyH * Time.deltaTime;
		else if (Input.GetKey(KeyCode.LeftArrow)) yaw -= speedKeyH * Time.deltaTime;
		else yaw += speedMouseH * Input.GetAxis("Mouse X");
        pitch -= speedMouseV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(Mathf.Clamp(pitch, -80f, 80f), yaw, 0.0f);
    }
}
