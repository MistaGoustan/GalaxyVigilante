using UnityEngine;
using System.Collections;

public class StarsMove : MonoBehaviour {
	public Transform Stars;
	public float speed = -2f;
	private float moveSpeed;
	public float MoveTime = 0.0f;
	// Use this for initialization
	void Start () {
		MoveTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		moveSpeed = (Time.deltaTime * speed);
		Stars.position = new Vector2 (Stars.position.x + moveSpeed, Stars.position.y);
		if (Stars.position.x <= -27.2f) {
			Stars.position = new Vector2(27.2f,0);
		}
	}
}
