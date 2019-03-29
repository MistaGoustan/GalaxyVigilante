using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {
	
	void Update(){
		GameObject ship = GameObject.FindWithTag("Ship");
		// short cut key to restart the game
		if (Input.GetKeyDown (KeyCode.R) && ship == null) {
			// toggle off the restart canvas
			GameObject canvasManager = GameObject.Find ("CanvasManager");
			ToggleGameOverCanvas canvasScript = canvasManager.GetComponent<ToggleGameOverCanvas>();
			canvasScript.Toggle ();
			// then restart the game
			Restart ();
		}
	}
	public void Restart(){
		RemoveObjects ();
		ResetScore ();
		ResetPowerUps ();
		SpawnShip ();
		ResetLives ();
		StartWaves ();
		ResetBoss ();
	}
	void ResetBoss(){
		GameObject boss = GameObject.FindWithTag ("Boss");
		if (boss != null){
			// reset boss health
			BossHealth healthScript = boss.GetComponent<BossHealth>();
			healthScript.currentHealth = healthScript.maxHealth;
			healthScript.HandleHealth();
			BossCollide script = boss.GetComponent<BossCollide>();
			script.RemoveBoss ();
			script.SwitchStatus ();
		}
	}
	void StartWaves(){
		GameObject waveManager = GameObject.Find ("WaveManager");
		KeepWave script = waveManager.GetComponent<KeepWave>();
		script.enabled = true;
		script.bossSpawned = false;
		script.UpdateWave ();

		GameObject boss = GameObject.Find ("Bosses");
		SpawnBoss bossScript = boss.GetComponent<SpawnBoss> ();
		bossScript.enabled = false;
	}
	void ResetLives (){
		// Reset The lives
		GameObject lifeManager = GameObject.Find ("LifeManager");
		KeepLives lifeScript = lifeManager.GetComponent<KeepLives>();
		lifeScript.ResetLives ();
	}
	void SpawnShip(){
		// spawn ship
		GameObject player = GameObject.Find("Player");
		SpawnShip spawnScript = player.GetComponent<SpawnShip>();
		spawnScript.firstSpawn = true;
		spawnScript.Spawn ();
	}
	void RemoveObjects(){
		// remove Shots
		GameObject manager = GameObject.Find("GameManager");
		DestroyAllObjects destroyScript = manager.GetComponent<DestroyAllObjects>();
		destroyScript.Destroy_All = true;
	}
	void ResetScore(){
		// reset the score
		GameObject scoreText = GameObject.Find ("ScoreText");
		KeepScore scoreScript = scoreText.GetComponent<KeepScore>();
		scoreScript.Rest_Score ();
	}
	void ResetPowerUps(){
		//restart powerup spawn
		GameObject powerup = GameObject.Find ("PowerUps");
		RandomPowerUp powerScript = powerup.GetComponent<RandomPowerUp>();
		powerScript.WillSpawn = false;
	}
}
