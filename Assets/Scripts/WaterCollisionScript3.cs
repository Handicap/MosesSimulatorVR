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

    private GameObject waterObj;

    public bool debugGizmos = false;

    public float drowningHeight = 0.4f;

	void Start () {
		water = GameObject.Find ("waterMesh").GetComponent<WaterScript> ();
        sp = GameObject.Find("Spawner").GetComponent<SpawnerScript>();

        // graffasamulin häröilyä
        waterObj = GameObject.Find("waterMesh");
	}

	void OnEnable () {
        nearest = new Vector3(0, -100);
	}


	void Update () {
		vertices = water.vertices;
		nearestDist = Mathf.Infinity;
		for (int i = 0; i < vertices.Length; i++) {
            dist = Vector3.Distance(transform.position, vertices[i] + waterObj.transform.position);
			if (dist < nearestDist) {
				nearestDist = dist;
				nearest = vertices [i] + waterObj.transform.position;
			}
		}
		if (nearest.y > transform.position.y + drowningHeight) {
            sp.deathCount--;
			gameObject.SetActive (false);
		}

        if (debugGizmos){
            Debug.DrawLine(nearest, nearest + Vector3.up * 10);
            Debug.DrawLine(nearest + Vector3.back * -5, nearest + Vector3.back * 10, Color.red);
            Debug.DrawLine(transform.position + Vector3.forward * -5 + Vector3.up * drowningHeight, transform.position + Vector3.forward * 10 + Vector3.up * drowningHeight, Color.green);
            
        }
	}

    void OnTriggerEnter(Collider jokucollider)
    {
        if (jokucollider.gameObject.name == "end_collider")
        {
            Debug.Log("reached destination");
            gameObject.SetActive(false);
        }
    }
}
