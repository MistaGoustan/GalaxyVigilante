using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public GameObject Enemy;
	public float Speed = 4f;
	private Rigidbody2D RigBod;
	// store the starting speed to keep a constant velocity
	private Vector2 ExactSpeed;
	
	void Start(){
		RigBod = GetComponent<Rigidbody2D> ();
		RigBod.AddForce (-Vector2.right * Speed, ForceMode2D.Impulse);
		ExactSpeed = RigBod.velocity;
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Enemy.transform.position.y > 0) {
			RigBod.AddForce (-Vector2.up, ForceMode2D.Force);
		} else if (Enemy.transform.position.y < 0) {
			RigBod.AddForce (Vector2.up, ForceMode2D.Force);
		}
		// if enemy is in the screen move it tword the ship
		if (Enemy.transform.position.x > -14f) {
			SetSpeed ();
		}
		else if (Enemy.transform.position.x < -14f) {
			Destroy (Enemy);
		}
	}
	
	void SetSpeed(){
		// SETTING THE SPEED
		RigBod.velocity = new Vector2(ExactSpeed.x, RigBod.velocity.y);
	}
}
