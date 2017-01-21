using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class WaterCollisionScript3 : MonoBehaviour {

	private Vector3[] vertices;
    private SpawnerScript sp;
	private WaterScript water;
	public Vector3 nearest;
	private float nearestDist;
	public float dist;

    public bool debugGizmos = false;

	void Start () {
		water = GameObject.Find ("waterMesh").GetComponent<WaterScript> ();
        sp = GameObject.Find("Spawner").GetComponent<SpawnerScript>();
	}

	void OnEnable () {
        nearest = new Vector3(0, -100);
	}


	void Update () {
		vertices = water.vertices;
		nearestDist = Mathf.Infinity;
		for (int i = 0; i < vertices.Length; i++) {
            dist = Vector3.Distance(transform.position, vertices[i]);
			if (dist < nearestDist) {
				nearestDist = dist;
				nearest = vertices [i];
			}
		}
		if (nearest.y > transform.position.y + 0.5f) {
            sp.deathCount--;
			gameObject.SetActive (false);
		}

        if (debugGizmos){
            Debug.DrawLine(nearest, nearest + Vector3.up * 10);
        }
	}
}
