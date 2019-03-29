using UnityEngine;
using System.Collections;

public class ShieldCollide : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		// cant be destroyed from the ship or powerups and is on a timmer
		if (other.gameObject.tag != "Ship" && other.gameObject.tag != "PowerUp01" &&
		    other.gameObject.tag != "PowerUp02" && other.gameObject.tag != "PowerUp03" &&
		    other.gameObject.tag != "PowerUp04" && other.gameObject.tag != "Boundary") {

			if(other.gameObject.tag != "Boss"){
				Destroy (other.gameObject);
			}

			GameObject powerUps = GameObject.Find ("PowerUps");
			SpawnShield script = powerUps.GetComponent<SpawnShield>();
			if(script.isImmune == false){
				Destroy(gameObject);
			}
		}
	}
}
