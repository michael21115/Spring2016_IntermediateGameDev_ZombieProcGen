﻿using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float moveSpeed;

	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed + Physics.gravity;

		Ray moveRay = new Ray(transform.position, transform.forward);
		Debug.DrawRay(transform.position, transform.forward * 1.5f, Color.yellow);

		if (Physics.SphereCast(moveRay, 0.5f, 1.5f)){

			float randomizer = Random.value;

			if (randomizer <= .5f){
				transform.Rotate(0f, 90f, 0f);
			}
			else {
				transform.Rotate(0f, -90f, 0f);
			}
		}
	}
}
