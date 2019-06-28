using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {
    ONE_HANDED,
    TWO_HANDED
}



public class WeaponHandler : MonoBehaviour {

    public Vector3 holdPositionRight;
    public Vector3 holdRotationRight;
    public Vector3 holdPositionLeft;
    public Vector3 holdRotationLeft;
    public WeaponType weaponType;

	void Start () {
		
	}
	
	void Update () {
		
	}
}
