using UnityEngine;
using System.Collections;

public class ShipDoubleShot : MonoBehaviour {
	// ships location
	public Transform Ships_Transform;
	// this is the Shot prefab
	public bool ToggleShot = false;
	public float ReloadTime = 0.0f;
	public GameObject Shot_Object;
	public float ShotLocationX = 0.9f;
	// for controller
	private bool TriggerPressed = false;

	void Fire(){
		// find shot cord1 before instance
		Vector2 pos1 = new Vector2 (Ships_Transform.position.x + ShotLocationX, Ships_Transform.position.y + 0.3f); 
		// create the shot1 instance
		Instantiate(Shot_Object, Shot_Object.transform.position = pos1, Shot_Object.transform.rotation);
		// find shot cord2 before instance
		Vector2 pos2 = new Vector2 (Ships_Transform.position.x + ShotLocationX, Ships_Transform.position.y - 0.3f); 
		// create the shot2 instance
		Instantiate(Shot_Object, Shot_Object.transform.position = pos2, Shot_Object.transform.rotation);
		Sound ();
	}
	
	void Sound(){
		PlaySound soundScript = GetComponent<PlaySound> ();
		soundScript.Play ();
	}

	// Update is called once per frame
	void Update () {
		// if player presses button and you can shoot then fire
		if (Input.GetAxis ("Fire") == 0 && TriggerPressed == true){
			TriggerPressed = false;
		}
		// if on keyboard space is pressed or xbox right trigger pressed
		if (Input.GetButtonDown ("Fire") && ReloadTime >= 0.225f && ToggleShot == false ||
		    Input.GetAxis ("Fire") == -1 && ReloadTime >= 0.225f && ToggleShot == false && TriggerPressed == false) {
			TriggerPressed = true;
			Fire();
			// reset
			ReloadTime = 0.0f;
		}
		// if keyboard spacebar or xbox trigger held down
		if (Input.GetButton ("Fire") && ReloadTime >= 0.45f && ToggleShot == false ||
		    Input.GetAxis ("Fire") == -1 && ReloadTime >= 0.45f && ToggleShot == false){
			TriggerPressed = true;
			Fire();
			// reset
			ReloadTime = 0.0f;
		}
		// add to the time
		ReloadTime += Time.deltaTime;
	}
}
