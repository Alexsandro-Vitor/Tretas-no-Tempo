using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour {
    
    // Update is called once per frame
    void Update()
    {
        transform.position =  Vector3.Lerp(transform.position, new Vector3(Player.playerG.transform.position.x, Player.playerG.transform.position.y + 8, Player.playerG.transform.position.z), Time.deltaTime * 3);
    }
}
