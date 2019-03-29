using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleHighScoreCanvas : MonoBehaviour {
	public GameObject menu; // Assign in inspector
	private bool isShowing =  false;
	
	public void Toggle(){
		isShowing = !isShowing;
		menu.SetActive(isShowing); 
		Cursor.visible = (isShowing);
	}


}
