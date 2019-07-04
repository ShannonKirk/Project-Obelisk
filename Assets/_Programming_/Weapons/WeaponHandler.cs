using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {
    ONE_HANDED,
    TWO_HANDED
}



public class WeaponHandler : MonoBehaviour {

    public Vector3 holdPosition;
    public Vector3 holdRotation;
    public float damage;
    public bool throwable;
    public WeaponType weaponType;
    
    IEnumerator ResetWeapon() {
        yield return null;
    }

}
