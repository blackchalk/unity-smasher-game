using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WhackerPause : MonoBehaviour {

	public GameObject PauseButton;
	public GameObject PauseFrame;
	public GameObject GamePanel;
	public GameObject PausePanel;
	public GameObject UpperFrame;
	public GameObject Timer;
	public GameObject True1;
	public GameObject False1;
	public GameObject False2;
	public GameObject False3;

	public bool isPaused = false;
	private Level4Scene2Touch lvl4scene2touch;

	void Start(){
		lvl4scene2touch = new Level4Scene2Touch ();


	}

	public void Paused(){
		isPaused = true;
		lvl4scene2touch.allowTouch = false; 
		PauseButton.SetActive (false);
		PauseFrame.SetActive (true);
		GamePanel.SetActive (false);
		PausePanel.SetActive (true);
		UpperFrame.SetActive (false);
		Timer.SetActive (false);
        lvl4scene2touch.allowClick = false;
        lvl4scene2touch.secondsToWait = 5.0f;
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		}
	}

	public void Resume(){
		isPaused = false;
		lvl4scene2touch.allowTouch = true;
		PauseButton.SetActive (true);
		PauseFrame.SetActive (false);
		GamePanel.SetActive (false);
		PausePanel.SetActive (false);
		UpperFrame.SetActive (true);
		Timer.SetActive (true);

		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
	}

	public void Restart(){
	}

	public void HomeButton(){
		SceneManager.LoadScene ("Main");
	}

	public void MapButton(){
		SceneManager.LoadScene ("Map 1");
	}
}
