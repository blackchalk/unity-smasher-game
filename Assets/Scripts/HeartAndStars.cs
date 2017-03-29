using UnityEngine;
using System.Collections;

public class HeartAndStars : MonoBehaviour {


	public static int HeartAndStarCount;
	public GameObject Star3;
	public GameObject Heart3;
	public GameObject Star2;
	public GameObject Heart2;
	public GameObject Star1;
	public GameObject Heart1;
	public GameObject GameOver;
	public GameObject Questions;
	public GameObject Slider;
	public GameObject UpperFrame;
	public GameObject Right;
	public GameObject Wrong;
	public GameObject Pause;
	public GameNumbers gameNumbers;

	void Awake(){
        Slider = GameObject.Find("Counter Slider");
		UpperFrame = GameObject.Find("Upper Frame");

		Pause = GameObject.Find("Pause Button");
		gameNumbers = GameObject.Find ("Gameplay").GetComponent<GameNumbers> ();
	}

	void Start () {
		HeartAndStarCount = '3';
		gameNumbers = GameObject.Find ("Gameplay").GetComponent<GameNumbers> ();
	}
	

	void Update () {
		
		if (HeartAndStarCount == '2') {//currentStarCount = PlayerPrefs.GetInt ("totalStars");
			Star3.SetActive (false);
			Heart3.SetActive (false);

		} else if (HeartAndStarCount == '1') {
			Star2.SetActive (false);
			Heart2.SetActive (false);

		} else if (HeartAndStarCount == '0') {
			Counter.NewCounter = 0;
			Star3.SetActive (false);
			Heart3.SetActive (false);
			Star2.SetActive (false);
			Heart2.SetActive (false);
			Heart1.SetActive (false);
			Star1.SetActive (false);
			Right.SetActive (false);
			Wrong.SetActive (false);
			GameOver.SetActive (true);
			Questions.SetActive (false);
			Slider.SetActive (false);
			UpperFrame.SetActive (false);
			Pause.SetActive (false);
		}
	}

	public static void MinusHeartAndStars(int toBeDeducted){
		HeartAndStarCount -= toBeDeducted;

	}

}
