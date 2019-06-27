using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController characterController;
    private Vector3 moveDirection;
    private float gravity = 20f;
    private float verticalVelocity;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 10f;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
    }
    
	void Update () {
        Movement();
	}

    void Movement() {
        moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;
        ApplyGravity();
        characterController.Move(moveDirection);
    }

    void ApplyGravity() {
        verticalVelocity -= gravity * Time.deltaTime;
        PlayerJump();
        moveDirection.y = verticalVelocity * Time.deltaTime;
    }

    void PlayerJump() {
        if(characterController.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            verticalVelocity = jumpForce;
        }
    }
}
