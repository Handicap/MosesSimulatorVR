using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Generic GameObject pooler. Creates and stores GameObjects in a list and is able to return them
//Ideally used for bullets but can be used for other things as well, such as enemies and powerups
public class ObjectPooler : MonoBehaviour {
	//public static ObjectPooler current;

	public bool willGrow = true;//luodaanko lisää objekteja jos loppuvat
	public List<GameObject> objectsToPool = new List<GameObject>();//lista objekteista jotka luodaan
	public List<int> objectAmounts = new List<int>();//lista montako mitäkin objektia pitää luoda
	public List<GameObject>[] pools;//lista objektivarastoista
	private int poolAmount;//montako objektivarastoa tarvitaan

	private void Awake() {

		poolAmount = objectsToPool.Count;//resetoidaan tarvittavien varastojen määrä

		pools = new List<GameObject>[poolAmount];//luodaan lista varastoista

		for (int i = 0; i < poolAmount; i++) {//käydään läpi lista varastoista
			pools[i] = new List<GameObject>();//luodaan uusi varasto
			poolObjects (objectsToPool[i], objectAmounts[i], pools[i]);//täytetään varasto
		}
	}

	//
	//	void OnLevelWasLoaded(int level) {
	//		if (level > 0)
	//			init ();
	//		else 
	//			MayPoolObjects = true;
	//
	//	}



	private void poolObjects (GameObject go, int goAmount, List<GameObject> list) {
		if (go) {
			for (int i = 0; i < goAmount; i++) {
				MakeNewObject(go, list);
			}
		}
	}

	//Make new GameObjects and add them to the list
	private GameObject MakeNewObject(GameObject newGo, List<GameObject> list) {
		//Instantiate new GameObject
		GameObject obj = (GameObject)Instantiate(newGo);

		//New objects are set to inactive, they are not used yet
		obj.SetActive(false);

		//Add the objects to the list
		list.Add(obj);

		return obj;
	}

	//Make new GameObject, add them to the list and return it
	private GameObject GetNewObject(GameObject newGo, List<GameObject> pool) {

		GameObject obj = MakeNewObject (newGo, pool);

		//Return the object
		return obj;
	}

	//Returns single object from the first pool
	public GameObject GetPooledObject() {
		return GetFromPool (0);
	}

	public GameObject GetFromPool(int poolNumber) {

		foreach (GameObject pooledObject in pools[poolNumber]) {//käydään läpi objektit halutussa pooolissa
			if(!pooledObject.activeInHierarchy) {//jos objekti on epäaktiivinen
				pooledObject.SetActive(true);//aktivoi se
				return pooledObject;//ja palauta se
			}
		}
		//mutta jos epäaktiivista objektia ei ollut
		if(willGrow) {//ja uusia objekteja saa luoda

			GameObject obj = GetNewObject(objectsToPool[poolNumber], pools[poolNumber]);//luodaan uusi halutun mallinen objekti, joka lisätään haluttuun pooliin
			obj.SetActive(true);//aktivoidaan se
			return obj;//ja palautetaan se
		}
		return null;
	}
}