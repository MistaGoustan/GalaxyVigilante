using UnityEngine;
using System.Collections;

public class MoveShot : MonoBehaviour {
	public float speed = 0.5f;
	public GameObject Shot_Object;
	public float ShotBoarder;

	// Update is called once per frame
	void FixedUpdate () {
		if (ShotBoarder < 0) {
			// move shot for enemy
			Shot_Object.transform.position = new Vector2 (Shot_Object.transform.position.x + speed,
			                                              Shot_Object.transform.position.y);
		} else if (ShotBoarder > 0) {
			// move shot for player
			Shot_Object.transform.position = new Vector2 (Shot_Object.transform.position.x + speed,
			                                              Shot_Object.transform.position.y);
		}
	}
}
