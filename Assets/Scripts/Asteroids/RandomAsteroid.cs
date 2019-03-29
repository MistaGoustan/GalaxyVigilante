﻿using UnityEngine;
using System.Collections;

public class RandomAsteroid : MonoBehaviour {
	public GameObject Big_Asteroid;
	public GameObject Medium_Asteroid;
	public GameObject Small_Asteroid;
	public float xSpawn;
	// spawn time
	public float minSpawnTime = 1f;
	public float maxSpawnTime = 2f;
	private float randTime;
	
	public bool SpawnAsteroids = true;

	void RandAsteroid(){
		// random asteroid size
		int randNum = Random.Range (1, 4);
		// random y cord for spawn
		float yCord = Random.Range (-6f, 6f);

		// initialize the random asteriod
		switch (randNum) {
		// Large Asteroid
		case 3:
			Instantiate (Big_Asteroid,
			             new Vector2 (xSpawn, yCord),
			             Quaternion.identity);

			break;
		case 2:
			// Medium Asteroid
			Instantiate (Medium_Asteroid,
			             new Vector2 (xSpawn, yCord),
			             Quaternion.identity);
			break;
		case 1:
			// Small Asteroid

			Instantiate (Small_Asteroid,
			             new Vector2 (xSpawn, yCord),
			             Quaternion.identity);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > randTime && SpawnAsteroids == true) {
			RandAsteroid ();
			GetSpawnTime ();
		}
	}
	
	void GetSpawnTime(){
		randTime = Random.Range (minSpawnTime, maxSpawnTime);
		randTime += Time.time;
	}
}