using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DifficultyManager : MonoBehaviour {
	public Text difficultyText;
	public Text descriptionText;
	public RectTransform texBoxRect;

	// Use this for initialization
	void Start () {
		LoadDifficulty ();
		LoadText ();
	}
	
	public void RightButton(){
		switch (difficultyText.text) {
		case "Easy":
			difficultyText.text = "Medium";
			texBoxRect.sizeDelta = new Vector2 (180, 60);
			descriptionText.text = "You are a true vigilante. (points x 1.0)";
			SaveDifficulty();
			break;
		case "Medium":
			difficultyText.text = "Hard";
			texBoxRect.sizeDelta = new Vector2 (100, 60);
			descriptionText.text = "Good Luck. (points x 2.0)";
			SaveDifficulty();
			break;
		case "Hard":
			// move over
			difficultyText.text = "Easy";
			texBoxRect.sizeDelta = new Vector2 (160, 60);
			descriptionText.text = "Fit for a Newbie. (points x 0.5)";
			SaveDifficulty();
			break;
		}
	}
	public void LeftButton(){
		switch (difficultyText.text) {
		case "Easy":
			// move over
			difficultyText.text = "Hard";
			texBoxRect.sizeDelta = new Vector2 (100, 60);
			descriptionText.text = "Good Luck. (points x 2.0)";
			SaveDifficulty();
			break;
		case "Medium":
			difficultyText.text = "Easy";
			texBoxRect.sizeDelta = new Vector2 (160, 60);
			descriptionText.text = "Fit for a Newbie. (points x 0.5)";
			SaveDifficulty();
			break;
		case "Hard":
			difficultyText.text = "Medium";
			texBoxRect.sizeDelta = new Vector2 (180, 60);
			descriptionText.text = "You are a true vigilante. (points x 1.0)";
			SaveDifficulty();
			break;
		}
	}
	void LoadText(){
		switch (difficultyText.text) {
		case "Easy":
			// move over
			difficultyText.text = "Easy";
			texBoxRect.sizeDelta = new Vector2 (160, 60);
			descriptionText.text = "Fit for a Newbie. (points x 0.5)";
			break;
		case "Medium":
			difficultyText.text = "Medium";
			texBoxRect.sizeDelta = new Vector2 (180, 60);
			descriptionText.text = "You are a true vigilante. (points x 1.0)";
			break;
		case "Hard":
			difficultyText.text = "Hard";
			texBoxRect.sizeDelta = new Vector2 (100, 60);
			descriptionText.text = "Good Luck. (points x 2.0)";
			break;
		}
	}
	void SaveDifficulty(){
		GameObject GameControl = GameObject.Find ("GameController");
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			// then save the volume
			script.gameDifficulty = difficultyText.text;
		}
	}
	void LoadDifficulty(){
		GameObject GameControl = GameObject.Find ("GameController");
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			// then save the volume
			difficultyText.text = script.gameDifficulty;
		}
	}
}
