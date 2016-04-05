using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class preyActions : MonoBehaviour {

	public Transform predatorPrefab;

	void OnDestroy() {
		Manager.listOfPrey.Remove(transform);
	}

	// Update is called once per frame
	void FixedUpdate () {
		foreach(Transform thisPredator in Manager.listOfPredators){
			if (thisPredator == null){
				return;
			}
			else {
				Vector3 directionToPredator = thisPredator.position - transform.position;

				if (Vector3.Angle(transform.forward, directionToPredator) <= 45f) {

					Ray preyRay = new Ray(transform.position, directionToPredator);

					RaycastHit preyHitInfo = new RaycastHit();

					if (Physics.Raycast (preyRay, out preyHitInfo, 100f)){
						Debug.Log ("I SEE A PREDATOR");

						if (preyHitInfo.collider.tag == "Predator"){
							GetComponent<Rigidbody>().AddForce((-directionToPredator.normalized) * 1000f);
						}
					}
				}
			}
		}
	}
}
