using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostAndPreGameChangeScenes : MonoBehaviour {


	public GameObject UpperFrame;
	public GameObject Paused;
	public GameObject Slider;
	public GameObject Right;
	public GameObject Wrong;
    private int levelIndex;

	void Awake(){
		UpperFrame = GameObject.Find ("Upper Frame");
		Paused = GameObject.Find ("Pause Button");
		Slider = GameObject.Find ("Counter Slider");
		Right = GameObject.Find ("Right");
		Wrong = GameObject.Find ("Wrong");
	}
    void Start()
    {

        levelIndex = Application.loadedLevel;
    }

	public void Map(){
		SceneManager.LoadScene ("Map 1");
	}
	//dynamic scene change
	public void Restart(string x){
		SceneManager.LoadScene (x);
	}

	public void NextLevel(string x){
		//Debug.Log ("hit");
        
        if (!PlayerPrefs.HasKey("isFinished" + levelIndex.ToString()))
        {
            SceneManager.LoadScene("Map 1");
        }else
        {
            if (PlayerPrefsX.GetBool("isFinished" + levelIndex.ToString()))
            {
                SceneManager.LoadScene(x);
            }else {
                SceneManager.LoadScene("Map 1");
            }
        }
	}
}
