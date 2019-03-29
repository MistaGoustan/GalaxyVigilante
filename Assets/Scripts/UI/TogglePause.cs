using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TogglePause : MonoBehaviour {
	private bool isPause = false;

	void Awake(){
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Pause")) {
			GameObject ship = GameObject.FindWithTag("Ship");
			if (ship != null){
				Toggle_All ();
			}
		}
	}

	public void Toggle_All(){
		// pause game
		if(isPause == false){
			isPause = true;
			Toggle_AsteroidSpawn ();
			Toggle_EnemySpawn ();
			Toggle_EnemyShoot ();
			Toggle_MoveAsteroids ();
			Toggle_MovePowerUps();
			Toggle_Move ();
			Toggle_Shoot();
			Toggle_BGMove ();
			Toggle_Wave ();
			ToggleBoss();
			Time.timeScale = 0;
		}
		// unpause game
		else if (isPause == true){
			isPause = false;
			Toggle_AsteroidSpawn ();
			Toggle_EnemySpawn ();
			Toggle_EnemyShoot ();
			Toggle_MoveAsteroids ();
			Toggle_MovePowerUps();
			Toggle_Move ();
			Toggle_Shoot();
			Toggle_BGMove ();
			Toggle_Wave ();
			ToggleBoss();
			Time.timeScale = 1;
		}
	}
	void ToggleBoss(){
		GameObject boss = GameObject.FindWithTag ("Boss");
		if (boss != null) {
			BossMove moveScript = boss.GetComponent<BossMove> ();
			moveScript.enabled = !moveScript.enabled;
			
			EnemyDoubleShot dShotScript = boss.GetComponent<EnemyDoubleShot> ();
			dShotScript.enabled = !dShotScript.enabled;
			
			EnemyFire[] fireScript = boss.GetComponents<EnemyFire> ();
			fireScript[0].enabled = !fireScript[0].enabled;
			fireScript[1].enabled = !fireScript[1].enabled;
		}
	}
	void Toggle_Wave(){
		GameObject waveManager = GameObject.Find ("WaveManager");
		KeepWave script = waveManager.GetComponent<KeepWave>();
		script.enabled = !script.enabled;
	}
	void Toggle_BGMove (){
		GameObject Stars01 = GameObject.Find("Stars01");
		GameObject Stars02 = GameObject.Find("Stars02");
		StarsMove moveScript01 = Stars01.GetComponent<StarsMove>();
		StarsMove moveScript02 = Stars02.GetComponent<StarsMove>();
		// toggle moveing BGs
		moveScript01.enabled = !moveScript01.enabled;
		moveScript02.enabled = !moveScript02.enabled;
	}
	void Toggle_AsteroidSpawn(){
		GameObject asteroids = GameObject.Find("Asteroids");
		RandomAsteroid asteroidScript = asteroids.GetComponent<RandomAsteroid>();
		// toggle spawning asteroids
		asteroidScript.enabled = !asteroidScript.enabled;
	}
	void Toggle_EnemySpawn(){
		GameObject enemies = GameObject.Find("Enemies");
		RandomEnemies enemyScript = enemies.GetComponent<RandomEnemies>();
		// toggle spawning enemies
		enemyScript.enabled = !enemyScript.enabled;
	}
	void Toggle_Move(){
		// var so player cant move when button held down then paused
		GameObject ship = GameObject.FindWithTag("Ship");
		if (ship != null) {
			ShipMove moveScript = ship.GetComponent<ShipMove>();
			moveScript.canMove = !moveScript.canMove;
		}
	}
	void Toggle_Shoot(){
		// var so player cant shoot when paused
		GameObject ship = GameObject.FindWithTag("Ship");
		if (ship != null) {
			// get scripts for each type of shot
			ShipFire shootScript = ship.GetComponent<ShipFire>();
			ShipDoubleShot doubleScript = ship.GetComponent<ShipDoubleShot>();
			ShipLongShot longScript = ship.GetComponent<ShipLongShot>();
			// then toggle them
			if (shootScript.ToggleShot == true && doubleScript.ToggleShot == true && longScript.ToggleShot == true) {
				shootScript.ToggleShot = false;
				doubleScript.ToggleShot = false;
				longScript.ToggleShot = false;
			}
			else if(shootScript.ToggleShot == false && doubleScript.ToggleShot == false && longScript.ToggleShot == false){
				shootScript.ToggleShot = true;
				doubleScript.ToggleShot = true;
				longScript.ToggleShot = true;
			}
		}
	}
	void Toggle_EnemyShoot(){
		// store all current Enemies in a variable
		GameObject[] Enemies01 = GameObject.FindGameObjectsWithTag("Enemy01");
		GameObject[] Enemies02 = GameObject.FindGameObjectsWithTag("Enemy02");
		GameObject[] Enemies03 = GameObject.FindGameObjectsWithTag("Enemy03");
		
		// make a variable that can hold all the scripts 
		EnemyFire[] FireScripts01 = new EnemyFire[Enemies01.Length];
		EnemyDoubleShot[] FireScripts02 = new EnemyDoubleShot[Enemies02.Length];
		EnemyFire[] FireScripts03 = new EnemyFire[Enemies03.Length];
		
		// Enemy01 Toggle
		for(int i = 0; i < Enemies01.Length; i++){
			// put each script in the variable that was just made
			FireScripts01[i] = Enemies01[i].GetComponent<EnemyFire> ();
			// then enable or disable the script
			FireScripts01[i].enabled = !FireScripts01[i].enabled;
		}
		// Enemy02 Toggle
		for(int i = 0; i < Enemies02.Length; i++){
			// put each script in the variable that was just made
			FireScripts02[i] = Enemies02[i].GetComponent<EnemyDoubleShot> ();
			// then enable or disable the script
			FireScripts02[i].enabled = !FireScripts02[i].enabled;
		}
		// Enemy03 Toggle
		for(int i = 0; i < Enemies03.Length; i++){
			// put each script in the variable that was just made
			FireScripts03[i] = Enemies03[i].GetComponent<EnemyFire> ();
			// then enable or disable the script
			FireScripts03[i].enabled = !FireScripts03[i].enabled;
		}
	}
	void Toggle_MovePowerUps(){
		//gameobjects
		GameObject[] PowerUps01 = GameObject.FindGameObjectsWithTag("PowerUp01");
		GameObject[] PowerUps02 = GameObject.FindGameObjectsWithTag("PowerUp02");
		GameObject[] PowerUps03 = GameObject.FindGameObjectsWithTag("PowerUp03");
		GameObject[] PowerUps04 = GameObject.FindGameObjectsWithTag("PowerUp04");
		//scripts
		MovePowerUp[] PowerUp01Scripts = new MovePowerUp[PowerUps01.Length];
		MovePowerUp[] PowerUp02Scripts = new MovePowerUp[PowerUps02.Length];
		MovePowerUp[] PowerUp03Scripts = new MovePowerUp[PowerUps03.Length];
		MovePowerUp[] PowerUp04Scripts = new MovePowerUp[PowerUps04.Length];
		// Toggle there movement
		for(int i = 0; i < PowerUps01.Length; i++){
			// put each script in the variable that was just made
			PowerUp01Scripts[i] = PowerUps01[i].GetComponent<MovePowerUp> ();
			// then enable or disable the script
			PowerUp01Scripts[i].enabled = !PowerUp01Scripts[i].enabled;
		}
		for(int i = 0; i < PowerUps02.Length; i++){
			// put each script in the variable that was just made
			PowerUp02Scripts[i] = PowerUps02[i].GetComponent<MovePowerUp> ();
			// then enable or disable the script
			PowerUp02Scripts[i].enabled = !PowerUp02Scripts[i].enabled;
		}
		for(int i = 0; i < PowerUps03.Length; i++){
			// put each script in the variable that was just made
			PowerUp03Scripts[i] = PowerUps03[i].GetComponent<MovePowerUp> ();
			// then enable or disable the script
			PowerUp03Scripts[i].enabled = !PowerUp03Scripts[i].enabled;
		}
		for(int i = 0; i < PowerUps04.Length; i++){
			// put each script in the variable that was just made
			PowerUp04Scripts[i] = PowerUps04[i].GetComponent<MovePowerUp> ();
			// then enable or disable the script
			PowerUp04Scripts[i].enabled = !PowerUp04Scripts[i].enabled;
		}
	}
	void Toggle_MoveAsteroids(){
		// SMALL ASTEROID
		// store all current asteroids in a variable
		GameObject[] Small_Asteroids = GameObject.FindGameObjectsWithTag("Small_Asteroid");
		GameObject[] Medium_Asteroids = GameObject.FindGameObjectsWithTag("Medium_Asteroid");
		GameObject[] Big_Asteroids = GameObject.FindGameObjectsWithTag("Big_Asteroid");
		
		// make a variable that can hold all the scripts 
		MoveAsteroid[] Small_AsteroidScripts = new MoveAsteroid[Small_Asteroids.Length];
		MoveAsteroid[] Medium_AsteroidScripts = new MoveAsteroid[Medium_Asteroids.Length];
		MoveAsteroid[] Big_AsteroidScripts = new MoveAsteroid[Big_Asteroids.Length];
		
		// Small Toggle
		for(int i = 0; i < Small_Asteroids.Length; i++){
			// put each script in the variable that was just made
			Small_AsteroidScripts[i] = Small_Asteroids[i].GetComponent<MoveAsteroid> ();
			// then enable or disable the script
			Small_AsteroidScripts[i].enabled = !Small_AsteroidScripts[i].enabled;
		}
		// Medium Toggle
		for(int i = 0; i < Medium_Asteroids.Length; i++){
			// put each script in the variable that was just made
			Medium_AsteroidScripts[i] = Medium_Asteroids[i].GetComponent<MoveAsteroid> ();
			// then enable or disable the script
			Medium_AsteroidScripts[i].enabled = !Medium_AsteroidScripts[i].enabled;
		}
		// Big Toggle
		for(int i = 0; i < Big_Asteroids.Length; i++){
			// put each script in the variable that was just made
			Big_AsteroidScripts[i] = Big_Asteroids[i].GetComponent<MoveAsteroid> ();
			// then enable or disable the script
			Big_AsteroidScripts[i].enabled = !Big_AsteroidScripts[i].enabled;
		}
	}
	
}
