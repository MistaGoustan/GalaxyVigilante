using UnityEngine;
using System.Collections;

public class SpawnShield : MonoBehaviour {
	public GameObject Shield;
	private SpriteRenderer shieldSpriteRenderer;
	public Sprite[] Images;
	public float immuneTime;
	public bool isImmune = false;
	private bool toggleImage = true;
	private float countTime = 0.225f;

	// Update is called once per frame
	void Update () {
		if (Shield != null) {
			// if time is ready then can die
			if (Time.time >= immuneTime && isImmune == true) {
				isImmune = false;
			}else if (isImmune == true){
				ToggleImage();
			}
		}
	}
	void ResetImmune(){
		isImmune = true;
		immuneTime = Time.time + 2.25f;
	}
	void ToggleImage(){
		if (countTime >= Time.time && toggleImage == true){
			
			if (shieldSpriteRenderer != null){
				ImageSwap ();
				toggleImage = false;
			}else{
				// store shields image
				GameObject ExistingShield = GameObject.FindWithTag ("Shield");
				shieldSpriteRenderer = ExistingShield.GetComponent<SpriteRenderer> ();
			}
		}else if (countTime < Time.time) {
			countTime = Time.time + 0.225f;
			toggleImage = true;
		}
	}
	void ImageSwap(){
		if (shieldSpriteRenderer.sprite.name == "Shield01a"){
			shieldSpriteRenderer.sprite = Images[1];
		}
		else if(shieldSpriteRenderer.sprite.name == "Shield01b"){
			shieldSpriteRenderer.sprite = Images[0];
		}
	}
	public void Spawn(){
		ResetImmune ();
		GameObject ship = GameObject.FindWithTag("Ship");
		// find shot cord before instance
		Vector2 pos = new Vector2 (ship.transform.position.x, ship.transform.position.y); 
		Instantiate (Shield,
		             Shield.transform.position = pos,
		             Shield.transform.rotation);
	}
}
