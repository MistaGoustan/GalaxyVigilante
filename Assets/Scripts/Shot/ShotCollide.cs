using UnityEngine;
using System.Collections;

public class ShotCollide : MonoBehaviour {

	// check for collision
	void OnCollisionEnter2D(Collision2D other){
		Destroy (gameObject);
	}
}
