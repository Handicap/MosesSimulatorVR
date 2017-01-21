using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {


	private ObjectPooler Pool;
	public int deathCount;
	private float spawntimer;
	private int poolCount;
	private Vector3 spawnPoint;
	public float spawnRange;
    public GameObject button;
    public float waitTime;

	void Start () {
		Pool = GetComponent<ObjectPooler> ();
		deathCount = 40;
		spawntimer = .5f;
		poolCount = Pool.pools.Length;
		StartCoroutine (wave ());
	}

    private float score;
         
	private IEnumerator wave () {

        yield return new WaitForSeconds (waitTime);

        score = 0;
		while (deathCount > 0) {

            for (int i = 2; i > 0; i--)
            {
                spawnPoint = transform.position;
                spawnPoint.z += Random.Range(-spawnRange, spawnRange);
                Pool.GetFromPool(Random.Range(0, poolCount)).transform.position = spawnPoint;
            }
			//spawntimer -= .04f;

//			if (spawntimer <= .1f)
//				spawntimer = .1f;

			yield return new WaitForSeconds (spawntimer);
		}

        button.SetActive (true);
        foreach (GameObject jew in GameObject.FindGameObjectsWithTag ("duckling"))
        {
            if (jew.activeInHierarchy)
                score++;
        }
        foreach (TextMesh t in button.transform.GetComponentsInChildren<TextMesh>())
        {
            t.text = (Time.timeSinceLevelLoad) + " seconds";
        }
			
		yield break;
	}
}
