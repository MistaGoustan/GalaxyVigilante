using UnityEngine;
using System.Collections;

public class RandomPowerUp : MonoBehaviour {
	public GameObject PowerUp01;
	public GameObject PowerUp02;
	public GameObject PowerUp03;
	public GameObject PowerUp04;
	public GameObject Ship;
	// spawn time
	public float minSpawnTime = 60f;
	public float maxSpawnTime = 120f;
	private float randTime;

	public bool WillSpawn = false;

	// Update is called once per frame
	void Update () {
		if (randTime == 0) {
			GetSpawnTime();
		}
		else if (Time.time > randTime) {
			WillSpawn = true;
			GetSpawnTime ();
		}
	}
	void GetSpawnTime(){
		randTime = Random.Range (minSpawnTime, maxSpawnTime);
		randTime += Time.time;
	}
	public void SpawnPowerUp(Vector2 cords, int powerType){
		if (WillSpawn == true) {
			switch (powerType) {
			case 1:
				Instantiate (PowerUp01,
				             PowerUp01.transform.position = cords,
				             Quaternion.identity);
				break;
			case 2:
				Instantiate (PowerUp02,
				             PowerUp02.transform.position = cords,
				             Quaternion.identity);
				break;
			case 3:
				Instantiate (PowerUp03,
				             PowerUp03.transform.position = cords,
				             Quaternion.identity);
				break;
			case 4:
				Instantiate (PowerUp04,
				             PowerUp04.transform.position = cords,
				             Quaternion.identity);
				break;
			}
			WillSpawn = false;
		}
	}
}
