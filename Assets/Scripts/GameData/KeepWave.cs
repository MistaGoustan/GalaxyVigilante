using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeepWave : MonoBehaviour {
	// referenced gameobjects
	public GameObject asteroids;
	public GameObject enemies;
	public GameObject waveText;
	public GameObject gameManager;
	private Text text;
	// time count
	public float nextTime;
	public float gameTime;
	// boss
	public int SpawnBossWave;
	[HideInInspector] public bool spawnBoss = false;
	[HideInInspector] public bool bossSpawned = false;
	// enemy kills
	public int waveKillCount;
	public int minKillCount = 2;
	// wave
	public int waveVal;
	private bool startWave;
	// difficulty
	public string gameDifficulty;
	private int difficultyValue;


	void Start () {
		minKillCount = 3 + (waveVal * 2);
		nextTime = 30 + (waveVal * 2);
		text = waveText.GetComponent <Text> ();
		text.enabled = true;
		startWave = false;
		UpdateWave ();
		SetDifficultyValue ();
	}

	void Update(){
		if (spawnBoss == false) {
			GameStatus ();
			Counter ();
		} else if (spawnBoss == true && bossSpawned == false) {
			SwitchStatus();
			GameObject bosses = GameObject.Find ("Bosses");
			SpawnBoss script = bosses.GetComponent<SpawnBoss>();
			script.SpawnTheBoss ();
			bossSpawned = true;
		}
	}
	void SetShootSpawn(){
		GameObject enemies = GameObject.Find ("Enemies");
		RandomEnemies script = enemies.GetComponent<RandomEnemies> ();
		GameObject bosses = GameObject.Find ("Bosses");
		SpawnBoss bossScript = bosses.GetComponent<SpawnBoss> ();
		switch (gameDifficulty) {
		case "Easy":
			//Enemies
			script.Enemy01MinShootRange = 1.8f;
			script.Enemy01MaxShootRange = 2.5f;
			script.Enemy02MinShootRange = 2.5f;
			script.Enemy02MaxShootRange = 3.5f;
			script.Enemy03MinShootRange = 2.25f;
			script.Enemy03MaxShootRange = 3f;
			//Boss
			bossScript.minShootRange = 1.25f;
			bossScript.maxShootRange = 2f;
			bossScript.minDoubleShootRange = 0.75f;
			bossScript.maxDoubleShootRange = 2.25f;
			break;
		case "Medium":
			//Enemies
			script.Enemy01MinShootRange = 0.9f;//1.2
			script.Enemy01MaxShootRange = 2.5f;
			script.Enemy02MinShootRange = 1.75f;
			script.Enemy02MaxShootRange = 3.5f;
			script.Enemy03MinShootRange = 1.25f;//.5
			script.Enemy03MaxShootRange = 3f;
			//Boss
			bossScript.minShootRange = 0.75f;
			bossScript.maxShootRange = 1.5f;
			bossScript.minDoubleShootRange = 0.5f;
			bossScript.maxDoubleShootRange = 2f;
			break;
		case "Hard":
			//Enemies
			script.Enemy01MinShootRange = 0.6f;
			script.Enemy01MaxShootRange = 2.5f;
			script.Enemy02MinShootRange = 1.25f;
			script.Enemy02MaxShootRange = 3.5f;
			script.Enemy03MinShootRange = 0.75f;
			script.Enemy03MaxShootRange = 3f;
			//Boss
			bossScript.minShootRange = 0.5f;
			bossScript.maxShootRange = 1.25f;
			bossScript.minDoubleShootRange = 0.25f;
			bossScript.maxDoubleShootRange = 1.5f;
			break;
		}
	}
	void SetDifficultyValue(){
		RandomEnemies eScript = enemies.GetComponent<RandomEnemies> ();
		RandomAsteroid rScript = asteroids.GetComponent<RandomAsteroid> ();
		SetShootSpawn ();
		switch (gameDifficulty) {
		case "Easy":
			difficultyValue = 1;
			// Enemies
			eScript.minSpawnTime = 2.5f;
			eScript.maxSpawnTime = 3.5f;
			// Asteroids
			rScript.minSpawnTime = 1.5f;
			rScript.maxSpawnTime = 2.0f;
			break;
		case "Medium":
			difficultyValue = 2;
			// Enemies
			eScript.minSpawnTime = 1.5f;
			eScript.maxSpawnTime = 2.5f;
			// Asteroids
			rScript.minSpawnTime = 1f;
			rScript.maxSpawnTime = 1.5f;
			break;
		case "Hard":
			difficultyValue = 3;
			// Enemies
			eScript.minSpawnTime = 1f;
			eScript.maxSpawnTime = 1.5f;
			// Asteroids
			rScript.minSpawnTime = 0.75f;
			rScript.maxSpawnTime = 1.25f;
			break;
		}
	}
	void AddWave(){
		waveVal += 1;
		IncreaseDifficulty ();
		// spawn boss if level 10
		if (waveVal == SpawnBossWave) {
			spawnBoss = true;
		} else if (waveVal != SpawnBossWave) { // let the text update
			UpdateWave ();
		}

	}

	void IncreaseDifficulty(){
		minKillCount = 3 + (waveVal * difficultyValue);
		nextTime = 30 + (waveVal * difficultyValue);
		// increment enemy shooting
		IncreaseEnemyShoot ();
		IncreaseEnemySpawn ();
		IncreaseAsteroidSpawn ();
	}
	void IncreaseAsteroidSpawn(){
		RandomAsteroid rScript = asteroids.GetComponent<RandomAsteroid> ();
		// for Min spawn Easy and Medium over .05
		if (rScript.minSpawnTime > 0.5f && gameDifficulty != "Hard") {
			rScript.minSpawnTime -= .025f;
		}// for Hard over .25 
		else if (rScript.minSpawnTime > 0.25f && gameDifficulty == "Hard") {
			rScript.minSpawnTime -= .025f;
		}
		// for Max spawn Easy and Medium over .05
		if (rScript.maxSpawnTime > 0.5f && gameDifficulty != "Hard") {
			rScript.maxSpawnTime -= .025f;
		}// for Hard over .25 
		else if (rScript.maxSpawnTime > 0.25f && gameDifficulty == "Hard") {
			rScript.maxSpawnTime -= .025f;
		}
	}
	void IncreaseEnemySpawn(){
		// increment spawn range
		RandomEnemies eScript = enemies.GetComponent<RandomEnemies> ();
		// For Easy and Medium min spawn range over 1
		if (eScript.minSpawnTime > 1f && gameDifficulty != "Hard") {
			eScript.minSpawnTime -= 0.05f;
		}// for Easy and Medium
		else if (eScript.minSpawnTime > 0.75f && gameDifficulty != "Hard") {
			eScript.minSpawnTime -= 0.025f;
		}// for Hard 
		else if (eScript.minSpawnTime > 0.5f && gameDifficulty == "Hard") {
			eScript.minSpawnTime -= 0.025f;
		}
		// For All max spawn range over 1
		if (eScript.maxSpawnTime > 1f) {
			eScript.maxSpawnTime -= 0.05f;
		}// for Easy and Medium
		else if (eScript.maxSpawnTime > 0.75f && gameDifficulty != "Hard") {
			eScript.maxSpawnTime -= 0.025f;
		}// for Hard 
		else if (eScript.maxSpawnTime > 0.5f && gameDifficulty == "Hard") {
			eScript.maxSpawnTime -= 0.025f;
		}

	}
	void IncreaseEnemyShoot(){
		GameObject enemies = GameObject.Find ("Enemies");
		RandomEnemies shootScript = enemies.GetComponent<RandomEnemies> ();
		//ENEMY01
		//min range
		if (shootScript.Enemy01MinShootRange  > 0.1f) {
			shootScript.Enemy01MinShootRange -= 0.05f;
		} //max range
		if (shootScript.Enemy01MaxShootRange > 0.5) {
			shootScript.Enemy01MaxShootRange -= 0.1f;
		}
		//ENEMY02
		//min range
		if (shootScript.Enemy02MinShootRange  > 0.25f) {
			shootScript.Enemy02MinShootRange -= 0.1f;
		} //max range
		if (shootScript.Enemy02MaxShootRange > 0.5) {
			shootScript.Enemy02MinShootRange -= 0.1f;
		}
		//ENEMY03
		//min range
		if (shootScript.Enemy03MinShootRange  > 0.25f) {
			shootScript.Enemy03MinShootRange -= 0.05f;
		} //max range
		if (shootScript.Enemy03MaxShootRange > 0.5) {
			shootScript.Enemy03MinShootRange -= 0.1f;
		}
	}

	void Counter(){
		// count time
		gameTime += Time.deltaTime;
		// disable the text after a bit
		if (gameTime >= 2.5f) {
			startWave = true;
			text.enabled = false;
		} 

		if (gameTime >= nextTime && waveKillCount >= minKillCount) {
			startWave = false;
			CheckForEnemies ();
		}
	}

	void CheckForEnemies(){
		if (startWave == false) {
			GameObject enemies01 = GameObject.FindGameObjectWithTag("Enemy01");
			GameObject enemies02 = GameObject.FindGameObjectWithTag("Enemy02");
			GameObject enemies03 = GameObject.FindGameObjectWithTag("Enemy03");
			
			if(enemies01 == null &&
			   enemies02 == null &&
			   enemies03 == null ){
				waveKillCount = 0;
				AddWave ();
			}
		}
	}

	void GameStatus(){
		// Game Status
		// if the wave is ready or not to spawn then eanable or disable
		if (startWave == true) {
			//enable enemy spawn
			RandomEnemies enemyScript = enemies.GetComponent<RandomEnemies>();
			enemyScript.SpawnEnemies = true;
		} else if (startWave == false) {
			//disable enemy spawn
			RandomEnemies enemyScript = enemies.GetComponent<RandomEnemies>();
			enemyScript.SpawnEnemies = false;
		} 
	}

	// Update wave
	public void UpdateWave () {
		gameTime = 0f;
		text.text = "Wave: " + waveVal;
		text.enabled = true;
	}
	
	public void ResetWave(){
		SetDifficultyValue ();
		startWave = false;
		GameStatus ();
		waveVal = 1;
		gameTime = 0;
		text.enabled = true;
	}

	void SwitchStatus(){
		GameStatus script = gameManager.GetComponent<GameStatus> ();
		script.ToggleStatus ();
		// toggle spawning asteroids
		RandomAsteroid asteroidScript = asteroids.GetComponent<RandomAsteroid>();
		asteroidScript.SpawnAsteroids = !asteroidScript.SpawnAsteroids;
	}
}
