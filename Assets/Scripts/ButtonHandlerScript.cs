using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandlerScript : MonoBehaviour {

	void OnTriggerEnter (Collider col) {

		if (col.tag == "Controller") {
			SceneManager.LoadScene (0);
		}
	}
}
