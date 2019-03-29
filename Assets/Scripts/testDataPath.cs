using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testDataPath : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
		text.text = Application.persistentDataPath;
		Debug.Log (Application.persistentDataPath);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
