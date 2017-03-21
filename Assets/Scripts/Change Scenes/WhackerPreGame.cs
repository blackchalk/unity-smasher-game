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
    public float secondsToWait = 5.0f;
    public int finishWithStars = 0;
    private int levelIndex;
    private Scene scene;

    void Start(){
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        scene = SceneManager.GetActiveScene();
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
        Time.timeScale = 1.0f;
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
		LevelSuccess.GetComponent<Animator> ().enabled = true;
		Questions.SetActive (false);
		Slider.SetActive (false);
		UpperFrame.SetActive (false);

    }

	public void NotesBack(){
		PregameFrame.SetActive (true);
		NotesFrame.SetActive (false);
	}
	public void Restart(string x){
		SceneManager.LoadScene (x);
	}
	public void Next(string x){
        Debug.Log("im here:" + scene.name);
        if (scene.name.Equals("Level24Scene1MOD"))
        {
            GameObject.Find("EndGame").SetActive(true);
        }
        else
        {
            if (!PlayerPrefs.HasKey("isFinished" + scene.name))
            {
                Debug.Log("no playerprefs");
                SceneManager.LoadScene("Map 1");
            }
            else
           {
                if (PlayerPrefsX.GetBool("isFinished" + scene.name))
                {
                    Debug.Log("has playerprefs");
                    SceneManager.LoadScene(x);
                }
                else
                {
                    Debug.Log("no playerprefs-inner");
                    SceneManager.LoadScene("Map 1");
                }
            }
        }

    }
	public void GoToThisScene(string x){
		SceneManager.LoadScene (x);
	}


	public void Exit(){
		Application.Quit();
	}
	IEnumerator afterWhackEm(float sec){
		yield return new WaitForSeconds (sec);
		Slider.SetActive (true);
	}
}
