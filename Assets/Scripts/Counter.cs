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
    public int targetCorrectMaxValues = 12;
    private ScoreManager scoreManager;
    //private bool isFinish;

    void Awake(){

		finishWithStars = 0;
        mscTriggers = GameObject.Find("GameManager").GetComponentInChildren<musicTriggers>();
        gameNumbers = GameObject.Find ("Gameplay").GetComponent<GameNumbers>();
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        scoreManager = LevelSuccess.GetComponentInChildren<ScoreManager>();
    }

	void Start () {
        //isFinish = false;
        if (levelIndex == 21)
        {
            targetCorrectMaxValues = 8;
        } else if (levelIndex == 12 || levelIndex == 13 || levelIndex == 16)
        {
            targetCorrectMaxValues = 10;
        }

        CounterBar = GetComponent<Slider> ();
        CounterBar.maxValue = targetCorrectMaxValues;
	}


	void Update(){
        //Debug.Log(PlayerPrefs.GetInt("totalStars",0));
			CounterBar.value = OldCounter;
			OldCounter = NewCounter;

		if(OldCounter == targetCorrectMaxValues || OldCounter>= targetCorrectMaxValues)
        {
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
            scoreManager.manageHighScoreData();
            Data.SaveData(levelIndex, true, finishWithStars,ScoreManager.score);
            mscTriggers.PlaySingle(mscTriggers.audioClip[1]);
            LevelSuccess.GetComponent<Animator> ().enabled = true;
            //isFinish = true;
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
