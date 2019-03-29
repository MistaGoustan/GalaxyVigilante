using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {
	public GameObject waveManager;
	public GameObject bosses;

	public void ToggleStatus(){
		KeepWave waveScript = waveManager.GetComponent<KeepWave> ();
		waveScript.enabled = !waveScript.enabled;

		if (waveScript.enabled == true) {
			waveScript.UpdateWave ();
			waveScript.spawnBoss = false;
		}
	}
}
