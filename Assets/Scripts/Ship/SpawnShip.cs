﻿using UnityEngine;
using System.Collections;

public class SpawnShip : MonoBehaviour {
	public GameObject Ship01;
	public GameObject Ship02;
	public GameObject Ship03;
	public GameObject Ship04;
	private GameObject Ship;
	public Vector2 ShipSpawnLocation;
	public float immuneTime;
	private float countTime = 0.225f;
	private bool toggleImage = true;
	public bool isImmune = false;
	[HideInInspector]public Vector2 spawnPosition;
	public bool firstSpawn = true;
	private SpriteRenderer shipSpriteRenderer;
	public Sprite[] FirstImage;
	public Sprite[] SecondImage;
	private GameObject engines;


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
		             ShipSpawnLocation,
		             Quaternion.identity);
		FirstSpawn ();
		// toggle bool that ship is not dead
		ShipCollide deathScript = Ship01.GetComponent<ShipCollide> ();
		deathScript.Toggle_Death ();
	}
	void Update(){
		// if time is ready then can die
		if (Time.time >= immuneTime && isImmune == true) {
			isImmune = false;
		} // toggle sprite on/off
		else if (isImmune == true) {
			ToggleShipImage();
		}
	}
	void ToggleShipImage(){
		if (countTime >= Time.time && toggleImage == true){

			if (shipSpriteRenderer != null){
				ImageSwap ();
				toggleImage = false;
			}else{
				// store ships image
				GameObject ExistingShip = GameObject.FindWithTag ("Ship");
				shipSpriteRenderer = ExistingShip.GetComponent<SpriteRenderer> ();
				// Store particle system
				engines = GameObject.Find ("ShipEngines");
			}
		}else if (countTime < Time.time) {
			countTime = Time.time + 0.225f;
			toggleImage = true;
		}
	}
	void ImageSwap(){
		GameObject gameManager = GameObject.Find ("GameManager");
		LoadSettings script = gameManager.GetComponent<LoadSettings> ();
		switch (script.shipNumber) {
		case 0:
			if (shipSpriteRenderer.sprite.name == "Ship01a"){
				shipSpriteRenderer.sprite = SecondImage[0];
				engines.SetActive (false);
			}
			else if(shipSpriteRenderer.sprite.name == "Ship01b"){
				shipSpriteRenderer.sprite = FirstImage[0];
				engines.SetActive (true);
			}
			break;
		case 1:
			if (shipSpriteRenderer.sprite.name == "Ship02a"){
				shipSpriteRenderer.sprite = SecondImage[1];
				engines.SetActive (false);
			}
			else if(shipSpriteRenderer.sprite.name == "Ship02b"){
				shipSpriteRenderer.sprite = FirstImage[1];
				engines.SetActive (true);
			}
			break;
		case 2:
			if (shipSpriteRenderer.sprite.name == "Ship03a"){
				shipSpriteRenderer.sprite = SecondImage[2];
				engines.SetActive (false);
			}
			else if(shipSpriteRenderer.sprite.name == "Ship03b"){
				shipSpriteRenderer.sprite = FirstImage[2];
				engines.SetActive (true);
			}
			break;
		case 3:
			if (shipSpriteRenderer.sprite.name == "Ship04a"){
				shipSpriteRenderer.sprite = SecondImage[3];
				engines.SetActive (false);
			}
			else if(shipSpriteRenderer.sprite.name == "Ship04b"){
				shipSpriteRenderer.sprite = FirstImage[3];
				engines.SetActive (true);
			}
			break;
		}
	}
	void FirstSpawn(){
		if (firstSpawn == true) {
			StartingPowerup ();
			isImmune = false;
		} 
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
		case 3:
			Ship = Ship04;
			break;
		}
	}
	void RemovePowerup(){
		// reove only double shot at the moment
		ShipFire fireScript = Ship.GetComponent<ShipFire>();
		fireScript.enabled = true;
		ShipDoubleShot doubleShotScript = Ship.GetComponent<ShipDoubleShot>();
		doubleShotScript.enabled = false;
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
