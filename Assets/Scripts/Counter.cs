using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour {
	
	public Slider CounterBar;
	public int OldCounter;
	public static int NewCounter;
	public GameObject LevelSuccess;
	public GameObject Right;
	public GameObject Wrong;
	public GameObject UpperFrame;
	public GameObject Slider;
	public GameObject Pause;
	public GameNumbers gameNumbers;
	public bool didResume,didRestart;
	public int finishWithStars;
    private int levelIndex;
    private musicTriggers mscTriggers;

    void Awake(){
		finishWithStars = 0;
        mscTriggers = GameObject.Find("GameManager").GetComponentInChildren<musicTriggers>();
        gameNumbers = GameObject.Find ("Gameplay").GetComponent<GameNumbers>();
        levelIndex = SceneManager.GetActiveScene().buildIndex;
    }

	void Start () {
		CounterBar = GetComponent<Slider> ();
	}


	void Update(){
        //Debug.Log(PlayerPrefs.GetInt("totalStars",0));
			CounterBar.value = OldCounter;
			OldCounter = NewCounter;

		if(OldCounter == 12 || OldCounter>=12){
			NewCounter = 0;
			LevelSuccess.SetActive (true);
			Right.SetActive (false);
			Wrong.SetActive (false);
			UpperFrame.SetActive (false);
			//Slider.SetActive (false);
			Pause.SetActive (false);
			finishWithStars = LevelSuccess.GetComponentInChildren<StarCountClass> ().CountActive ();
            //add up the stars to persistent data
            //save this to prefs
            StartCoroutine(gameNumbers.addstars(finishWithStars));
            Data.SaveData(levelIndex, true, finishWithStars);
            mscTriggers.PlaySingle(mscTriggers.audioClip[1]);
            LevelSuccess.GetComponent<Animator> ().enabled = true;

		}

	}

	public static void AddCounter(int counterToAdd)
	{
		NewCounter += counterToAdd;

	}

	public void ResumeCounter(){
		didResume = true;
	}
	public void RestartCounter(){
		didRestart = true;
	}

}
