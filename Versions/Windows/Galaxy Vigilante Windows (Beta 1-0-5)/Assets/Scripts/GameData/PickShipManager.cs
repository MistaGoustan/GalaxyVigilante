using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickShipManager : MonoBehaviour {
	public GameObject Ships;
	public Sprite[] ShipSprites;
	public Text ShipTitle;
	public Text ShipDescription;
	public Image ShipsImage;
	public Image LockImage;
	public bool[] unlockedShips;
	
	void Start () {
		LoadShip ();
	}

	void LoadShip(){
		// load the ship image at the start
		GameObject GameControl = GameObject.Find ("GameController");
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			// if unlock var exists set info
			if (script.unlockedShips != null){
				unlockedShips[0] = script.unlockedShips[0];
				unlockedShips[1] = script.unlockedShips[1];
				unlockedShips[2] = script.unlockedShips[2];
				unlockedShips[3] = script.unlockedShips[3];
			}
			Image sprite = Ships.GetComponent<Image> ();
			sprite.sprite = ShipSprites[script.ship];

			switch (sprite.sprite.name) {
			case "Ship01a":
				sprite.sprite = ShipSprites[0];
				ShipTitle.text = "Newbie Ship";
				ShipDescription.text = "Default ship, fit for a newbie.";
				LockImage.enabled = !unlockedShips[0];
				break;
			case "Ship02a":
				sprite.sprite = ShipSprites[1];
				ShipTitle.text = "Vigilante Ship";
				if (unlockedShips[1] == true){
					ShipDescription.text = "The original Vigilante Ship, you are no stranger to the galaxy. (Start with Double Shot)";
				} else {
					ShipDescription.text = "Unlocks after 10,000 points.";
				}
				LockImage.enabled = !unlockedShips[1];
				break;
			case "Ship03a":
				sprite.sprite = ShipSprites[2];
				ShipTitle.text = "Guardian Ship";
				if (unlockedShips[2] == true){
					ShipDescription.text = "Smaller hit box, fit for a professional. (Start with a Shield)";
				} else {
					ShipDescription.text = "Unlocks after killing the boss at round 10. (Difficulty Medium/Hard)";
				}
				LockImage.enabled = !unlockedShips[2];
				break;
			case "Ship04a":
				sprite.sprite = ShipSprites[3];
				ShipTitle.text = "Custom Ship";
				if (unlockedShips[3] == true){
					ShipDescription.text = "This ship is a work in progress - Unlocked";
				} else {
					ShipDescription.text = "Locked";
				}
				LockImage.enabled = !unlockedShips[3];
				break;
			}
		}
	}

	public void RightButton(){
		Image sprite = Ships.GetComponent<Image> ();
		// to save ship data
		GameObject GameControl = GameObject.Find ("GameController");
		GameControl script = GameControl.GetComponent<GameControl> ();
		switch (sprite.sprite.name) {
		case "Ship01a":
			sprite.sprite = ShipSprites[1];
			script.ship = 1;
			script.unlockedShips[1] = unlockedShips[1];
			ShipTitle.text = "Vigilante Ship";
			if (unlockedShips[1] == true){
				ShipDescription.text = "The original Vigilante Ship, you are no stranger to the galaxy. (Start with Double Shot)";
			} else {
				ShipDescription.text = "Unlocks after 10,000 points.";
			}
			LockImage.enabled = !unlockedShips[1];
			break;
		case "Ship02a":
			sprite.sprite = ShipSprites[2];
			script.ship = 2;
			script.unlockedShips[2] = unlockedShips[2];
			ShipTitle.text = "Guardian Ship";
			if (unlockedShips[2] == true){
				ShipDescription.text = "Smaller hit box, fit for a professional.  (Start with a Shield)";
			} else {
				ShipDescription.text = "Unlocks after killing the boss at round 10. (Difficulty Medium/Hard)";
			}
			LockImage.enabled = !unlockedShips[2];
			break;
		case "Ship03a":
			sprite.sprite = ShipSprites[3];
			script.ship = 3;
			ShipTitle.text = "Custom Ship";
			if (unlockedShips[3] == true){
				ShipDescription.text = "This ship is a work in progress - Unlocked";
			} else {
				ShipDescription.text = "Locked";
			}
			LockImage.enabled = !unlockedShips[3];
			break;
		case "Ship04a":
			// Go back to first
			sprite.sprite = ShipSprites[0];
			script.ship = 0;
			script.unlockedShips[0] = unlockedShips[0];
			ShipTitle.text = "Newbie Ship";
			ShipDescription.text = "Default ship, fit for a newbie.";
			LockImage.enabled = !unlockedShips[0];
			break;
		}
	}
	public void LeftButton(){
		Image sprite = Ships.GetComponent<Image> ();
		// to save ship data
		GameObject GameControl = GameObject.Find ("GameController");
		GameControl script = GameControl.GetComponent<GameControl> ();
		switch (sprite.sprite.name) {
		case "Ship01a":
			// Go to last
			sprite.sprite = ShipSprites[3];
			script.ship = 3;
			ShipTitle.text = "Custom Ship";
			if (unlockedShips[3] == true){
				ShipDescription.text = "This ship is a work in progress - Unlocked";
			} else {
				ShipDescription.text = "Locked";
			}
			LockImage.enabled = !unlockedShips[3];
			break;
		case "Ship02a":
			sprite.sprite = ShipSprites[0];
			script.ship = 0;
			script.unlockedShips[0] = unlockedShips[0];
			ShipTitle.text = "Newbie Ship";
			ShipDescription.text = "Default ship, fit for a newbie.";
			LockImage.enabled = !unlockedShips[0];
			break;
		case "Ship03a":
			sprite.sprite = ShipSprites[1];
			script.ship = 1;
			script.unlockedShips[1] = unlockedShips[1];
			ShipTitle.text = "Vigilante Ship";
			if (unlockedShips[1] == true){
				ShipDescription.text = "The original Vigilante Ship, you are no stranger to the galaxy. (Start with Double Shot)";
			} else {
				ShipDescription.text = "Unlocks after 10,000 points.";
			}
			LockImage.enabled = !unlockedShips[1];
			break;
		case "Ship04a":
			sprite.sprite = ShipSprites[2];
			script.ship = 2;
			script.unlockedShips[2] = unlockedShips[2];
			ShipTitle.text = "Guardian Ship";
			if (unlockedShips[2] == true){
				ShipDescription.text = "Smaller hit box, fit for a professional. (Start with a Shield)";
			} else {
				ShipDescription.text = "Unlocks after killing the boss at round 10. (Difficulty Medium/Hard)";
			}
			LockImage.enabled = !unlockedShips[2];
			break;
		}
	}
	public void GoBack(){
		// ref back and save
		GameObject pickShipManager = GameObject.Find ("PickShipManager");
		DataManager dataScript = pickShipManager.GetComponent<DataManager> ();
		LoadScene sceneScript = pickShipManager.GetComponent<LoadScene> ();
		// check if you can go back
		GameObject GameControl = GameObject.Find ("GameController");
		GameControl script = GameControl.GetComponent<GameControl> ();
		if (unlockedShips [script.ship]) {
			dataScript.SaveData ();
			sceneScript.SceneToLoad (1);
		} else {
			ShipDescription.text = "CHOOSE AN UNLOCKED SHIP.";
		}
	}
}
