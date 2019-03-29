using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerupScoreText : MonoBehaviour {
	private Text text;
	private float textTime = 0.0f;

	void Start () {
		// get the +500 text then disable it on start
		text = GetComponent<Text>();
		text.enabled = false;
		SetText ();
	}
	
	void Update(){
		// add to the time
		textTime += Time.deltaTime;
		// if time is ready then show text
		if(textTime >= 2f)
		{
			text.enabled = false;
		}
	}

	void SetText(){
		GameObject waveManager = GameObject.Find ("WaveManager");
		KeepWave script = waveManager.GetComponent<KeepWave> ();
		switch (script.gameDifficulty) {
		case "Easy":
			text.text = "+500";
			break;
		case "Medium":
			text.text = "+1000";
			break;
		case "Hard":
			text.text = "+2000";
			break;
		}
	}

	public void resetText(){
		text.enabled = true;
		textTime = 0.0f;
	}
}
