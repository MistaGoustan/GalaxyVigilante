using UnityEngine;
using System.Collections;

public class RandomEnemies : MonoBehaviour {
	public GameObject Enemy01;
	public GameObject Enemy02;
	public GameObject Enemy03;
	// shoot range
	public float Enemy01MinShootRange;
	public float Enemy01MaxShootRange;
	public float Enemy02MinShootRange;
	public float Enemy02MaxShootRange;
	public float Enemy03MinShootRange;
	public float Enemy03MaxShootRange;
	// spawn time
	public float minSpawnTime = 1f;
	public float maxSpawnTime = 3f;
	private float randTime;

	public bool Toggle = false;
	public bool SpawnEnemies;

	void RandEnemy(){
		// random enemy
		int randNum = Random.Range (1, 4);
		// random y cord for spawn
		float yCord = Random.Range (-6f, 6f);

		// initialize the random enemy
		switch (randNum) {
			// Enemy03
		case 3:
			Instantiate (Enemy03,
			             Enemy03.transform.position = new Vector2(Enemy03.transform.position.x, yCord),Quaternion.identity);
			
			break;
		case 2:
			// Enemy02
			Instantiate (Enemy02,
			             Enemy02.transform.position = new Vector2(Enemy02.transform.position.x, yCord),Quaternion.identity);
			break;
		case 1:
			// Enemy01
			Instantiate (Enemy01,
			             Enemy01.transform.position = new Vector2(Enemy01.transform.position.x, yCord),Quaternion.identity);
			break;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > randTime && SpawnEnemies == true && Toggle == false) {
			RandEnemy ();
			GetSpawnTime ();
		}
	}

	void GetSpawnTime(){
		randTime = Random.Range (minSpawnTime, maxSpawnTime);
		randTime += Time.time;
	}
}
