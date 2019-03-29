using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BossHealth : MonoBehaviour {
	private RectTransform healthTransform;
	private float cachedY;
	private float minXValue;
	private float maxXValue;
	public int currentHealth;
	public int maxHealth;
	private Image visualHealth;
	private Canvas gameCanvas;

	void Awake (){
		// get canvas and healthbar at startup
		GameObject health = GameObject.Find ("Health");
		healthTransform = health.GetComponent<RectTransform>();
		visualHealth = health.GetComponent<Image> ();

		GameObject GC = GameObject.Find ("GameCanvas");
		gameCanvas = GC.GetComponent<Canvas> ();
	}

	void Start () {
		maxHealth = GetHealth ();
		// store these positions so we dont contiune to access them
		cachedY = healthTransform.position.y;
		maxXValue = healthTransform.position.x;
		minXValue = (healthTransform.position.x - healthTransform.rect.width * gameCanvas.scaleFactor) ;
		currentHealth = maxHealth;
	}

	public void HandleHealth(){
		float currentXValue = MapValues (currentHealth, 0, maxHealth, minXValue, maxXValue);

		healthTransform.position = new Vector2 (currentXValue, cachedY);

		if (currentHealth >= maxHealth / 2) {//Then health is more then 50%
			visualHealth.color = new Color32((byte)MapValues (currentHealth, maxHealth/2, maxHealth, 255, 0), 255, 0, 255);
		} else {// less then 50%
			visualHealth.color = new Color32(255, (byte)MapValues (currentHealth, 0, maxHealth/2, 0, 255), 0, 255);
		}
	}

	float MapValues(float x, float inMin, float inMax, float outMin, float outMax){
		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
	int GetHealth(){
		GameObject waveManager = GameObject.Find ("WaveManager");
		KeepWave script = waveManager.GetComponent<KeepWave> ();
		int health;
		switch (script.gameDifficulty) {
		case "Easy":
			health = 100;
			break;
		case "Medium":
			health = 200;
			break;
		case "Hard":
			health = 300;
			break;
		default:
			health = 200;
			break;
		}
		return health;
	}
}
