using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour {
	public void SaveData(){
		GameObject GameControl = GameObject.Find ("GameController");
		// adjust the music volume
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			script.Save ();
		}
	}
	public void LoadData(){
		GameObject GameControl = GameObject.Find ("GameController");
		// adjust the music volume
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			script.Load ();
		}
	}
	public void ResetData(){
		ResetHighScores ();
		GameObject GameControl = GameObject.Find ("GameController");
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			// reset volume data
			script.SFXVolume = 1;
			script.musicVolume = 1;
			// reset unlocked ships
			script.unlockedShips[0] = true;
			script.unlockedShips[1] = false;
			script.unlockedShips[2] = false;
		}
	}

	void ResetHighScores(){
		GameObject GameControl = GameObject.Find ("GameController");
		// reset scores
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();

			// declaration of array and its length
			int[] scores = new int[5];
			string[] names = new string[5];

			// for each int in array reset it
			for (int i = 0; i <= 4; i++){
				switch (i){
				case 0:
					scores[i] = 10000;
					names[i] = "AAA";
					break;
				case 1:
					scores[i] = 8000;
					names[i] = "BBB";
					break;
				case 2:
					scores[i] = 6000;
					names[i] = "CCC";
					break;
				case 3:
					scores[i] = 4000;
					names[i] = "DDD";
					break;
				case 4:
					scores[i] = 2000;
					names[i] = "EEE";
					break;
				}
			}

			// pass the arrays back
			script.scores = scores;
			script.names = names;
		}
	}
}