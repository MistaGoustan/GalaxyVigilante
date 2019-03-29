using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LoadSettings : MonoBehaviour {
	public GameObject ship01;
	public GameObject ship02;
	public GameObject ship03;
	public GameObject ship04;
	public GameObject enemy01;
	public GameObject enemy02;
	public GameObject enemy03;
	public GameObject boss;
	public GameObject player;
	public GameObject enemies;
	public GameObject asteroids;
	public GameObject powerups;
	public GameObject bosses;
	public GameObject lifeManager;
	public string gameDifficulty;
	public int shipNumber;

	void Awake(){
		MusicVolume ();
		SFXVolume ();
		Difficulty ();
		Ship ();
	}
	void Ship(){
		GameObject GameControl = GameObject.Find ("GameController");
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			shipNumber = script.ship;
		}
	}
	void Difficulty(){
		GameObject GameControl = GameObject.Find ("GameController");
		GameObject waveManager = GameObject.Find ("WaveManager");
		KeepWave waveScript = waveManager.GetComponent<KeepWave> ();
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			// set difficulty
			waveScript.gameDifficulty = script.gameDifficulty;
		}
	}
	void MusicVolume(){
		GameObject BG = GameObject.Find ("BG");
		// get background audio and playersettings in a var
		AudioSource source = BG.GetComponent<AudioSource> ();

		GameObject GameControl = GameObject.Find ("GameController");
		// adjust the music volume
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			source.volume = script.musicVolume;
		}
	}
	void SFXVolume(){
		// get all objects that make sound
		GameObject[] AllObjects = { player, enemies, 
									asteroids, bosses, powerups, lifeManager,  
									ship01, ship02, ship03, ship04,
									enemy01, enemy02, enemy03, boss};

		GameObject GameControl = GameObject.Find ("GameController");
		// adjust the SFX volume
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			// for each object store its source in a temp var then change the custom volume
			for(int i = 0; i < AllObjects.Length; i++){
				AudioSource sources = AllObjects[i].GetComponent<AudioSource>();
				sources.volume = script.SFXVolume;
			}
		}
	}
}
