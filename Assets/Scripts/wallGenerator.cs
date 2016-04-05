using UnityEngine;
using System.Collections;

public class wallGenerator : MonoBehaviour {

	[SerializeField] Transform wallMaker;
	[SerializeField] Transform wall;

	int counter = 0;

	
	// Update is called once per frame
	void Update () {

		// Randomized Turning
		float turnRand = Random.value;
		if (turnRand <= 0.01f){
			transform.localEulerAngles += new Vector3 (0f, 90f, 0f);
		}
		else if (turnRand >= 0.01f && turnRand <= 0.05f){
			transform.localEulerAngles += new Vector3 (0f, -90f, 0f);
		}

		// Deliberate Turning -- based on raycasting and outerWalls
		Ray moveRay = new Ray(transform.position, transform.forward);
		RaycastHit wallDetect = new RaycastHit();
		Debug.DrawRay(transform.position, transform.forward * 2f, Color.yellow);

		if (Physics.Raycast(moveRay, out wallDetect, 2f)){
			if (wallDetect.collider.tag == "outerWall" ){ //}|| wallDetect.collider.tag == "innerWall"){
				float rand = Random.value;
				if (rand < 0.5f){
					transform.localEulerAngles += new Vector3 (0f, 90f, 0f);
				}
				else if (rand >= 0.5f){
					transform.localEulerAngles += new Vector3 (0f, -90f, 0f);
				}
			}
		}

		// Wall Placement
		if (counter < 50){
			float wallDropper = Random.value;
			if (wallDropper <= 0.03f){
				Vector3 currentLoc = transform.localPosition; 
				if (wallDropper <= 0.0001f){
					Instantiate (wallMaker, currentLoc, Quaternion.identity);
				}
				else if (wallDropper > 0.0001f && wallDropper <= 0.01f){
					Instantiate (wall, currentLoc + (new Vector3 (0f, 0f, -1f)), Quaternion.identity);
				}
				else if (wallDropper > 0.01f && wallDropper <= 0.02f){
					Instantiate (wall, currentLoc + (new Vector3 (-1f, 0f, 0f)), Quaternion.Euler (0f, 90f, 0f));
				}
				counter++;
			}
		} else {
			// Remove Spawner after walls are placed
			Destroy(gameObject);
		}

		// Forward movement
		transform.Translate(new Vector3 (0f, 0f, 10f) * Time.deltaTime);
	}
}
