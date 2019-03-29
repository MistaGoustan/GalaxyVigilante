using UnityEngine;
using System.Collections;

public class PowerUpCollide : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "Ship") {
			// play the powerup sound
			Sound ();
			// Which power up collided with the player
			switch (gameObject.tag) {
			case "PowerUp01":
				//enable the +1000 text 
				GameObject text = GameObject.Find ("AddPointsText");
				PowerupScoreText textScript = text.GetComponent<PowerupScoreText>();
				textScript.resetText ();
				break;
			case "PowerUp02":
				Power2 ();
				break;
			case "PowerUp03":
				Power3 ();
				break;
			case "PowerUp04":
				Power4 ();
				break;
			}
			AddToScore (GetPowerUpPoints (gameObject.tag));
			// then destroy the powerup
			Destroy (gameObject);
		}
	}
	int GetPowerUpPoints(string powerup){
		GameObject waveManager = GameObject.Find ("WaveManager");
		KeepWave script = waveManager.GetComponent<KeepWave> ();
		int points;
		switch (script.gameDifficulty) {
		case "Easy":
			if (powerup == "PowerUp01"){
				points = 500;
			}else{
				points = 50;
			}
			break;
		case "Medium":
			if (powerup == "PowerUp01"){
				points = 1000;
			}else{
				points = 100;
			}
			break;
		case "Hard":
			if (powerup == "PowerUp01"){
				points = 2000;
			}else{
				points = 200;
			}
			break;
		default:
			if (powerup == "PowerUp01"){
				points = 1000;
			}else{
				points = 100;
			}
			break;
		}
		return points;
	}

	void Sound(){
		GameObject powerups = GameObject.Find ("PowerUps");
		PlaySound soundScript = powerups.GetComponent<PlaySound> ();
		soundScript.Play ();
	}
	// Double Shot
	public void Power2(){
		// find the ship
		GameObject ship = GameObject.FindWithTag("Ship");
		// get the shoot scripts
		ShipFire singleFire = ship.GetComponent<ShipFire> ();
		ShipDoubleShot doubleShot = ship.GetComponent<ShipDoubleShot> ();
		ShipLongShot longShot = ship.GetComponent<ShipLongShot> ();
		// Disable single fire and LongShot
		singleFire.enabled = false;
		longShot.enabled = false;
		// Enable doubleshot
		doubleShot.enabled = true;
	}
	// Shield
	public void Power3(){
		// find the ship
		GameObject ship = GameObject.FindWithTag("Ship");
		// get the script
		ShipShield shieldScript = ship.GetComponent<ShipShield> ();
		shieldScript.SpawnShield = true;
	}
	// Long Shot
	public void Power4(){
		// find the ship
		GameObject ship = GameObject.FindWithTag("Ship");
		// get the shoot scripts
		ShipFire singleFire = ship.GetComponent<ShipFire> ();
		ShipDoubleShot doubleShot = ship.GetComponent<ShipDoubleShot> ();
		ShipLongShot longShot = ship.GetComponent<ShipLongShot> ();
		// Disable single fire and doubleshot
		singleFire.enabled = false;
		doubleShot.enabled = false;
		// Enable longshot
		longShot.enabled = true;
	}
	void AddToScore(int points){
		// add to score
		GameObject scoreText = GameObject.Find ("ScoreText");
		KeepScore scoreScript = scoreText.GetComponent<KeepScore>();
		scoreScript.AddScore (points);
	}
}
