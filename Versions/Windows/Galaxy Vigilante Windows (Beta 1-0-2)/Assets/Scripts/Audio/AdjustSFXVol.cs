using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AdjustSFXVol : MonoBehaviour {
	public float Volume = 1f;
	void Awake(){
		AdjustSFXSSlider ();
	}
	
	public void AdjustSFXVolume(float newVol){
		// adjust volume to slider val
		Volume = newVol;
		// get settings
		GameObject GameControl = GameObject.Find ("GameController");
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			// then save the volume
			script.SFXVolume = Volume;
		}
	}
	public void AdjustSFXSSlider(){
		// get slider
		GameObject sfxSlider = GameObject.Find ("SFXSlider");
		Slider sliderObject = sfxSlider.GetComponent<Slider> ();
		//get settings
		GameObject GameControl = GameObject.Find ("GameController");
		if (GameControl != null) {
			GameControl script = GameControl.GetComponent<GameControl> ();
			// load custom sfx settings
			sliderObject.value = script.SFXVolume;
		}
	}
}
