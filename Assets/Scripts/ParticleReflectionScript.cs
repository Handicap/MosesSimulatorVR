﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleReflectionScript : MonoBehaviour {


	void Start () {
		
	}


	void Update () {
		
	}

	private void OnParticleCollision (GameObject GO) {
        if (GO.tag != "Hand")
        {
            GO.SetActive(false);
        }
        
	}
}
