using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMeleeAttack : MonoBehaviour {


	void Update () {
        if (Input.GetMouseButtonDown(0) && PlayerManager.alive == true)
        {
            PlayerManager.playerAnimations.playAnimation("Attack");
            PlayerManager.timesPlayerPunched++;
        }
	}

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.GetComponent<Enemy>());
        if (Input.GetMouseButtonDown(0) && other.gameObject.GetComponent<Enemy>() && PlayerManager.alive == true)
        {
            Debug.Log("kill");
           other.gameObject.GetComponent<Enemy>().KillThisEnemy();
        }
    }
}
