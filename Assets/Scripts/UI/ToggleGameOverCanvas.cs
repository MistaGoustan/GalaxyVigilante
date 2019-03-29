using UnityEngine;
using System.Collections;

public class ToggleGameOverCanvas : MonoBehaviour {
	public GameObject menu; // Assign in inspector
	private bool isShowing =  false;
	private int playerScore;
	
	public void Toggle(){
		isShowing = !isShowing;
		menu.SetActive(isShowing); 
		Cursor.visible = (isShowing);
		if (isShowing == true) {
			LoadScores();
		}
	}
	public void LoadScores(){
		PostHighScores script = GetComponent<PostHighScores> ();
		script.PostScores ();
	}
	public void CheckForToggle(){
		// check if we can toggle
		GameObject canvasManager = GameObject.Find ("CanvasManager");
		ToggleNewShipCanvas NSCS = canvasManager.GetComponent<ToggleNewShipCanvas> ();
		if (NSCS.newShip == false) {
			Toggle ();
		}
	}
}
