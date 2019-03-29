using UnityEngine;
using System.Collections;

public class ShipMove : MonoBehaviour {
	public GameObject Ship;
	public float speed = .2f;
	public float moveVert;
	public float moveHor;
	public bool canMove = true;

	// Update is called once per frame
	void Update () {
		speed = (Time.deltaTime*12);
		if (canMove == true) {
			moveVert = Input.GetAxis ("Vertical") ;
			moveHor = Input.GetAxis ("Horizontal");
			Vertical ();
			Horizontal ();
		} 
	}
	void Vertical(){
		//Ship.transform.position = new Vector2 (Ship.transform.position.x, Ship.transform.position.y + (moveVert * speed));

		// if ship is below top screen then move if its at the max height allow to move back down
		if (Ship.transform.position.y < 6.2f && moveVert > 0 && canMove == true) {
			Ship.transform.position = new Vector2 (Ship.transform.position.x, Ship.transform.position.y + (moveVert * speed));
		}
		// if ship is above bottom screen then move if its at the min height allow to move up
		else if (Ship.transform.position.y > -6.4f && moveVert < 0 && canMove == true) {
			Ship.transform.position = new Vector2 (Ship.transform.position.x, Ship.transform.position.y + (moveVert * speed));
		} 
	}

	void Horizontal() {
		//Ship.transform.position = new Vector2 (Ship.transform.position.x + (moveHor * speed), Ship.transform.position.y);


		// if ship is behind right screen edge then allow to move back
		if (Ship.transform.position.x < 11.8f && moveHor > 0 && canMove == true) {
			Ship.transform.position = new Vector2 (Ship.transform.position.x + (moveHor * speed), Ship.transform.position.y);
		} 
		// if ship is past the left screen edge then allow to move up
		else if (Ship.transform.position.x > -11.8f && moveHor < 0 && canMove == true) {
			Ship.transform.position = new Vector2 (Ship.transform.position.x + (moveHor * speed), Ship.transform.position.y);
		}
	}
}
