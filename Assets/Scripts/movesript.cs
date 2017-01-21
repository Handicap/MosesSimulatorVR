using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movesript : MonoBehaviour {

	Vector3 dir;
	public float speed;

	void Start () {
		dir = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.H))
		dir.x = 1;
	else if (Input.GetKey (KeyCode.K))
		dir.x = -1;
	else
		dir.x = 0;

	if (Input.GetKey (KeyCode.U))
		dir.y = 1;
		else if (Input.GetKey (KeyCode.J))
			dir.y = -1;
		else
			dir.y = 0;


		if (Input.GetKey (KeyCode.Mouse0))
			dir.z = 1;
		else if (Input.GetKey (KeyCode.Mouse1))
			dir.z = -1;
		else
			dir.z = 0;

		transform.position += dir * speed;
	}
}
