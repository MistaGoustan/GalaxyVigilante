using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour {
	// ships location
	public Transform Ships_Transform;
	// this is the Shot prefab
	public GameObject Shot_Object;
	public bool CanShoot = true;

	private float randTime;
	public float minShootRange;
	public float maxShootRange;

	public float Xpos = 0.9f;
	public float Ypos = 0f;

	void Start(){
		GetSpawnTime ();
		// set the starting fire rate
		if (gameObject.tag == "Enemy01") {
			GameObject enemies = GameObject.Find ("Enemies");
			RandomEnemies script = enemies.GetComponent<RandomEnemies> ();
			minShootRange = script.Enemy01MinShootRange;
			maxShootRange = script.Enemy01MaxShootRange;
		} else if (gameObject.tag == "Enemy03") {
			GameObject enemies = GameObject.Find ("Enemies");
			RandomEnemies script = enemies.GetComponent<RandomEnemies> ();
			minShootRange = script.Enemy03MinShootRange;
			maxShootRange = script.Enemy03MaxShootRange;
		} else if (gameObject.tag == "Boss") {
			GameObject bosses = GameObject.Find ("Bosses");
			SpawnBoss bossScript = bosses.GetComponent<SpawnBoss> ();
			minShootRange = bossScript.minShootRange;
			maxShootRange = bossScript.maxShootRange;
		}
	}

	void Fire(){
		// create the shot instance
		Instantiate(Shot_Object, 
		            new Vector2 (Ships_Transform.position.x - Xpos, Ships_Transform.position.y + Ypos),
		            Quaternion.identity);
		Sound ();
	}
	
	void Sound(){
		PlaySound soundScript = GetComponent<PlaySound> ();
		soundScript.Play ();
	}
	
	void GetSpawnTime(){
		randTime = Random.Range (minShootRange, maxShootRange);
		randTime += Time.time;
	}
	// Update is called once per frame
	void Update () {
		if (Time.time > randTime) {
			Fire ();
			GetSpawnTime ();
		}
	}
}
