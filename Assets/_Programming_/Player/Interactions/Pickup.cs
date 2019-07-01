using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    
    [SerializeField] bool carrying = false;
    [SerializeField] WeaponHandler carriedHandler;
    [SerializeField] GameObject rightHandWeapon;
    [SerializeField] GameObject leftHandWeapon;
    [SerializeField] Transform rightHand;
    [SerializeField] Transform leftHand;
    [SerializeField] float startThrowHold = 0.0f;
    [SerializeField] float throwHoldTimer = 1.0f;

    private void Update() {
        if (rightHandWeapon != null || leftHandWeapon == null) {
            CheckThrow();
        }
    }

    void ThrowObject(GameObject weapon, Transform hand) {
        weapon.transform.parent = null;
        carrying = false;
        ChangeLayerRecursively(weapon.transform, Layers.DEFAULT);
        weapon.GetComponent<Rigidbody>().useGravity = true;
        weapon.GetComponent<Rigidbody>().AddForce(hand.up * -1000);
    }//throw object

    void CheckThrow() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            startThrowHold = Time.time;
        }
        if (Input.GetKey(KeyCode.Mouse0)) {
            if (leftHandWeapon == null) { return; }
            if (startThrowHold + throwHoldTimer <= Time.time) {
                Debug.Log("Throw left weapon");
                ThrowObject(leftHandWeapon, leftHand);
                leftHandWeapon = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            startThrowHold = Time.time;
        }
        if (Input.GetKey(KeyCode.Mouse1)) {
            if (rightHandWeapon == null) { return; }
            if (startThrowHold + throwHoldTimer <= Time.time) {
                Debug.Log("Throw right weapon");
                ThrowObject(rightHandWeapon, rightHand);
                rightHandWeapon = null;
            }
        }
    }//Check throw

    void PickUpObject(GameObject weapon) {
        ChangeLayerRecursively(weapon.transform, Layers.FPS);
        carriedHandler = weapon.GetComponent<WeaponHandler>();
        if (rightHandWeapon == null) {
            weapon.transform.parent = rightHand;
            rightHandWeapon = weapon;
        } else {
            weapon.transform.parent = leftHand;
            leftHandWeapon = weapon;
        }
        weapon.transform.localPosition = carriedHandler.holdPosition;
        weapon.transform.localEulerAngles = carriedHandler.holdRotation;
    }//Pickup Object

    void ChangeLayerRecursively(Transform trans, string layerName) {
        //Changes the layer of the weapon and all child objects
        trans.gameObject.layer = LayerMask.NameToLayer(layerName);
        foreach (Transform child in trans)
            ChangeLayerRecursively(child, layerName);
    }//Change Layer

    private void OnTriggerEnter(Collider other) {
        //Ignores the trigger currently in players hand
        if(other.gameObject == rightHandWeapon || other.gameObject == leftHandWeapon || (rightHandWeapon != null && leftHandWeapon != null)) { return; }
        if (other.tag == Tags.WEAPON) {
            PickUpObject(other.gameObject);
        }
    }//Trigger enter
}//class
