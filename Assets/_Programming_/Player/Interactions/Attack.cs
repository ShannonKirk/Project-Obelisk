using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    private Pickup pickupScript;
    public float fistDamage;
    public float rightDamage;
    public float leftDamage;

	void Awake () {
        pickupScript = GetComponent<Pickup>();
        rightDamage = leftDamage = fistDamage;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //Left Click
            AttackEnemy(leftDamage);
        if (Input.GetKeyDown(KeyCode.Mouse1)) //RightClick
            AttackEnemy(rightDamage);
	}

    public void ResetDamage() {
        rightDamage = leftDamage = fistDamage;
    }

    void AttackEnemy(float damage) {
        Debug.Log("Deal " + damage + " to enemy");
    }
}
