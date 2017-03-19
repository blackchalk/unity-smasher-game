using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level4Scene2 : MonoBehaviour {

	public int pointsToAdd;
	public Slider timeBar;
	public float startingTime;
	public int toBeDeducted;
	public int counting=0;
	public GameObject[] questionObjects;
	public GameObject UpperFrame;
	public Sprite[] sprQuestions;
	public bool gameEnd = false;

	void Start(){
		UpperFrame = GameObject.Find ("Upper Frame");
		timeBar = GetComponent<Slider> ();
		timeBar.value = startingTime;
		questionObjects [counting].SetActive (true);
		questionObjects [1].SetActive (false);
		questionObjects [2].SetActive (false);
		questionObjects [3].SetActive (false);
		questionObjects [4].SetActive (false);
	
	}

	void Update(){
		if (timeBar.value > 0.0f) {
			timeBar.value -= Time.deltaTime;
		}
		if (timeBar.value== 0.0f) {
//			SceneManager.LoadScene ("Level4Scene3");
			timeBar.value = startingTime;
			HeartAndStars.MinusHeartAndStars (toBeDeducted);
			counting++;
			if (!gameEnd) {
				changeQuestions (counting);
				changeUpperFrameQuestions (counting);
			} else {
				//do nothing
			}
		}
		if (counting >= 5) {
			gameEnd = true;
		}
	}
	public void changeQuestions(int c){
		if (!gameEnd) {
			switch (c) {
			case 0: 
				questionObjects [0].SetActive (true);
				questionObjects [1].SetActive (false);
				questionObjects [2].SetActive (false);
				questionObjects [3].SetActive (false);
				questionObjects [4].SetActive (false);
				break;
			case 1: 
				questionObjects [0].SetActive (false);
				questionObjects [1].SetActive (true);
				questionObjects [2].SetActive (false);
				questionObjects [3].SetActive (false);
				questionObjects [4].SetActive (false);
				break;
			case 2: 
				questionObjects [0].SetActive (false);
				questionObjects [1].SetActive (false);
				questionObjects [2].SetActive (true);
				questionObjects [3].SetActive (false);
				questionObjects [4].SetActive (false);
				break;
			case 3: 
				questionObjects [0].SetActive (false);
				questionObjects [1].SetActive (false);
				questionObjects [2].SetActive (false);
				questionObjects [3].SetActive (true);
				questionObjects [4].SetActive (false);
				break;
			case 4: 
				questionObjects [0].SetActive (false);
				questionObjects [1].SetActive (false);
				questionObjects [2].SetActive (false);
				questionObjects [3].SetActive (false);
				questionObjects [4].SetActive (true);
				break;
			default:
				questionObjects [0].SetActive (true);
				questionObjects [1].SetActive (false);
				questionObjects [2].SetActive (false);
				questionObjects [3].SetActive (false);
				questionObjects [4].SetActive (false);
				break;
			
			}
		} else {
		//do nothing
		}
	}
	public void changeUpperFrameQuestions(int c){
		if (gameEnd==false) {
			UpperFrame.GetComponent<Image> ().sprite = sprQuestions [c];
		} 
		if (gameEnd == true) {
            Debug.Log("finish");
			//do nothing        
		}
	}

}
