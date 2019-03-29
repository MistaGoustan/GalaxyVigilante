using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class KeepLives : MonoBehaviour {
	public int LifeVal;
	public GameObject Life;
	public GameObject lifeText;
	public float LifeSpawnLocation;
	public Sprite[] ShipSprites;
	private int shipNumber;
	private Text text;
	private float textTime = 0.0f;

	void Start () {
		LifeVal = 3;
		GetShipNumber ();
		UpdateLife ();
		// get the +1 Life text then disable it on start
		text = lifeText.GetComponent<Text>();
		text.enabled = false;
	}
	void Update(){
		// add to the time
		textTime += Time.deltaTime;
		// if time is ready then show text
		if(textTime >= 2f)
		{
			text.enabled = false;
		}
	}


	void GetShipNumber(){
		GameObject gameManager = GameObject.Find ("GameManager");
		LoadSettings script = gameManager.GetComponent<LoadSettings> ();
		shipNumber = script.shipNumber;
	}

	// Update life
	void UpdateLife () {
		// set init position
		Life.transform.position = new Vector2 (LifeSpawnLocation, 6.7f);
		// move life over 1 each time
		float pos = .6f;
		//put lives on sceen
		for(int i = 0; i < LifeVal; i++){
			SpriteRenderer sr = Life.GetComponent<SpriteRenderer>();
			sr.sprite = ShipSprites[shipNumber];
			Instantiate (Life,
			             Life.transform.position = new Vector2 (Life.transform.position.x + pos, 6.7f),
			             Quaternion.identity);
		}
		GameObject[] Lives = GameObject.FindGameObjectsWithTag("Life");
		for(int i = 0; i < LifeVal; i++){
			Lives[i].transform.parent = GameObject.Find("LifeManager").transform;
		}

	}
	public void RemoveLife (){
		// remove to be replaced
		RemoveLives ();
		LifeVal -= 1;
		UpdateLife ();
	}
	public void AddLife (){
		RemoveLives ();
		LifeVal += 1;
		UpdateLife ();
		//enable the text once life has increased and reset the time it can be on
		text.enabled = true;
		textTime = 0.0f;
		// play life increase sound
		PlaySound soundScript = GetComponent<PlaySound> ();
		soundScript.Play ();
	}
	public void ResetLives(){
		LifeVal = 3;
		UpdateLife ();
	}
	//remove to be replaced
	void RemoveLives(){
		// get lives and put them in arry so they can be removed and replaced
		GameObject[] Lives = GameObject.FindGameObjectsWithTag("Life");
		for(int i = 0; i < LifeVal; i++){
			Destroy(Lives[i]);
		}
	}
}
