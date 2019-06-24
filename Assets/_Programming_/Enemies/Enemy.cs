using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] readonly float destroyBelowY = -10;
    [SerializeField] readonly float respawnRange = 20;

    new Collider collider;
    new Rigidbody rigidbody;


    void Start () {
        collider  = gameObject.GetComponent<Collider>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        //RespawnThisEnemy();
    }
	
	void Update () {
        if(transform.position.y < destroyBelowY)
        {
            RespawnThisEnemy();
        }
	}

    void RespawnThisEnemy()
    {
        Respawn.RespawnRandomSquare(gameObject.gameObject,respawnRange);
    }

    public void KillThisEnemy()
    {
        rigidbody.AddForce(new Vector3(10, 500, 10));
        collider.enabled = false;
        GetComponentInParent<DestructableObject>().ApplyDestruction();
    }
}
