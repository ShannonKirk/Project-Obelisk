using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    [SerializeField] bool carrying = false;
    [SerializeField] GameObject carriedObject;
    [SerializeField] Transform hand;

    void PickUpObject(GameObject weapon) {
        var weaponHandler = weapon.GetComponent<WeaponHandler>();
        ChangeLayerRecursively(weapon.transform, Layers.FPS);
        weapon.transform.parent = hand;
        weapon.transform.localPosition = weaponHandler.holdPosition;
        weapon.transform.localEulerAngles = weaponHandler.holdRotation;
        carriedObject = weapon;
    }

    void ChangeLayerRecursively(Transform trans, string layerName) {
        trans.gameObject.layer = LayerMask.NameToLayer(layerName);
        foreach (Transform child in trans)
            ChangeLayerRecursively(child, layerName);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == Tags.WEAPON && !carrying) {
            carrying = true;
            PickUpObject(other.gameObject);
        }
    }
}
