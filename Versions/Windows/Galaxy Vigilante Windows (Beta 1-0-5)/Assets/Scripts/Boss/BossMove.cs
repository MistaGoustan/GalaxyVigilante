﻿using UnityEngine;
using System.Collections;

public class BossMove : MonoBehaviour {
	public GameObject Boss;
	public float xBoarder;
	private Rigidbody2D RigBod;
	private bool moveForward = true;

	void Start(){
		RigBod = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		if (Boss.transform.position.y > 0) {
			RigBod.AddForce (-Vector2.up, ForceMode2D.Force);
		} else if (Boss.transform.position.y < 0) {
			RigBod.AddForce (Vector2.up, ForceMode2D.Force);
		}

	}
	void Update(){
		MoveForward ();
	}

	void MoveForward(){
		if (moveForward == true) {
			if (Boss.transform.position.x > xBoarder) {
				Boss.transform.position = new Vector2 (Boss.transform.position.x - 0.03f, Boss.transform.position.y);
			} else if (Boss.transform.position.x < xBoarder && Boss.transform.position.x > (xBoarder - 1)) {
				Boss.transform.position = new Vector2 (Boss.transform.position.x - 0.02f, Boss.transform.position.y);
			} else if (Boss.transform.position.x < (xBoarder - 1) && Boss.transform.position.x > (xBoarder - 2)) {
				Boss.transform.position = new Vector2 (Boss.transform.position.x - 0.01f, Boss.transform.position.y);
			} else {
				moveForward = false;
			}
		}
	}
}
