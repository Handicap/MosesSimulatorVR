﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class WaterCollisionScript2 : MonoBehaviour {

	private Vector3[] vertices;
	private WaterScript water;
	private Vector3 nearest;
	private float nearestDist;
	private float dist;

	void Start () {
		water = GameObject.Find ("waterMesh").GetComponent<WaterScript> ();
	}

	void OnEnable () {
        nearest = new Vector3(0, -100);
	}


	void Update () {
		vertices = water.vertices;
		nearestDist = Mathf.Infinity;
		for (int i = 0; i < vertices.Length; i++) {
			dist = Vector3.Distance (transform.position, vertices [i]);
			if (dist < nearestDist) {
				nearestDist = dist;
				nearest = vertices [i];
			}
		}
		if (nearest.y > transform.position.y) {
			gameObject.SetActive (false);
		}
	}
}
