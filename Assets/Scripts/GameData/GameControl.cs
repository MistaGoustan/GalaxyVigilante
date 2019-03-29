using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class GameControl : MonoBehaviour {
	public static GameControl control;
	// these variables are place holder, cant be used to initilize data just temperary storage
	// for example change the value outside the script before saving.
	public float musicVolume;
	public float SFXVolume;
	public int[] scores;
	public string[] names;
	public string gameDifficulty;
	public int ship;
	public bool[] unlockedShips;


	// if there is no control keep this one other wise destroy the new one
	void Awake(){
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
	}
	public void Save(){
		Debug.Log ("SAVE");
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		
		PlayerData data = new PlayerData ();

		// sounds
		data.musicVolume = musicVolume;
		data.SFXVolume = SFXVolume;
		// scores
		data.scores = scores;
		data.names = names;
		// difficulty
		data.gameDifficulty = gameDifficulty;
		// ship
		data.ship = ship;
		data.unlockedShips = unlockedShips;

		bf.Serialize (file, data);
		file.Close();
	}
	public void Load(){
		Debug.Log ("LOAD");
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			// sounds
			musicVolume = data.musicVolume;
			SFXVolume = data.SFXVolume;
			// scores
			scores = data.scores;
			names = data.names;
			// difficulty
			gameDifficulty = data.gameDifficulty;
			// ship
			ship = data.ship;
			unlockedShips = data.unlockedShips;

		} else {
			Debug.Log ("LOAD AND RESET");
			CheckForFileData ();
		}
	}
	void CheckForFileData(){
		// if there is no data when trying to load reset the data
		GameObject menuManager = GameObject.Find ("MenuManager");
		DataManager script = menuManager.GetComponent<DataManager>();
		script.ResetData();
	}
}
[Serializable]
class PlayerData{
	// this is data to be accessed from a file also cant be initilized
	public float musicVolume;
	public float SFXVolume;
	public int[] scores;
	public string[] names;
	public string gameDifficulty;
	public int ship;
	public bool[] unlockedShips;
}
