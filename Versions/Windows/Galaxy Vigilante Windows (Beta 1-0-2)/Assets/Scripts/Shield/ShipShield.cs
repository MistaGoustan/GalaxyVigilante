using UnityEngine;
using System.Collections;

public class ShipShield : MonoBehaviour {
	public GameObject Shield;
	public bool SpawnShield = false;
	private float RespawnTime = 0.0f;
	public bool ShieldExists = false;
	
	// Update is called once per frame
	void Update () {
		GameObject shield = GameObject.FindWithTag("Shield");
		if (SpawnShield == true && ShieldExists != true) {
			Spawn ();
			SpawnShield = false;
			ShieldExists = true;
			RespawnTime = 0.0f;
		} else {
			SpawnShield = false;
		}
		// add to the time
		RespawnTime += Time.deltaTime;
		// if time is ready shield can be destroyed
		if(RespawnTime >= 0.5f)
		{
			if (shield != null){
				ShieldCollide shieldScript = shield.GetComponent<ShieldCollide>();
				shieldScript.canDestroy = true;
			}
		}
	}
	void Spawn(){
		GameObject ship = GameObject.FindWithTag("Ship");
		// find shot cord before instance
		Vector2 pos = new Vector2 (ship.transform.position.x, ship.transform.position.y); 
		Instantiate (Shield,
		             Shield.transform.position = pos,
		             Shield.transform.rotation);
	}
}
