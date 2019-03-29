using UnityEngine;
using System.Collections;

public class ToggleSettingsCanvas : MonoBehaviour {
	public GameObject menu; // Assign in inspector
	private bool isShowing = true;
	
	public void Toggle(){
		isShowing = !isShowing;
		menu.SetActive(isShowing);
	}
}
