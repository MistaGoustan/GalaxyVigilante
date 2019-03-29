using UnityEngine;
using System.Collections;

public class TogglePauseCanvas : MonoBehaviour {
	public GameObject menu; // Assign in inspector
	private bool isShowing;

	void Update() {
		// if ships not dead and player presses esc toggle pause screen
		if (Input.GetButtonDown("Pause")) {
			// find ship object	
			GameObject Ship = GameObject.FindWithTag ("Ship");
			// if ship exists then toggle screen 
			if (Ship != null){
				Toggle ();
			}
		}
	}
	public void Toggle(){
		isShowing = !isShowing;
		menu.SetActive(isShowing);
		Cursor.visible = (isShowing);
	}
}