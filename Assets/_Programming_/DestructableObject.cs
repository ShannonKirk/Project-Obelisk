using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour {

    [SerializeField] GameObject defaultState;
    [SerializeField] GameObject destroyedState;

    // Use this for initialization
    void Start () {
        defaultState.SetActive(true);
        destroyedState.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyDestruction()
    {
        defaultState.SetActive(false);
        destroyedState.SetActive(true);
    }
}
