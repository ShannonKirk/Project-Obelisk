using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMeleeAttack : MonoBehaviour {


	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerManager.playerAnimations.playAnimation("Attack");
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0) && other.gameObject.GetComponent<Enemy>())
        {
           other.gameObject.GetComponent<Enemy>().KillThisEnemy();
        }
    }
}
