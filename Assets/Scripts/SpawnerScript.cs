using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {


	private ObjectPooler Pool;
	private int deathCount;
	private float spawntimer;
	private int poolCount;
	private Vector3 spawnPoint;
	public float spawnRange;

	void Start () {
		Pool = GetComponent<ObjectPooler> ();
		deathCount = 40;
		spawntimer = 5f;
		poolCount = Pool.pools.Length;
		StartCoroutine (wave ());
	}

	private IEnumerator wave () {

//		yield return new WaitForSeconds (10);

		while (deathCount > 0) {
			Debug.Log ("SeES");
			spawnPoint = transform.position;
			spawnPoint.z += Random.Range (-spawnRange / 2f, spawnRange / 2f);
			Pool.GetFromPool (Random.Range(0, poolCount)).transform.position = spawnPoint;

			spawntimer -= .04f;

			if (spawntimer <= .1f)
				spawntimer = .1f;

			yield return new WaitForSeconds (spawntimer);
		}
			
		yield break;
	}
}
