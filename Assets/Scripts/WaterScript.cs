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

	public GameObject player1;
    public GameObject player2;
    public float arith;
	public Vector3 initialHeight;

    public float floodspeed = 1f;

	void Start () {

		mesh = GetComponent<MeshFilter> ().mesh;
		vertices = mesh.vertices;
		initialHeight = vertices [0];


		
		mesh = GetComponent<MeshFilter> ().mesh;
		vertices = mesh.vertices;
		normals = mesh.normals;


	}

	void Update () {
		
		mesh = GetComponent<MeshFilter> ().mesh;
		vertices = mesh.vertices;
		normals = mesh.normals;

		int i = 0;

		while (i < vertices.Length) {
			
			if (Vector3.Distance (vertices [i], player1.transform.position) < 2f || Vector3.Distance(vertices[i], player2.transform.position) < 2f) {
				vertices [i] -= normals [i]*2;

			} else if (vertices [i].y < initialHeight.y) {

				vertices [i] += normals [i] / 300f * floodspeed;
			}

			i++;
		}
		mesh.vertices = vertices;
	}
}
