using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessorySpawner : MonoBehaviour {

	public bool debugMsg = false;

	// a list of prefab hats
	public GameObject[] hatList;

	// a nice slider to control how likely it is for no hat to spawn
	[Range(0f,100f)] public float noHat = 30f;

	void OnEnable(){
		ChooseHat ();
	}

	/// <summary>
	/// Chooses the hat from the pre-specified list of hats.
	/// </summary>
	/// <returns>The hat.</returns>
	void ChooseHat(){
		// throw the dice to see if the guy has no hat
		if (Random.Range (0f, 100f) < noHat) {
			if (debugMsg) Debug.Log ("no hat was spawned");
			return;
		}

		int chosenHatIndex = Random.Range (0, hatList.Length);
		GameObject spawnedHat;
		spawnedHat = Instantiate (hatList [chosenHatIndex], transform);
		spawnedHat.transform.localPosition = Vector3.zero;
		spawnedHat.transform.localRotation = Quaternion.identity;
		if (debugMsg) Debug.Log (hatList[chosenHatIndex].name + " was spawned");
	}
}
