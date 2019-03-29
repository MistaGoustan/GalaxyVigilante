using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SoundPercent : MonoBehaviour {
	public int PercentVal;
	public double SoundVal;
	public Text text;

	void Awake () {
		text = text.GetComponent <Text> ();
		PercentVal = 100;
		UpdatePercent ();
	}
	void Update (){
		// get the manager to refernce the script
		GameObject Manager = GameObject.Find ("SettingsManager");
		// check what script is needed
		if (this.gameObject.name == "MusicPercentText") {
			AdjustMusicVol volScript = Manager.GetComponent<AdjustMusicVol> ();
			SoundVal = volScript.Volume;
		} else if (this.gameObject.name == "SFXPercentText") {
			AdjustSFXVol volScript = Manager.GetComponent<AdjustSFXVol> ();
			SoundVal = volScript.Volume;
		}
		// get 2 dec places
		SoundVal = System.Math.Round(SoundVal,2);
		// turn it into a percent
		SoundVal *= 100;
		// then store it
		PercentVal = (int) SoundVal;
		UpdatePercent ();
	}
	void UpdatePercent () {
		text.text = PercentVal + "%";
	}
}
