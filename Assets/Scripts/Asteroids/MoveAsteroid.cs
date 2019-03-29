using UnityEngine;
using System.Collections;

public class MoveAsteroid : MonoBehaviour {
	public GameObject Asteroid_Object;
	private Rigidbody2D RigBod;

	void Start(){
		RigBod = GetComponent<Rigidbody2D> ();
	}
	// Update is called once per frame
	void FixedUpdate () {
		// if asteroid is in the screen move it tword the ship
		if (Asteroid_Object.transform.position.x > -14f && Asteroid_Object.transform.position.x < 15f &&
		    Asteroid_Object.transform.position.y > -8f && Asteroid_Object.transform.position.y < 8f) {
			// Move Asteroid
			RigBod.AddRelativeForce (-Vector2.right);
		}
	}
}
