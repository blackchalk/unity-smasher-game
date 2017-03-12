using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenTimer : MonoBehaviour {

	public float secondsToLoad;
	public string sceneToLoad;

	// Use this for initialization
	void Start () {
		secondsToLoad = 2.5f;
		
	}
	
	// Update is called once per frame
	void Update () {
		secondsToLoad -= Time.deltaTime;
		if (secondsToLoad <= 0.0f) {
			SceneManager.LoadScene (sceneToLoad);
		}


	}
}
