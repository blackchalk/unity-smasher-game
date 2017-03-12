using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Pause : MonoBehaviour {

	public GameObject PauseButton;
	public GameObject PauseFrame;
	public GameObject GamePanel;
	public GameObject UpperFrame;
	public GameObject lvl1pregame;
	public GameObject Timer;
	public Slider CounterSlider;
	public Counter cs;
	public unpaused disabler;
	public GameObject counterSliderGO;


	public void Paused(){
		lvl1pregame.SetActive (false);
		PauseButton.SetActive (false);
		PauseFrame.SetActive (true);
		GamePanel.SetActive (true);
		UpperFrame.SetActive (false);
		Timer.SetActive (false);
	
		if (Time.timeScale == 1f) {
			Time.timeScale = 0f;
		}
	}
		
	public void Resume(){
//		CounterSlider.value = counterSliderGO.GetComponent<Counter>().OldCounter;
////		disabler = GameObject.Find ("Count").GetComponent<unpaused> ();
		PauseButton.SetActive (true);
		PauseFrame.SetActive (false);
		GamePanel.SetActive (false);
		UpperFrame.SetActive (true);
		Timer.SetActive (true);
//

		if (Time.timeScale == 0f) {
			Time.timeScale = 1f;

		}
	}

	public void Restart(string x){
//		cs = GameObject.Find ("Counter Slider").GetComponent<Counter> ();
//		cs.OldCounter = 0;
		SceneManager.LoadScene (x);
	}

	public void HomeButton(){
		SceneManager.LoadScene ("Main");
	}

	public void MapButton(){
		SceneManager.LoadScene ("Map");
	}
}
