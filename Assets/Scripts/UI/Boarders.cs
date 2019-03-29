using UnityEngine;
using System.Collections;

public class Boarders : MonoBehaviour {
	public Camera mainCam;//Declare var to store the camera 
	public Transform player;//Declare var to store the player
	public BoxCollider2D topWall;
	public BoxCollider2D bottomWall;
	public BoxCollider2D rightWall;
	public BoxCollider2D leftWall;


	// Use this for initialization
	void Start () {
		topWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
		topWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height, 0f)).y + 0.5f);
		// size and center the wall based on ratio
		bottomWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
		bottomWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height - Screen.height, 0f)).y - 0.5f);
		// size and center the wall based on ratio
		rightWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
		rightWall.offset = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width, 0f, 0f)).x + 0.5f, 0f);
		// size and center the wall based on ratio
		leftWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
		leftWall.offset = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x - 0.5f, 0f);
		// player object setting its position based on ratio
		Vector2 pOnePos = player.position;//Store the player position inside of vector
		pOnePos.x = mainCam.ScreenToWorldPoint (new Vector2 (128f, 0f)).x;//Set the var to 75 pixels right of the camera
		player.position = pOnePos;//Declare the players position as the variable 
	}
	
	// Update is called once per frame
	void Update () {
		// size and center the wall based on ratio

	}
}
