using UnityEngine;
using System.Collections;

public class MoveShot : MonoBehaviour {
	public float speed = 0.5f;
	public GameObject Shot_Object;
	public float ShotBoarder;

	// Update is called once per frame
	void FixedUpdate () {
		if (ShotBoarder < 0) {
			// if shot is in screen then move it forward
			if (Shot_Object.transform.position.x > ShotBoarder) {
				// move shot
				Shot_Object.transform.position = new Vector2 (Shot_Object.transform.position.x + speed, Shot_Object.transform.position.y);
			}
			// if shot is out of screen destroy the shot
			else {
				Destroy (Shot_Object);
			}
		} else if (ShotBoarder > 0) {
			// if shot is in screen then move it forward
			if (Shot_Object.transform.position.x < ShotBoarder) {
				// move shot
				Shot_Object.transform.position = new Vector2 (Shot_Object.transform.position.x + speed, Shot_Object.transform.position.y);
			}
			// if shot is out of screen destroy the shot
			else {
				Destroy (Shot_Object);
			}
		}
	}
}
