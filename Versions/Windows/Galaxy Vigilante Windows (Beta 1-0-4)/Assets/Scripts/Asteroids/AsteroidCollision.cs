using UnityEngine;
using System.Collections;

public class AsteroidCollision : MonoBehaviour {
	public GameObject Medium_Asteroid;
	public GameObject Small_Asteroid;
	private Vector2 powerCord;

	void OnCollisionEnter2D(Collision2D other){
		if (gameObject != null) {
			//check for Ships shot collision
			if (other.gameObject.tag == "Shot" || other.gameObject.tag == "LongShot") {
				AddToScore ();
				ExplosionSound();
				// get cords before destroying for powerup
				powerCord = gameObject.transform.position;
				// destroy asteroid
				Destroy (gameObject);
				
			}// destroy asteroid if enemy shoots it
			else if(other.gameObject.tag == "EnemyShot" || other.gameObject.tag == "EnemyLongShot"){
				Destroy (gameObject);
			}
			// replace it if player or enemy shoots it
			if (gameObject.tag == "Big_Asteroid" && other.gameObject.tag == "Shot" ||
			    gameObject.tag == "Big_Asteroid" && other.gameObject.tag == "EnemyShot") {
				// replace with medium
				Instantiate (Medium_Asteroid, gameObject.transform.position, gameObject.transform.rotation);
			} // replace it if player or enemy shoots it
			else if (gameObject.tag == "Medium_Asteroid" && other.gameObject.tag == "Shot" ||
			         gameObject.tag == "Medium_Asteroid" && other.gameObject.tag == "EnemyShot") {
				// replace with small
				Instantiate (Small_Asteroid, gameObject.transform.position, gameObject.transform.rotation);
			} // replace it only if player shoots it
			else if (gameObject.tag == "Small_Asteroid" && other.gameObject.tag == "Shot" || other.gameObject.tag == "LongShot") {
				PowerUp ();
			}
		}
	}
	public void BossAsteroidCollide(){
		ExplosionSound();
		Destroy (gameObject);
	}
	void PowerUp(){
		//spawn powerup
		GameObject powerup = GameObject.Find ("PowerUps");
		RandomPowerUp powerScript = powerup.GetComponent<RandomPowerUp>();
		powerScript.SpawnPowerUp (powerCord, 1);
	}
	void AddToScore(){
		// add to score
		GameObject scoreText = GameObject.Find ("ScoreText");
		KeepScore scoreScript = scoreText.GetComponent<KeepScore>();
		scoreScript.AddScore (GetPoints());
	}
	int GetPoints(){
		GameObject waveManager = GameObject.Find ("WaveManager");
		KeepWave script = waveManager.GetComponent<KeepWave> ();
		int points;
		switch (script.gameDifficulty) {
		case "Easy":
			points = 10;
			break;
		case "Medium":
			points = 20;
			break;
		case "Hard":
			points = 40;
			break;
		default:
			points = 20;
			break;
		}
		return points;
	}
	void ExplosionSound(){
		// Play Sound
		GameObject Asteroids = GameObject.Find("Asteroids");
		PlaySound SoundScript = Asteroids.GetComponent<PlaySound>();
		SoundScript.Play();
	}
}
