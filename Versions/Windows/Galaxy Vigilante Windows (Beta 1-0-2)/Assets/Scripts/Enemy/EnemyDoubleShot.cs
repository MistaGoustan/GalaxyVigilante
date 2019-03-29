using UnityEngine;
using System.Collections;

public class EnemyDoubleShot : MonoBehaviour {
	// ships location
	public Transform Ships_Transform;
	// this is the Shot prefab
	public bool ToggleShot = false;
	public GameObject Shot_Object;

	private float randTime;
	public float minShootRange;
	public float maxShootRange;
	public bool CanShoot = true;

	public float ShotLocationX = 0.9f;

	void Start(){
		// set the starting fire rate
		if (gameObject.tag == "Enemy02") {
			GameObject enemies = GameObject.Find ("Enemies");
			RandomEnemies script = enemies.GetComponent<RandomEnemies> ();
			minShootRange = script.Enemy02MinShootRange;
			maxShootRange = script.Enemy02MaxShootRange;
		}else if (gameObject.tag == "Boss") {
			GameObject bosses = GameObject.Find ("Bosses");
			SpawnBoss bossScript = bosses.GetComponent<SpawnBoss> ();
			minShootRange = bossScript.minDoubleShootRange;
			maxShootRange = bossScript.maxDoubleShootRange;
		}
	}

	void Fire(){
		// find shot cord1 before instance
		Vector2 pos1 = new Vector2 (Ships_Transform.position.x - ShotLocationX, Ships_Transform.position.y + 0.3f); 
		// create the shot1 instance
		Instantiate(Shot_Object, Shot_Object.transform.position = pos1, Shot_Object.transform.rotation);
		// find shot cord2 before instance
		Vector2 pos2 = new Vector2 (Ships_Transform.position.x - ShotLocationX, Ships_Transform.position.y - 0.3f); 
		// create the shot2 instance
		Instantiate(Shot_Object, Shot_Object.transform.position = pos2, Shot_Object.transform.rotation);
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
