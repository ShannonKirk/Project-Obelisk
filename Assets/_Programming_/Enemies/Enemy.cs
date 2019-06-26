using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] readonly float destroyBelowY = -10;

    new Collider collider;
    new Rigidbody rigidbody;


    void Start () {
        collider  = gameObject.GetComponent<Collider>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        Respawn.RespawnRandomSquare(gameObject);
    }
	

    public void KillThisEnemy()
    {
        GetComponentInParent<DestructableObject>().ApplyDestruction();
        PlayerManager.enemiesPlayerKilled++;
    }
}
