using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerSetup : MonoBehaviour {

    //sets up the playermanager class with the right shtuffs

	// Use this for initialization
	void Start () {
        PlayerManager.playerAnimations = GetComponent<PlayerAnimations>();
        PlayerManager.playerController = GetComponent<PlayerController>();
        PlayerManager.camera = GetComponentInChildren<Camera>();
    }
}
