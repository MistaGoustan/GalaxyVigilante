using UnityEngine;
using System.Collections;

public class SetResolution : MonoBehaviour {
	private float screenWidth;
	private float screenHeight;
	private float screenRatio;
	public GameObject[] ships;
	public GameObject boss;
	// Use this for initialization
	void Awake () {
		// store resolution
		screenWidth = Screen.currentResolution.width;
		screenHeight = Screen.currentResolution.height; 
		// store ratio
//		screenRatio = (1024f/768f); // 4:3
//		screenRatio = (1280f/1024f); // 5:4
//		screenRatio = (1280f/854f); // 3:2
//		screenRatio = (1280f / 800f); // 16:10
		screenRatio = (screenWidth / screenHeight);
		screenRatio = Mathf.Round(screenRatio * 100f) / 100f;
		Debug.Log (screenRatio);
		SetScreen ();
	}
	void SetScreen(){
		string convertedRatio;
		convertedRatio = screenRatio.ToString ("0.00");
		switch (convertedRatio) {
			// 16:9
		case "1.78":
			if (Application.loadedLevelName == "Game") {
				gameObject.transform.localScale = new Vector3(24.9f, 14f, 1f); // checked
				SetPlayerSpawn (new Vector2(-11f,0f)); // checked
				SetLifeSpawn (-12.5f); // checked
				SetShipBoundary(11.8f); // checked
				SetAsteroidSpawn(14f); // checked
				SetEnemySpawn(13f); // checked
				SetBossSpawn(9f); // checked
			}else{
				SetSun(-4f); // checked
			}
			break;
			// 16:10
		case "1.60":
			if (Application.loadedLevelName == "Game") {
				gameObject.transform.localScale = new Vector3(22.5f, 14f, 1f);
				SetPlayerSpawn (new Vector2(-9.75f,0f)); // checked
				SetLifeSpawn (-11.25f); // checked
				SetShipBoundary(10.55f); // checked
				SetAsteroidSpawn(12.75f); // checked
				SetEnemySpawn(11.75f); // checked
				SetBossSpawn(8.75f); // checked
			}else{
				SetSun(-3.5f); // checked
			}
			break;
			// 3:2
		case "1.50":
			if (Application.loadedLevelName == "Game") {
				gameObject.transform.localScale = new Vector3(21f, 14f, 1f);
				SetPlayerSpawn (new Vector2(-9f,0f)); // checked
				SetLifeSpawn (-10.5f); // checked
				SetShipBoundary(9.8f); // checked
				SetAsteroidSpawn(12f); // checked
				SetEnemySpawn(11f); // checked
				SetBossSpawn(8.5f); // checked
			}else{
				SetSun(-3.5f); // checked
			}
			break;
			// 4:3
		case "1.33":
			if (Application.loadedLevelName == "Game") {
				gameObject.transform.localScale = new Vector3(18.5f, 14f, 1f); // checked
				SetPlayerSpawn (new Vector2(-7.75f,0f)); // checked
				SetLifeSpawn (-9.25f); // checked
				SetShipBoundary(8.55f); // checked
				SetAsteroidSpawn(10.75f); // checked
				SetEnemySpawn(10f); // checked
				SetBossSpawn(7f); // checked
			}else{
				SetSun(-3f); // checked
			}
			break;
			// 5:4
		case "1.25":
			if (Application.loadedLevelName == "Game") {
				gameObject.transform.localScale = new Vector3(17.5f, 14f, 1f);
				SetPlayerSpawn (new Vector2(-7.25f,0f)); // checked
				SetLifeSpawn (-8.75f); // checked
				SetShipBoundary(8.05f); // checked
				SetAsteroidSpawn(10.25f); // checked
				SetEnemySpawn(9.5f); // checked
				SetBossSpawn(7f); // checked
			}else{
				SetSun(-2.5f); // checked
			}
			break;
			// Defaults to 16:9
		default:
			if (Application.loadedLevelName == "Game") {
				gameObject.transform.localScale = new Vector3(24.9f, 14f, 1f);
				SetPlayerSpawn (new Vector2(-11f,0f));
				SetLifeSpawn (-12.5f);
				SetShipBoundary(11.8f);
				SetAsteroidSpawn(14f);
				SetEnemySpawn(13f);
				SetBossSpawn(9f);
			}else{
				SetSun(-4f);
			}
			break;
		}
	}
	void SetSun(float xCord){
		GameObject sun = GameObject.Find ("Sun");
		sun.transform.position = new Vector3 (xCord, 0f, 0f);
	}
	void SetPlayerSpawn(Vector2 location){
		GameObject player = GameObject.Find ("Player");
		SpawnShip script = player.GetComponent<SpawnShip> ();
		script.ShipSpawnLocation = location;
	}
	void SetLifeSpawn(float location){
		GameObject lifeManager = GameObject.Find ("LifeManager");
		KeepLives script = lifeManager.GetComponent<KeepLives> ();
		script.LifeSpawnLocation = location;
	}
	void SetShipBoundary(float boundary){
		GameObject gameManager = GameObject.Find ("GameManager");
		LoadSettings gameScript = gameManager.GetComponent<LoadSettings> ();
		ShipMove script = ships[gameScript.shipNumber].GetComponent<ShipMove> ();
		script.xBoarder = boundary;
	}
	void SetAsteroidSpawn(float location){
		GameObject asteroids = GameObject.Find ("Asteroids");
		RandomAsteroid script = asteroids.GetComponent<RandomAsteroid>();
		script.xSpawn = location;
	}
	void SetEnemySpawn(float location){
		GameObject enemies = GameObject.Find ("Enemies");
		RandomEnemies script = enemies.GetComponent<RandomEnemies>();
		script.xSpawn = location;
	}
	void SetBossSpawn(float location){
		BossMove script = boss.GetComponent<BossMove>();
		script.xBoarder = location;
	}
}
