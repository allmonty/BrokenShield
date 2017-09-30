﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {	
	[SerializeField] float rotationSpeed = 1f;

	void Update () {
		transform.Rotate(new Vector3(0, 0.5f, 0) * rotationSpeed, Space.World);
		
	}
}
