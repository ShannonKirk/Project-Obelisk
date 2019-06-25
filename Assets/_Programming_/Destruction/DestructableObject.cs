using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour {

    [SerializeField] GameObject destroyedPrefab;
    [SerializeField] float respawnBelowY = -10;

    GameObject destroyedParts;
    GameObject normalState;
    bool destroyed = false;

    private void Start()
    {
        normalState = gameObject.transform.GetChild(0).gameObject;
    }

    void Update () {
        
        if (destroyed && 
            destroyedParts.transform.GetChild(0).position.y < respawnBelowY)
        {
            Debug.Log("yes");
            Respawn.RespawnRandomSquare(gameObject);
            ResetDestruction();
        }
    }

    public void ResetDestruction()
    {
        destroyed = false;
        normalState.SetActive(true);
        Destroy(destroyedParts);
    }

    public void ApplyDestruction()
    {
        destroyed = true;
        normalState.SetActive(false);
        destroyedParts = Instantiate(destroyedPrefab);
        destroyedParts.transform.position = normalState.transform.position;
        destroyedParts.transform.rotation = normalState.transform.rotation;
    }
}
