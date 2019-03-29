using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {
	private Vector2 powerCord;
	public GameObject Explosion;
	public GameObject Enemy;

	void OnCollisionEnter2D(Collision2D other){
		//check for shot collision
		if (other.gameObject.tag == "Shot" || other.gameObject.tag == "LongShot") {
			AddToWaveKillCount ();
			AddToScore ();
			ExplosionSound();
			// destroy enemy
			Destroy (gameObject);
			LeaveExplosion ();
			// get cords before destroying for powerup
			powerCord = gameObject.transform.position;
			//based on what enemy decide what power up
			PowerUp ();
		} 
	}
	void AddToWaveKillCount(){
		GameObject waveManager = GameObject.Find ("WaveManager");
		KeepWave script = waveManager.GetComponent<KeepWave> ();
		script.waveKillCount += 1;
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
			points = 25;
			break;
		case "Medium":
			points = 50;
			break;
		case "Hard":
			points = 100;
			break;
		default:
			points = 50;
			break;
		}
		return points;
	}
	void LeaveExplosion(){
		// leave explosion
		Instantiate (Explosion,
		             Explosion.transform.position = new Vector2(Enemy.transform.position.x, Enemy.transform.position.y),
		             Explosion.transform.rotation);
	}
	void ExplosionSound(){
		// Play Sound
		GameObject Enemies = GameObject.Find("Enemies");
		PlaySound SoundScript = Enemies.GetComponent<PlaySound>();
		SoundScript.Play ();
	}
	void PowerUp (){
		switch (gameObject.tag) {
		case "Enemy01":
			//longshot
			//spawn powerup
			GameObject powerup04 = GameObject.Find ("PowerUps");
			RandomPowerUp powerScript04 = powerup04.GetComponent<RandomPowerUp>();
			powerScript04.SpawnPowerUp (powerCord, 4);
			break;
		case "Enemy02":
			//shield
			//spawn powerup
			GameObject powerup02 = GameObject.Find ("PowerUps");
			RandomPowerUp powerScript02 = powerup02.GetComponent<RandomPowerUp>();
			powerScript02.SpawnPowerUp (powerCord, 2);
			break;
		case "Enemy03":
			//double shot
			//spawn powerup
			GameObject powerup03 = GameObject.Find ("PowerUps");
			RandomPowerUp powerScript03 = powerup03.GetComponent<RandomPowerUp>();
			powerScript03.SpawnPowerUp (powerCord, 3);
			break;
		}
	}
}
