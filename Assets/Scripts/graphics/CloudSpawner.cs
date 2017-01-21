using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates cloud objects as a point of reference/graphical thingamajick
/// </summary>
public class CloudSpawner : MonoBehaviour {

	public GameObject cloud_prefab;

	public float minSpawnFreq = 2f;
	public float maxSpawnFreq = 5f;
	public float nextPhase;
	public float currentTime = 0f;

	private GameObject corner1;
	private GameObject corner2;
	private GameObject cloudpool;

	public Vector3 cloudTravelVector = Vector3.forward;

	void Start(){
		nextPhase = minSpawnFreq;
		corner1 = transform.GetChild (0).gameObject;
		corner2 = transform.GetChild (1).gameObject;
		cloudpool = transform.GetChild (2).gameObject;
	}

	// Update is called once per frame
	void Update () {
		currentTime = currentTime + Time.deltaTime;
		if (currentTime > nextPhase) {
		
			nextPhase = Random.Range (minSpawnFreq, maxSpawnFreq);
			Vector3 spawnPos = GenerateSpawnPos ();
			GameObject newcloud = Instantiate (cloud_prefab, spawnPos, Quaternion.identity, cloudpool.transform);
			CloudLogic newcloudLog = newcloud.GetComponent <CloudLogic>();
			newcloudLog.direction = cloudTravelVector;
			currentTime = 0f;

		}
	}

	/// <summary>
	/// Generates a new vector3 by randomizing between the corner positions
	/// </summary>
	/// <returns>Vector3 that is the new spawn position.</returns>
	Vector3 GenerateSpawnPos(){

		Vector3 newpos = Vector3.zero;

		newpos.x = Random.Range (corner1.transform.position.x, corner2.transform.position.x);
		newpos.y = Random.Range (corner1.transform.position.y, corner2.transform.position.y);
		newpos.z = Random.Range (corner1.transform.position.z, corner2.transform.position.z);

		return newpos;
	}
}
