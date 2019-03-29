using UnityEngine;
using System.Collections;

public class ShipLongShot : MonoBehaviour {
	// ships location
	public Transform Ships_Transform;
	// this is the Shot prefab
	public bool ToggleShot = false;
	public float ReloadTime = 0.0f;
	public GameObject Shot_Object;
	public bool CanShoot = true;
	// for controller
	private bool TriggerPressed = false;

	void Fire(){
		// find shot cord before instance
		Vector2 pos = new Vector2 (Ships_Transform.position.x + 0.9f, Ships_Transform.position.y); 
		// create the shot instance
		Instantiate(Shot_Object, Shot_Object.transform.position = pos, Shot_Object.transform.rotation);
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
		if (Input.GetButtonDown ("Fire") && ReloadTime >= 0.1f && ToggleShot == false ||
		    Input.GetAxis ("Fire") == -1 && ReloadTime >= 0.1f && ToggleShot == false && TriggerPressed == false) {
			TriggerPressed = true;
			Fire();
			//reset
			ReloadTime = 0.0f;
		}
		// if keyboard spacebar or xbox trigger held down
		if (Input.GetButton ("Fire") && ReloadTime >= 0.35f && ToggleShot == false ||
		    Input.GetAxis ("Fire") == -1 && ReloadTime >= 0.35f && ToggleShot == false){
			TriggerPressed = true;
			Fire();
			// reset
			ReloadTime = 0.0f;
		}
		// add to the time
		ReloadTime += Time.deltaTime;
	}
}
