using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLogic : MonoBehaviour {

	// fading in and out times (seconds)
	public float fadeInTime = 3f;
	public float fadeOutTime = 5;

	// direction to go and speed constraints
	public Vector3 direction = Vector3.forward;
	public float minSpeed = 0.2f;
	public float maxSpeed = 1f;

	private float speed;

	// minimum and maximum lifetime
	public float maxLife = 5f;
	public float minLife = 2f;
	private float currentLife;
	private float deathTime;

	public float minScale = 0.5f;
	public float maxScale = 3f;

	public int blendShapes = 4;

	private Material cloudmat;

		
	void Start(){
		speed = Random.Range (minSpeed, maxSpeed);
		deathTime = Random.Range (minLife, maxLife);
		transform.localScale = Vector3.one * Random.Range (minScale, maxScale);

		SkinnedMeshRenderer skinrend = transform.GetChild(0).GetComponent <SkinnedMeshRenderer>();

		for (int i = 0; i < blendShapes; i++) {
			skinrend.SetBlendShapeWeight(i, Random.Range(0f, 100f));
		}

		transform.localRotation = Quaternion.Euler (0, Random.Range (0, 359), 0);

		cloudmat = skinrend.material;

	}

	// Update is called once per frame
	void Update () {
		transform.position = transform.position + (direction * speed);
		currentLife = currentLife + Time.deltaTime;

		if (currentLife > deathTime) {
			Destroy (gameObject);
		}


	}

	private Color ChangeAlpha(Color original, float alpha){
		Color newcol = new Color(cloudmat.color.r, cloudmat.color.g, cloudmat.color.b, alpha);
		return newcol;
	}

}
