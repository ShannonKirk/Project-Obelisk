using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnTouch : MonoBehaviour {

    [SerializeField] bool useTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (useTrigger)
        {
            PlayerManager.player.transform.position = PlayerManager.respawnPoint;
        }
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerManager.player.transform.position = PlayerManager.respawnPoint;
        }
    }
}
