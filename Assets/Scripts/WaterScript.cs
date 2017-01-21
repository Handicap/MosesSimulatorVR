using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class WaterScript : MonoBehaviour {

	private Mesh mesh;
	public Vector3[] vertices;
	public Vector3[] normals;

	public GameObject player;
	public float arith;
	public Vector3 initialHeight;

	void Start () {

		mesh = GetComponent<MeshFilter> ().mesh;
		vertices = mesh.vertices;
		initialHeight = vertices [0];


		
		mesh = GetComponent<MeshFilter> ().mesh;
		vertices = mesh.vertices;
		normals = mesh.normals;


	}

	private List<float> arithmetic;

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
