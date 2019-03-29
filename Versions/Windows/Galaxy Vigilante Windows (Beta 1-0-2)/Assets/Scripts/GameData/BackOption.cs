using UnityEngine;
using System.Collections;

public class BackOption : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			FindScene ();
		}
	}
	void FindScene(){
		LoadScene script = GetComponent<LoadScene>();
		GameObject gameController = GameObject.Find ("GameController");
		GameControl gameScript = gameController.GetComponent<GameControl> ();
//		DataManager dataScript = GetComponent<DataManager> ();
		if (Application.loadedLevelName == "Options") {
			gameScript.Save ();
			script.SceneToLoad (0);
		} else if(Application.loadedLevelName == "PickShip"){
			GameObject pickShipManager = GameObject.Find ("PickShipManager");
			PickShipManager pickScript = pickShipManager.GetComponent<PickShipManager>();
			pickScript.GoBack ();
		} else {
			gameScript.Save ();
			script.SceneToLoad (1);
		}
	}
}
