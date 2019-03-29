using UnityEngine;
using System.Collections;

public class ShieldCollide : MonoBehaviour {
	public bool canDestroy = false;
	void OnTriggerEnter2D(Collider2D other){
		// cant be destroyed from the ship or powerups and is on a timmer
		if (other.gameObject.tag != "Ship" && other.gameObject.tag != "PowerUp01" &&
		    other.gameObject.tag != "PowerUp02" && other.gameObject.tag != "PowerUp03" &&
		    other.gameObject.tag != "PowerUp04") {

			if(other.gameObject.tag != "Boss"){
				Destroy (other.gameObject);
			}
			if(canDestroy == true){
				Destroy(gameObject);
				// toggle shield existing
				GameObject ship = GameObject.FindWithTag ("Ship");
				ShipShield script = ship.GetComponent<ShipShield>();
				script.ShieldExists = false;
			}
		}
	}
}
