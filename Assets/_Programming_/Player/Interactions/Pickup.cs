using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FreeHands {
    TWO_HANDS,
    ONE_HAND,
    NONE
}

public class Pickup : MonoBehaviour {

    public FreeHands freeHands;
    [SerializeField] bool carrying = false;
    [SerializeField] GameObject rightHandWeapon;
    [SerializeField] WeaponHandler rightCarriedHandler;
    [SerializeField] Transform rightHand;
    [SerializeField] GameObject leftHandWeapon;
    [SerializeField] WeaponHandler leftCarriedHandler;
    [SerializeField] Transform leftHand;
    [SerializeField] float startThrowHold = 0.0f;
    [SerializeField] float throwHoldTimer = 1.0f;

    private void Update() {
        if (leftHandWeapon != null || rightHandWeapon != null) {
            CheckThrow();
        }
    }

    void ThrowObject(GameObject weapon, Transform hand) {
        weapon.transform.parent = null;
        carrying = false;
        ChangeLayerRecursively(weapon.transform, Layers.DEFAULT);
        weapon.GetComponent<Rigidbody>().useGravity = true;
        weapon.GetComponent<Rigidbody>().AddForce(hand.up * -1000);
    }//throw

    void CheckThrow() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            startThrowHold = Time.time;
        }
        if (Input.GetKey(KeyCode.Mouse0)) {
            if (leftHandWeapon == null) { return; }
            if (startThrowHold + throwHoldTimer <= Time.time) {
                Debug.Log("Through left weapon");
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
                Debug.Log("Through right weapon");
                ThrowObject(rightHandWeapon, rightHand);
                rightHandWeapon = null;
            }
        }
    }//Check throw

    void PickUpObject(GameObject weapon) {
        ChangeLayerRecursively(weapon.transform, Layers.FPS);
        switch (freeHands) {
            case FreeHands.TWO_HANDS:
                rightCarriedHandler = weapon.GetComponent<WeaponHandler>();
                weapon.transform.parent = rightHand;
                weapon.transform.localPosition = rightCarriedHandler.holdPositionRight;
                weapon.transform.localEulerAngles = rightCarriedHandler.holdRotationRight;
                rightHandWeapon = weapon;
                freeHands = FreeHands.ONE_HAND;
                break;
            case FreeHands.ONE_HAND:
                leftCarriedHandler = weapon.GetComponent<WeaponHandler>();
                weapon.transform.parent = leftHand;
                weapon.transform.localPosition = leftCarriedHandler.holdPositionLeft;
                weapon.transform.localEulerAngles = leftCarriedHandler.holdRotationLeft;
                leftHandWeapon = weapon;
                freeHands = FreeHands.NONE;
                break;
            case FreeHands.NONE:
                return;
        }
    }//Pickup Object

    void ChangeLayerRecursively(Transform trans, string layerName) {
        //Changes the layer of the weapon and all child objects
        trans.gameObject.layer = LayerMask.NameToLayer(layerName);
        foreach (Transform child in trans)
            ChangeLayerRecursively(child, layerName);
    }//Change Layer

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == rightHandWeapon || other.gameObject == leftHandWeapon) { return; }
        if (other.tag == Tags.WEAPON) {
            PickUpObject(other.gameObject);
        }
    }//Trigger enter
}//class
