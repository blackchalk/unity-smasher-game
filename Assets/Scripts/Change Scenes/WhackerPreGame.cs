using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WhackerPreGame : MonoBehaviour {

	public GameObject PregameFrame;
	public GameObject PauseButton;
	public GameObject UpperFrame;
	public GameObject True;
	public GameObject False1;
	public GameObject False2;
	public GameObject False3;
	public GameObject GamePanel;
	public GameObject Whack;
	public GameObject Em;
	public GameObject NotesFrame;
	public GameObject Slider;
	public GameObject LevelSuccess;
	public GameObject LevelFail;
	public GameObject Questions;
	public Level4Scene2 lvl4scene2;
    private int finishWithStars;
    private int levelIndex;
    public float secondsToWait = 5.0f;
    private GameNumbers gameNumbers;
    private musicTriggers mscTriggers;
    void Start(){
        mscTriggers = GameObject.Find("GameManager").GetComponentInChildren<musicTriggers>();
        gameNumbers = GameObject.Find("Gameplay").GetComponent<GameNumbers>();
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        finishWithStars = 0;
		True.SetActive (false);
		False1.SetActive (false);
		False2.SetActive (false);
		False3.SetActive (false);
		UpperFrame.SetActive (false);
		PauseButton.SetActive (false);
		Whack.SetActive (false);
		Em.SetActive (false);
		NotesFrame.SetActive (false);
		Slider.SetActive (false);
		LevelSuccess.SetActive (true);
		LevelSuccess.GetComponent<Animator> ().enabled = false;
		Slider.SetActive (false);
	}
	void Update(){
        if (lvl4scene2.gameEnd == true) {
			LevelFinish ();
		}
	}

	public void Play(){
		PregameFrame.SetActive (false);
		UpperFrame.SetActive (true);
		True.SetActive (true);
		False1.SetActive (true);
		False2.SetActive (true);
		False3.SetActive (true);
		PauseButton.SetActive (true);
		GamePanel.SetActive (false);
		Whack.SetActive (true);
		Em.SetActive (true);
		StartCoroutine (afterWhackEm (3.0f));
		Whack.SetActive (true);
		Em.SetActive (true);
		LevelSuccess.SetActive (true);
		LevelSuccess.GetComponent<Animator> ().enabled = false;

    }

	public void Notes(){
		PregameFrame.SetActive (false);
		NotesFrame.SetActive (true);

	}
	public void LevelFinish(){
        lvl4scene2.gameEnd = false;
        LevelSuccess.GetComponent<Animator> ().enabled = true;
        mscTriggers.PlaySingle(mscTriggers.audioClip[1]);
        finishWithStars = LevelSuccess.GetComponentInChildren<StarCountClass>().CountActive();
        StartCoroutine(gameNumbers.addstars(finishWithStars));
        Data.SaveData(levelIndex, true, finishWithStars);
        Questions.SetActive (false);
		Slider.SetActive (false);
		UpperFrame.SetActive (false);

	}

	public void NotesBack(){
		PregameFrame.SetActive (true);
		NotesFrame.SetActive (false);
	}
	public void Restart(string x){
        Time.timeScale = 1.0f;
		SceneManager.LoadScene (x);
	}
	public void Next(string x){
        if (!PlayerPrefs.HasKey("isFinished" + levelIndex.ToString()))
        {
            SceneManager.LoadScene("Map 1");
        }
        else
        {
            if (PlayerPrefsX.GetBool("isFinished" + levelIndex.ToString()))
            {
                Debug.Log("" + levelIndex);
                if (levelIndex == 27)
                {//finallevel
                    SceneManager.LoadScene("LEVELFINISH");
                }
                else
                {
                    SceneManager.LoadScene(x);
                }
            }
            else
            {
                SceneManager.LoadScene("Map 1");
            }
        }
    }
    public void enableGO(GameObject target)
    {
        target.SetActive(true);
        mscTriggers.PlaySingle(mscTriggers.audioClip[2]);
    }
	public void GoToThisScene(string x){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene (x);
	}


	public void Exit(){
        SceneManager.LoadScene("Map 1");
    }
	IEnumerator afterWhackEm(float sec){
		yield return new WaitForSeconds (sec);
		Slider.SetActive (true);
	}
}
