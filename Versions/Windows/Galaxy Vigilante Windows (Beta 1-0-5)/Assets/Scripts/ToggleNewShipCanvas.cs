using UnityEngine;
using System.Collections;

public class ToggleNewShipCanvas : MonoBehaviour {
	public GameObject menu; // Assign in inspector
	private bool isShowing =  false;
	public bool newShip = false;
	
	public void Toggle(){
		isShowing = !isShowing;
		menu.SetActive(isShowing);
		Cursor.visible = (isShowing);
	}
	public void CheckForToggle(){
		if (newShip == true) {
			Toggle ();
		}
	}
}
