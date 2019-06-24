using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToKillEnemy : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.gameObject.GetComponent<Enemy>())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //hit.transform.gameObject.GetComponent<Enemy>().KillThisEnemy();
                    hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(10,500,10));
                }
            }
        }
	}
}
