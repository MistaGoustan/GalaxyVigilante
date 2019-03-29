using UnityEngine;
using System.Collections;

public class SpawnBoss : MonoBehaviour {
	public GameObject Boss;
	private GameObject healthBar;
	public float minShootRange;
	public float maxShootRange;
	public float minDoubleShootRange;
	public float maxDoubleShootRange;

	void Awake(){
		healthBar = GameObject.Find ("BossHealthBG");
		healthBar.SetActive (false);
	}

	public void SpawnTheBoss () {
		healthBar.SetActive (true);
		StartCoroutine(WaitAndSpawn(3.0f));
	}

	void Spawn(){
		Instantiate (Boss,
		             Boss.transform.position,
		             Quaternion.identity);
		BossHealth script = Boss.GetComponent<BossHealth> ();
		script.currentHealth = script.maxHealth;

	}

	public IEnumerator WaitAndSpawn(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Spawn ();
	}
}
