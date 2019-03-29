using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {
	// Audio
	public AudioClip SoundClip;
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1f;
	// Use this for initialization
	void Awake () {
		// assign the source component 
		source = GetComponent<AudioSource> ();
	}
	public void Play(){
		float vol = Random.Range (volLowRange, volHighRange);
		source.PlayOneShot (SoundClip, vol);
	}
}
