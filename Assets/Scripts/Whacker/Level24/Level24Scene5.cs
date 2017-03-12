using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level24Scene5 : MonoBehaviour {

	public int pointsToAdd;
	public Slider timeBar;
	public float startingTime;

	void Start(){
		timeBar = GetComponent<Slider> ();
	}

	void Update(){
		timeBar.value = startingTime;
		startingTime -= Time.deltaTime;

		if (startingTime <= 0) {
			SceneManager.LoadScene ("Complete");
		}
	}

}
