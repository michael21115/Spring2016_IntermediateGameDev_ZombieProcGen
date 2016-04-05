using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	[SerializeField] Transform wallMaker;
	public static List<Transform> listOfPredators = new List<Transform>();
	public static List<Transform> listOfPrey = new List<Transform>();
	public static Transform predatorPrefab;
	public Transform preyPrefab;

	void Start () {
		listOfPrey.Clear();
		listOfPredators.Clear();
		Instantiate(wallMaker, new Vector3 (0f, 1.5f, 0f), Quaternion.identity);
	}

	public void Restart(){
		SceneManager.LoadScene(0);
	}

	// Update is called once per frame
	void Update () {
		// Raycast to determine where Predator/Prey is placed
		Ray targetLock = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit targetHitInfo = new RaycastHit();

		if (Physics.Raycast (targetLock, out targetHitInfo, 1000f) && targetHitInfo.transform.tag == "spawningValid"){
			// Instantiate Predators
			if (Input.GetMouseButtonDown(0)){
				Transform thisPredator = (Transform)Instantiate(predatorPrefab, targetHitInfo.point + new Vector3 (0f, 2f, 0f), Quaternion.identity);
				listOfPredators.Add(thisPredator);
			}

			// Instantiate Prey
			if (Input.GetMouseButtonDown(1)){
				Transform thisPrey = (Transform)Instantiate(preyPrefab, targetHitInfo.point + new Vector3 (0f, 2f, 0f), Quaternion.identity);
				listOfPrey.Add(thisPrey);
			}
		}
	}
}
