using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour {
	public GameObject lifeManager;
	public int ScoreVal;
	public int AddVal;
	Text text;
	Text TotalScoreText;
	private int increaseLifeValue;
	
	// Use this for awake
	void Awake () {
		text = GetComponent <Text> ();
		ScoreVal = 0;
		AddVal = 0;
		UpdateScore ();
		increaseLifeValue = GetPoints ();
	}

	void Update(){
		// if val is enough then add a life
		if (AddVal >= increaseLifeValue){
			AddVal = AddVal - increaseLifeValue;
			KeepLives lifeScript = lifeManager.GetComponent<KeepLives>();
			lifeScript.AddLife ();
		}
	}
	
	// Update Score
	void UpdateScore () {
		text.text = "Score: " + ScoreVal;
	}
	int GetPoints(){
		GameObject waveManager = GameObject.Find ("WaveManager");
		KeepWave script = waveManager.GetComponent<KeepWave> ();
		int points;
		switch (script.gameDifficulty) {
		case "Easy":
			points = 5000;
			break;
		case "Medium":
			points = 10000;
			break;
		case "Hard":
			points = 15000;
			break;
		default:
			points = 10000;
			break;
		}
		return points;
	}
	public void AddScore(int NewScore){
		// add for new life
		AddVal += NewScore;
		// add for score
		ScoreVal += NewScore;
		UpdateScore ();
	}

	public void Rest_Score (){
		ScoreVal = 0;
		AddVal = 0;
		UpdateScore ();
	}
}
