using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class predatorActions : MonoBehaviour {

	public Transform newPredator;

	// Update is called once per frame
	void FixedUpdate () {

		foreach (Transform thisPrey in Manager.listOfPrey) {
			if (thisPrey == null){
				return;
			}
			else {
				Vector3 directionToPrey = thisPrey.position - transform.position;

				if (Vector3.Angle(transform.forward, directionToPrey) <= 60f) {

					Ray predatorRay = new Ray(transform.position, directionToPrey);

					RaycastHit predatorHitInfo = new RaycastHit();

					if (Physics.Raycast (predatorRay, out predatorHitInfo, 100f)){
						Debug.Log ("I SEE A PREY");

						if (predatorHitInfo.collider.tag == "Prey"){

							if (predatorHitInfo.distance <= 2f){
								Instantiate(newPredator, thisPrey.transform.position, Quaternion.identity);
								GameObject.Destroy(thisPrey.gameObject);
								Debug.Log("I CAUGHT A PREY");

							} else {
								GetComponent<Rigidbody>().AddForce((directionToPrey.normalized) * 1000f);
							}
						}
					}
				}
			}
		}
	}
}
