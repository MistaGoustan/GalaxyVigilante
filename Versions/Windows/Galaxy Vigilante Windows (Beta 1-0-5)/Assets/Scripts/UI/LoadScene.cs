using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public void SceneToLoad(int SceneVal){
		Application.LoadLevel (SceneVal);
		Time.timeScale = 1;
	}
}
