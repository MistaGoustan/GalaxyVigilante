using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AdjustMusicVol : MonoBehaviour {
	public float Volume = 1f;
	void Awake(){
		AdjustMusicSlider ();
	}

	public void AdjustMusicVolume(float newVol){
		// adjust volume to slider val
		Volume = newVol;
		// get settings
		GameObject GameControl = GameObject.Find ("GameController");
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			// then save the volume
			script.musicVolume = Volume;
		}
	}
	public void AdjustMusicSlider(){
		// get slider
		GameObject musicSlider = GameObject.Find ("MusicSlider");
		Slider sliderObject = musicSlider.GetComponent<Slider> ();
		//get settings
		GameObject GameControl = GameObject.Find ("GameController");
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			// get custom music settings
			sliderObject.value = script.musicVolume;
		}
	}
}
