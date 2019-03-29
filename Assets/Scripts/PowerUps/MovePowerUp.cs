using UnityEngine;
using System.Collections;

public class MovePowerUp : MonoBehaviour {
	public GameObject powerUp;
	public float speed = -0.2f;
	
	// Update is called once per frame
	void Update () {
		speed = (Time.deltaTime*4);
		powerUp.transform.position = new Vector2 (powerUp.transform.position.x - speed,
		                                          powerUp.transform.position.y);
	}
}
