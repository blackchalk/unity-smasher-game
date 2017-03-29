using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreGame : MonoBehaviour {

	public GameObject PregameFrame;
	public GameObject PauseButton;
	public GameObject UpperFrame;
	public GameObject Right;
	public GameObject Wrong;
	public GameObject GamePanel;
	public GameObject Smash;
	public GameObject Em;
	public GameObject NotesFrame;
	public GameObject Slider;
	public GameObject LevelSuccess;

	void Awake(){
		PregameFrame = GameObject.Find ("Level1 PreGame");
		PauseButton = GameObject.Find ("Pause Button");
		UpperFrame = GameObject.Find ("Upper Frame");
		Right = GameObject.Find ("Right");
		Wrong = GameObject.Find ("Wrong");
//		Smash = GameObject.Find ("Smash");
//		Em = GameObject.Find ("Em");
//		NotesFrame = GameObject.Find ("Notes Frame");
		Slider = GameObject.Find ("Counter Slider");
		LevelSuccess = GameObject.Find ("Success Frame");
	}

	void Start(){
		Right.SetActive (false);
		Wrong.SetActive (false);
		UpperFrame.SetActive (false);
		PauseButton.SetActive (false);
		Smash.SetActive (false);
		Em.SetActive (false);
		NotesFrame.SetActive (false);
		Slider.SetActive (false);
		LevelSuccess.SetActive (true);
		LevelSuccess.GetComponent<Animator> ().enabled = false;
	}

	public void Play(){
		Slider.GetComponent<Slider> ().value = 0f;
		PregameFrame.SetActive (false);
		UpperFrame.SetActive (true);
		Right.SetActive (true);
		Wrong.SetActive (true);
		PauseButton.SetActive (true);
		GamePanel.SetActive (false);
		Smash.SetActive (true);
		Em.SetActive (true);
		Slider.SetActive (true);
		LevelSuccess.SetActive (true);
		LevelSuccess.GetComponent<Animator> ().enabled = false;
	}

	public void Notes(){
		PregameFrame.SetActive (false);
		NotesFrame.SetActive (true);

	}

	public void NotesBack(){
		PregameFrame.SetActive (true);
		NotesFrame.SetActive (false);
	}

	public void Exit(){
        SceneManager.LoadScene("Map 1");
	}

}
