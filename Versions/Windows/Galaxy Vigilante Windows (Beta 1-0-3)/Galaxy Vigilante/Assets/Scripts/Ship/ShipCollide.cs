using UnityEngine;
using System.Collections;

public class ShipCollide : MonoBehaviour {
	public GameObject Explosion;
	public GameObject Ship;
	public bool ShipDead = false;
	// on collision destroy ship and make explosion
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag != "PowerUp01" && other.gameObject.tag != "PowerUp02" &&
		    other.gameObject.tag != "PowerUp03" && other.gameObject.tag != "PowerUp04" &&
		    other.gameObject.tag != "Shield") {
			ShipCollision ();
		}
	}
	public void ShipCollision(){
		// get player and spawn script to check immunity
		GameObject player = GameObject.Find("Player");
		SpawnShip spawnScript = player.GetComponent<SpawnShip>();
		if (spawnScript.isImmune == false){
			ExplosionSound ();
			Destroy (gameObject);
			Toggle_Death ();
			LeaveExplosion ();
			Take_Life ();
		}
	}
	void Take_Life(){
		//find player and lives script
		GameObject lifeManager = GameObject.Find ("LifeManager");
		KeepLives lifeScript = lifeManager.GetComponent<KeepLives>();
		//if lives left then remove a life 
		if (lifeScript.LifeVal != 0) {
			lifeScript.RemoveLife ();
			// then respawn
			GameObject player = GameObject.Find ("Player");
			SpawnShip spawnScript = player.GetComponent<SpawnShip> ();
			// reset to not first spawn
			spawnScript.firstSpawn = false;
			spawnScript.Spawn ();
		}
			//if no more lives then enable the restart canvas
		else if (lifeScript.LifeVal == 0) {
			Enable_Canvas ();
			// reset the wave count and disable the script
			GameObject waveManager = GameObject.Find ("WaveManager");
			KeepWave script = waveManager.GetComponent<KeepWave>();
			script.ResetWave ();
			script.enabled=false;
			// remove boss bar if exists
			GameObject boss = GameObject.FindWithTag ("Boss");
			if (boss != null){
				BossCollide bossScript = boss.GetComponent<BossCollide>();
				bossScript.ToggleHealthBar ();
			}
		}
	}
	public void Toggle_Death(){
		ShipDead = !ShipDead;
	}
	void Enable_Canvas(){
		GameObject canvasManager = GameObject.Find("CanvasManager");
		HighScoreManager scoresScript = canvasManager.GetComponent<HighScoreManager> ();
		scoresScript.EnableCanvas ();
	}
	void LeaveExplosion(){
		// leave explosion
		Instantiate (Explosion,
		             Explosion.transform.position = new Vector2(Ship.transform.position.x, Ship.transform.position.y),
		             Explosion.transform.rotation);
	}
	void ExplosionSound(){
		// Play Sound
		GameObject Player = GameObject.Find("Player");
		PlaySound SoundScript = Player.GetComponent<PlaySound>();
		SoundScript.Play ();
	}
}