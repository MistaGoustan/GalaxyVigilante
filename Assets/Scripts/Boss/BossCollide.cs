using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossCollide : MonoBehaviour {
	public GameObject Explosion;
	public GameObject Boss;
	private GameObject healthBar;

	void Start(){
		healthBar = GameObject.Find ("BossHealthBG");
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Big_Asteroid" || other.gameObject.tag == "Medium_Asteroid" || other.gameObject.tag == "Small_Asteroid") {
			GameObject asteroid = other.gameObject;
			AsteroidCollision script = asteroid.GetComponent<AsteroidCollision>();
			script.BossAsteroidCollide ();

		}
		if (other.gameObject.tag == "Shot" || other.gameObject.tag == "LongShot") {
			Destroy (other.gameObject);

			BossHealth script = gameObject.GetComponent<BossHealth> ();

			if (script.currentHealth != 0) {
				script.currentHealth -= 1;
				script.HandleHealth();
				if(script.currentHealth <= 0){
					// reset health
					script.currentHealth = script.maxHealth;
					script.HandleHealth();
					AddToScore ();
					ExplosionSound();
					RemoveBoss ();
					LeaveExplosion ();
					GameObject waveManager = GameObject.Find ("WaveManager");
					KeepWave waveScript = waveManager.GetComponent<KeepWave>();
					waveScript.SpawnBossWave += 5;
					waveScript.bossSpawned = false;
				}
			}
		}else if (other.gameObject.tag == "Ship"){
			ShipCollide script = other.gameObject.GetComponent<ShipCollide>();
			script.ShipCollision ();

		}
	}
	public void RemoveBoss (){
		Destroy (gameObject);
		ToggleHealthBar ();
		SwitchStatus ();
		UnlockShip ();
	}
	void UnlockShip(){
		// unlock 3rd ship
		GameObject waveManager = GameObject.Find ("WaveManager");
		KeepWave script = waveManager.GetComponent<KeepWave> ();
		if (script.gameDifficulty != "Easy") {
			GameObject GameControl = GameObject.Find ("GameController");
			GameControl gameScript = GameControl.GetComponent<GameControl> ();
			if (gameScript.unlockedShips[2] == true){
				Debug.Log ("Ship 3 already unlocked");
			}else if (gameScript.unlockedShips[2] == false){
				Debug.Log ("UNLOCK SHIP 3");
				GameObject canvasManager = GameObject.Find ("CanvasManager");
				ToggleNewShipCanvas NSCS = canvasManager.GetComponent<ToggleNewShipCanvas> ();
				NSCS.newShip = true;

			}
			gameScript.unlockedShips[2] = true;
		}
	}
	void AddToScore(){
		// add to score
		GameObject scoreText = GameObject.Find ("ScoreText");
		KeepScore scoreScript = scoreText.GetComponent<KeepScore>();
		scoreScript.AddScore (GetPoints ());
	}
	void LeaveExplosion(){
		// leave explosion
		Instantiate (Explosion,
		             Explosion.transform.position = new Vector2(Boss.transform.position.x, Boss.transform.position.y),
		             Explosion.transform.rotation);
	}
	void ExplosionSound(){
		// Play Sound
		GameObject bosses = GameObject.Find("Bosses");
		PlaySound SoundScript = bosses.GetComponent<PlaySound>();
		SoundScript.Play ();
	}
	public void SwitchStatus(){
		GameObject gameManager = GameObject.Find ("GameManager");
		GameStatus script = gameManager.GetComponent<GameStatus> ();
		script.ToggleStatus ();
		// toggle spawning asteroids
		GameObject asteroids = GameObject.Find ("Asteroids");
		RandomAsteroid asteroidScript = asteroids.GetComponent<RandomAsteroid>();
		asteroidScript.SpawnAsteroids = !asteroidScript.SpawnAsteroids;
		// toggle boss spawn
	}
	public void ToggleHealthBar(){
		healthBar.SetActive (false);
	}
	int GetPoints(){
		GameObject waveManager = GameObject.Find ("WaveManager");
		KeepWave script = waveManager.GetComponent<KeepWave> ();
		int points;
		switch (script.gameDifficulty) {
		case "Easy":
			points = 2500;
			break;
		case "Medium":
			points = 5000;
			break;
		case "Hard":
			points = 10000;
			break;
		default:
			points = 5000;
			break;
		}
		return points;
	}
}
