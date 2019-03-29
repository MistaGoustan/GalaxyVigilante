using UnityEngine;
using System.Collections;

public class SpawnShip : MonoBehaviour {
	public GameObject Ship01;
	public GameObject Ship02;
	public GameObject Ship03;
	private GameObject Ship;
	public float immuneTime;
	public float countTime = 0.225f;
	private bool toggleImage = true;
	public bool isImmune = false;
	[HideInInspector]public Vector2 spawnPosition;
	public bool firstSpawn = true;
	private SpriteRenderer shipSpriteRenderer;

	// Use this for initialization
	void Start () {
		SetShip ();
		// Spawn Ship
		Spawn ();
	}
	public void Spawn(){
		ResetImmune ();
		// CHANGE FIRST SPAWN TO AFTER SO IT DOESNT EFFECT PREFABS
		RemovePowerup ();
		Instantiate (Ship,
		             Ship.transform.position,
		             Ship.transform.rotation);
		FirstSpawn ();
		// toggle bool that ship is not dead
		ShipCollide deathScript = Ship01.GetComponent<ShipCollide> ();
		deathScript.Toggle_Death ();
	}
	void Update(){
		// if time is ready then can die
		if (Time.time >= immuneTime && isImmune == true) {
			NotImmune ();
		} // toggle sprite on/off
		else if (isImmune == true) {
			ToggleShipImage();
		}
	}
	void ToggleShipImage(){
		if (countTime >= Time.time && toggleImage == true){
			// if image exists use it other wise get the image
			if (shipSpriteRenderer != null){
				shipSpriteRenderer.enabled = !shipSpriteRenderer.enabled;
				toggleImage = false;
			}else{
				// store ships image
				GameObject ExistingShip = GameObject.FindWithTag ("Ship");
				shipSpriteRenderer = ExistingShip.GetComponent<SpriteRenderer> ();
			}
		}else if (countTime < Time.time) {
			countTime = Time.time + 0.225f;
			toggleImage = true;
		}
	}
	void FirstSpawn(){
		if (firstSpawn == true) {
			StartingPowerup ();
			NotImmune ();
		} 
	}
	void NotImmune(){
		// store ships image
		GameObject ExistingShip = GameObject.FindWithTag ("Ship");
		shipSpriteRenderer = ExistingShip.GetComponent<SpriteRenderer> ();
		isImmune = false;
		// THIS IS TURNING IT BACK ON WHY OFF?
		shipSpriteRenderer.enabled = true;
	}
	void ResetImmune(){
		isImmune = true;
		immuneTime = Time.time + 2.25f;
	}
	void SetShip(){
		GameObject gameManager = GameObject.Find ("GameManager");
		LoadSettings script = gameManager.GetComponent<LoadSettings> ();
		switch (script.shipNumber) {
		case 0:
			Ship = Ship01;
			break;
		case 1:
			Ship = Ship02;
			break;
		case 2:
			Ship = Ship03;
			break;
		}
	}
	void RemovePowerup(){
		GameObject gameManager = GameObject.Find ("GameManager");
		LoadSettings script = gameManager.GetComponent<LoadSettings> ();
		switch (script.shipNumber) {
		case 1:
			ShipFire fireScript = Ship.GetComponent<ShipFire>();
			fireScript.enabled = true;
			ShipDoubleShot doubleShotScript = Ship.GetComponent<ShipDoubleShot>();
			doubleShotScript.enabled = false;
			break;
		case 2:
			ShipShield shieldScript = Ship.GetComponent<ShipShield>();
			shieldScript.SpawnShield = false;
			break;
		}
	}
	void StartingPowerup(){
		//get game manager
		GameObject gameManager = GameObject.Find ("GameManager");
		LoadSettings script = gameManager.GetComponent<LoadSettings> ();
		// get powerups
		GameObject powerUps = GameObject.Find ("PowerUps");
		PowerUpCollide powerScript = powerUps.GetComponent<PowerUpCollide>();
		switch (script.shipNumber) {
		case 1:
			Debug.Log ("Start with double shot");
			powerScript.Power2 ();
			break;
		case 2:
			Debug.Log ("Start with Shield");
			powerScript.Power3 ();
			break;
		}
	}
}
