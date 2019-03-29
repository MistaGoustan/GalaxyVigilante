using UnityEngine;
using System.Collections;

public class DestroyExplosion : MonoBehaviour {
	private float DestroyTime = 0.0f;
	private bool DestroyE = false;
	
	// Update is called once per frame
	void Update () {
		//
		if (DestroyE == true) {
			Destroy (gameObject);
		}
		// if its alive add to the time
		else {
			// add to the time
			DestroyTime += Time.deltaTime;
		}

		// if time is ready then can shoot
		if(DestroyTime >= 1f)
		{
			DestroyE = true;
		}
	}
}
