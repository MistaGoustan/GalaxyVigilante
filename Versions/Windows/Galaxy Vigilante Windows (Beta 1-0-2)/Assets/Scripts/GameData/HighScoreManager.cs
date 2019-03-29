using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HighScoreManager : MonoBehaviour {
	//detect highscore vars
	public int Rank;
	public bool highScore = false;
	private int totalScore;
	//input field vars
	public InputField inputField;
	private string nameText = "";
	private int stringLength = 0;
	// button
	public Button enterButton;
	//
	public GameObject scoreText;
	public GameObject canvasManager;
	public GameObject highScoreText;
	public GameObject totalScoreText;

	// start the button disabled
	void Start(){
		enterButton.interactable = false;
	}

	public void PostHighScore(){
		// get saved data
		GameObject gameControl = GameObject.Find ("GameController");
		GameControl gameScript = gameControl.GetComponent<GameControl> ();
		// get the rank the adjust the scores and names in the save data
		switch (Rank) {
		case 1:
			for (int i = 4; i >= 0; i--) {
				if (i != 0){
					// move the rank down
					gameScript.names[i] = gameScript.names[i-1];
					gameScript.scores[i] = gameScript.scores[i-1];
				}else{
					gameScript.names[i] = nameText;
					gameScript.scores[i] = totalScore;
				}
			}
			break;
		case 2:
			for (int i = 4; i >= 1; i--) {
				if (i != 1){
					// move the rank down
					gameScript.names[i] = gameScript.names[i-1];
					gameScript.scores[i] = gameScript.scores[i-1];
				}else{
					gameScript.names[i] = nameText;
					gameScript.scores[i] = totalScore;
				}
			}
			break;
		case 3:
			for (int i = 4; i >= 2; i--) {
				if (i != 2){
					// move the rank down
					gameScript.names[i] = gameScript.names[i-1];
					gameScript.scores[i] = gameScript.scores[i-1];
				}else{
					gameScript.names[i] = nameText;
					gameScript.scores[i] = totalScore;
				}
			}
			break;
		case 4:
			// move the rank down
			gameScript.names[4] = gameScript.names[3];
			gameScript.scores[4] = gameScript.scores[3];
			//then fill the place
			gameScript.names[3] = nameText;
			gameScript.scores[3] = totalScore;
			break;
		case 5:
			gameScript.names[4] = nameText;
			gameScript.scores[4] = totalScore;
			break;
		}
	}

	public void GetName(){
		switch (stringLength) {
		case 1:
			nameText = (nameText + "  ");
			stringLength = nameText.Length;
			break;
		case 2:
			nameText = (nameText + " ");
			stringLength = nameText.Length;
			break;
		}
	}

	public void EditName(){
		// uppercase the name
		nameText = inputField.text;
		nameText = nameText.ToUpper ();
		inputField.text = nameText;

		stringLength = nameText.Length;
		// if string length is more then 0 then enable button
		if (stringLength > 0) {
			enterButton.interactable = true;
		} else {
			enterButton.interactable = false;
		}
	}
	public void GetRank(){
		// get saved data
		GameObject gameControl = GameObject.Find ("GameController");
		GameControl gameScript = gameControl.GetComponent<GameControl> ();
		// get score value
		KeepScore scoreScript = scoreText.GetComponent<KeepScore>();

		// for each one post the score
		for (int i = 0; i <= 4; i++) {
			if (highScore == false){
				if (gameScript.scores[i] < scoreScript.ScoreVal){
					Rank = i + 1;
					highScore = true;
				}
			}
		}
	}
	public void EnableCanvas(){
		GetRank ();
		//new ship canvas
		GameObject canvasManager = GameObject.Find ("CanvasManager");
		ToggleNewShipCanvas NSCS = canvasManager.GetComponent<ToggleNewShipCanvas> ();

		if (highScore == true) {
			// toggle Highscore canvas if the get rank showed it can
			ToggleHighScoreCanvas toggleHS = canvasManager.GetComponent<ToggleHighScoreCanvas> ();
			toggleHS.Toggle ();
			TotalScore ();
			// display the rank and reset the values
			DisplayRank ();
			highScore = false;
		}else {
			// no new highscore then check for new ship if not just gameover canvas
			if (NSCS.newShip == true){
				Debug.Log ("TOGGLE NSCS");
				NSCS.Toggle();
				NSCS.newShip = false;
			}else{
				//if not then just toggle the gameover canvas
				ToggleGameOverCanvas toggleGO = canvasManager.GetComponent<ToggleGameOverCanvas>();
				toggleGO.Toggle();
			}
		}
	}
	void DisplayRank(){
		// get the text
		Text text = highScoreText.GetComponent<Text>();

		switch (Rank) {
		case 1:
			text.text = ("High Score! - 1st Place");
			break;
		case 2:
			text.text = ("High Score! - 2nd Place");
			break;
		case 3:
			text.text = ("High Score! - 3rd Place");
			break;
		case 4:
			text.text = ("High Score! - 4th Place");
			break;
		case 5:
			text.text = ("High Score! - 5th Place");
			break;
		}
	}
	public void TotalScore(){
		// get the text object
		Text text = totalScoreText.GetComponent<Text> ();
		// get the players end score
		GameObject scoreText = GameObject.Find ("ScoreText");
		KeepScore script = scoreText.GetComponent<KeepScore> ();
		totalScore = script.ScoreVal;
		text.text = "Total Score: " + script.ScoreVal;
		// unlock ship 2
		if (script.ScoreVal >= 10000) {
			GameObject GameControl = GameObject.Find ("GameController");
			GameControl gameScript = GameControl.GetComponent<GameControl> ();
			if (gameScript.unlockedShips[1] == true){
				Debug.Log ("Ship 2 already unlocked");
			}else if (gameScript.unlockedShips[1] == false){
				GameObject canvasManager = GameObject.Find ("CanvasManager");
				ToggleNewShipCanvas NSCS = canvasManager.GetComponent<ToggleNewShipCanvas> ();
				NSCS.newShip = true;
				Debug.Log ("UNLOCK SHIP 2");
			}
			gameScript.unlockedShips[1] = true;
		}
	}
}
