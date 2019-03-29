using UnityEngine;
using System.Collections;

public class ToggleYNCanvas : MonoBehaviour {
	public GameObject menu; // Assign in inspector
	private bool isShowing;

	public void Toggle(){
		isShowing = !isShowing;
		menu.SetActive(isShowing);
	}
}
