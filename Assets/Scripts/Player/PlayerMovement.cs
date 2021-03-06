﻿using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] float speed = 2.0F;
	
	[SerializeField] float dodgeSpeed = 10.0f;
	[SerializeField] float dodgeDuration = 1.0f;
	[SerializeField] float dodgeStaminaAmount = 1.0f;


	bool isDodging = false;

	Rigidbody rigid;
	Animator anim;

	void Start () {
		rigid = GetComponent<Rigidbody>();
		anim = GetComponentInChildren<Animator>();
	}

	public void move(float dirX, float dirZ){
		if(isDodging) return;

		Vector3 moveDirection = Vector3.zero;
		if(dirX == 0.0f && dirZ == 0.0f)
        {
            anim.SetBool("isMoving", false);
        }
		else
		{
			moveDirection = processDirectionInRelationToCamera(dirX, 0.0f, dirZ);
            if(moveDirection.magnitude > 1) moveDirection.Normalize();

            anim.SetBool("isMoving", true);

        	transform.LookAt(transform.position + new Vector3(moveDirection.x, 0.0f, moveDirection.z), Vector3.up);
		}

		rigid.velocity = new Vector3 (moveDirection.x * speed, rigid.velocity.y, moveDirection.z * speed);
	}

	private Vector3 processDirectionInRelationToCamera(float x, float y, float z)
    {
        Vector3 direction = new Vector3(x, y, z);
        Quaternion cameraRotation = Camera.main.transform.rotation;

        cameraRotation.x = 0.0f; //removes the vertical rotation

        direction = cameraRotation * direction;
        return direction;
    }
}
