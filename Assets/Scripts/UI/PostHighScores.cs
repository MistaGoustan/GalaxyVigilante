using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PostHighScores : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject gameControl = GameObject.Find ("GameController");
		if (gameControl != null && Application.loadedLevelName == "HighScores") {
			PostScores ();
		}
	}
	
	public void PostScores(){
		// make object and text arrays
		GameObject[] scoreTexts = new GameObject[5];
		Text[] texts = new Text[5];
		// get saved data
		GameObject gameControl = GameObject.Find ("GameController");
		GameControl script = gameControl.GetComponent<GameControl> ();
		// for each one post the score
		if (gameControl != null && script.scores.Length != 0 && script.names.Length != 0) {
			for (int i = 0; i <= 4; i++) {
				switch (i) {
				case 0:
					scoreTexts [i] = GameObject.Find ("Score01");
					texts [i] = scoreTexts [i].GetComponent<Text> ();
					texts [i].text = (1 + ") " + script.names [i] + " - " + script.scores [i]);
					break;
				case 1:
					scoreTexts [i] = GameObject.Find ("Score02");
					texts [i] = scoreTexts [i].GetComponent<Text> ();
					texts [i].text = (2 + ") " + script.names [i] + " - " + script.scores [i]);
					break;
				case 2:
					scoreTexts [i] = GameObject.Find ("Score03");
					texts [i] = scoreTexts [i].GetComponent<Text> ();
					texts [i].text = (3 + ") " + script.names [i] + " - " + script.scores [i]);
					break;
				case 3:
					scoreTexts [i] = GameObject.Find ("Score04");
					texts [i] = scoreTexts [i].GetComponent<Text> ();
					texts [i].text = (4 + ") " + script.names [i] + " - " + script.scores [i]);
					break;
				case 4:
					scoreTexts [i] = GameObject.Find ("Score05");
					texts [i] = scoreTexts [i].GetComponent<Text> ();
					texts [i].text = (5 + ") " + script.names [i] + " - " + script.scores [i]);
					break;
				}
			}
		}
	}
}
