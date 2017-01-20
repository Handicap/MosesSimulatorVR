using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movement : MonoBehaviour {

    public Transform goal;
    public float range = 10.0f;
	public bool seuraa = true;
	public GameObject duck;
    public AudioClip kuolonhuuto;
    public AudioClip keraysaani;

    bool RandomPoint(Vector3 center, float range, out Vector3 result) {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        UnityEngine.AI.NavMeshHit hit;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }

    void Start()
    {

    }

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "duck" && seuraa == false) {
			seuraa = true;
     //       SoundManager.instance.PlaySingle(keraysaani);
     //       ScoreManager.ducklingsGathered++;
		}

		if (other.gameObject.tag == "sewer") {
            GetComponentInChildren<ParticleSystem>().Play();
            //	gameObject.SetActive(false);
       //     GetComponent<NavMeshAgent>().enabled = false;
      //      SoundManager.instance.PlaySingle(kuolonhuuto);
        //    ScoreManager.ducklingsAlive--;
		}
	} 

    void Update()
    {
        UnityEngine.AI.NavMeshAgent ankka = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Vector3 point;
		if (RandomPoint (transform.position, range, out point) && seuraa == false) {
			Debug.DrawRay (point, Vector3.up, Color.blue, 1.0f);
			ankka.destination = point;
		}
			if (seuraa == true) {
			ankka.destination = duck.gameObject.transform.position - new Vector3(0f,0f,-1f);
        
		}
     }
    
}
