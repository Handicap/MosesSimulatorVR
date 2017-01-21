using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class WaterScript : MonoBehaviour {

	private Mesh mesh;
	private Vector3[] vertices;
	private Vector3[] normals;

	public GameObject player;

	private Vector3 initialHeight;


	void Start () {
		initialHeight = vertices [0];
	}

	void Update () {
		
		mesh = GetComponent<MeshFilter> ().mesh;
		vertices = mesh.vertices;
		normals = mesh.normals;


		int i = 0;
		while (i < vertices.Length) {
			
			if (Vector3.Distance (vertices [i], player.transform.position) < 2f) {
				vertices [i] -= normals [i];
			} else if (vertices [i].y < initialHeight.y) {
				vertices [i] += normals [i] / 100f;
			}
			i++;
		}
		mesh.vertices = vertices;
	}
}
