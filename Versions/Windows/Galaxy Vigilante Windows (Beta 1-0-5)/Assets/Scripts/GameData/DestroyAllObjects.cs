using UnityEngine;
using System.Collections;

public class DestroyAllObjects : MonoBehaviour {
	public bool Destroy_All = false;
	
	// Update is called once per frame
	void Update () {
		if(Destroy_All == true){
			Destroy();
			Destroy_All = false;
		}
	}
	void Destroy (){
		Shots ();
		Enemies ();
		PowerUps ();
		Asteroids ();
	}
	void DestroyObjects(GameObject[] destroyObject){
		for(int i = 0; i < destroyObject.Length; i++){
			// Destroy each one
			Destroy(destroyObject[i]);
		}
		
	}
	void Asteroids(){
		GameObject[] Small_Asteroids = GameObject.FindGameObjectsWithTag("Small_Asteroid");
		GameObject[] Medium_Asteroids = GameObject.FindGameObjectsWithTag("Medium_Asteroid");
		GameObject[] Big_Asteroids = GameObject.FindGameObjectsWithTag("Big_Asteroid");
		DestroyObjects (Small_Asteroids);
		DestroyObjects (Medium_Asteroids);
		DestroyObjects (Big_Asteroids);
	}
	void PowerUps(){
		GameObject[] PowerUps01 = GameObject.FindGameObjectsWithTag("PowerUp01");
		GameObject[] PowerUps02 = GameObject.FindGameObjectsWithTag("PowerUp02");
		GameObject[] PowerUps03 = GameObject.FindGameObjectsWithTag("PowerUp03");
		GameObject[] PowerUps04 = GameObject.FindGameObjectsWithTag("PowerUp04");
		DestroyObjects (PowerUps01);
		DestroyObjects (PowerUps02);
		DestroyObjects (PowerUps03);
		DestroyObjects (PowerUps04);
	}
	void Enemies(){
		GameObject[] Enemies01 = GameObject.FindGameObjectsWithTag("Enemy01");
		GameObject[] Enemies02 = GameObject.FindGameObjectsWithTag("Enemy02");
		GameObject[] Enemies03 = GameObject.FindGameObjectsWithTag("Enemy03");
		DestroyObjects (Enemies01);
		DestroyObjects (Enemies02);
		DestroyObjects (Enemies03);
	}
	void Shots(){
		GameObject[] pShots = GameObject.FindGameObjectsWithTag("Shot");
		GameObject[] eShots = GameObject.FindGameObjectsWithTag("EnemyShot");
		GameObject[] plShots = GameObject.FindGameObjectsWithTag("LongShot");
		GameObject[] elShots = GameObject.FindGameObjectsWithTag("EnemyLongShot");
		DestroyObjects (pShots);
		DestroyObjects (eShots);
		DestroyObjects (plShots);
		DestroyObjects (elShots);
	}
}
