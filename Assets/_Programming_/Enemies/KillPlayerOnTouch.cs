using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnTouch : MonoBehaviour {

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && PlayerManager.alive)
        {
            Debug.Log("KILL PLAYER");
            PlayerManager.playerDeath.killPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && PlayerManager.alive)
        {
            Debug.Log("KILL PLAYER");
            PlayerManager.playerDeath.killPlayer();
        }
    }

}
