using UnityEngine;
using System.Collections;

public class MoveShield : MonoBehaviour {
	public GameObject Shield;

	// Update is called once per frame
	void Update () {
		GameObject ship = GameObject.FindWithTag("Ship");
		if (ship != null) {
			// find shot cord before instance
			Vector2 pos = new Vector2 (ship.transform.position.x - 0.025f, ship.transform.position.y);
			Shield.transform.position = new Vector2 (pos.x, pos.y);
		}
	}
}
