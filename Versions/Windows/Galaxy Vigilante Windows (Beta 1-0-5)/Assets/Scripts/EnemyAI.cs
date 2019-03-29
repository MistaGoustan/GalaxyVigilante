using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public GameObject Enemy;
	private float Speed = 6f;
	private Rigidbody2D RigBod;
	// store the starting speed to keep a constant velocity
	private Vector2 ExactSpeed;
	private float centerSpawn;
	
	void Start(){
		// store spawn location
		GetSpawnLocation ();
		RigBod = GetComponent<Rigidbody2D> ();
		RigBod.AddForce (-Vector2.right * Speed, ForceMode2D.Impulse);
		ExactSpeed = RigBod.velocity;
	}

	void FixedUpdate () {
		// Move Side to Side
		if (Enemy.transform.position.y > centerSpawn) {
			RigBod.AddForce (-Vector2.up, ForceMode2D.Force);
		} else if (Enemy.transform.position.y < centerSpawn) {
			RigBod.AddForce (Vector2.up, ForceMode2D.Force);
		}
		// Move Forward
		SetSpeed ();
	}
	void GetSpawnLocation(){
		if (Enemy.transform.position.y > 0) {
			centerSpawn = Enemy.transform.position.y - 2f;
		} else if (Enemy.transform.position.y < 0) {
			centerSpawn = Enemy.transform.position.y + 2f;
		}
	}
	void SetSpeed(){
		// SETTING THE SPEED
		RigBod.velocity = new Vector2(ExactSpeed.x, RigBod.velocity.y);
	}
}
