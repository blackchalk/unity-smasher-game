using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameNumbers : MonoBehaviour {

	public int achievement1;//18
	public int achievement2;//21
	public int achievement3;//24
	public int achievement4;//all stars
	public int currentStarCount;//current star in this level
	public int isFirstTime = 0;
    private int levelIndex;
    // Use this for initialization
    void Start () {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        currentStarCount = PlayerPrefs.GetInt ("totalStars");
		isFirstTime = PlayerPrefs.GetInt ("isFirstTime");
	}
    void Update() {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        currentStarCount = PlayerPrefs.GetInt("totalStars");
    }


	public void setPrefstoZero(string title){
		PlayerPrefs.SetInt (title, 0);
	}

	public void saveAchievementToPrefs(string title,int value){
		PlayerPrefs.SetInt (title, value);
	}
	public int getAchievementPrefs(string title){
		int x =	PlayerPrefs.GetInt(title);
		return x;
	}
	public IEnumerator addstars(int x){
        //validate if stars have been acquired before
        int p = 0; //previous
        int q = x; //recent
        int sum = 0; //unique star to be added
        Debug.Log("star/s to be added :" + q);
        if (PlayerPrefs.HasKey("startsCount" + levelIndex.ToString()))
        {
            p = PlayerPrefs.GetInt("startsCount" + levelIndex.ToString());
            Debug.Log(q+"entering with previous:"+p);
            //compare previous to recent collected stars recent>previous
            if (q > p)
            {
                //minus unique stars
                sum = q - p;
                Debug.Log(p + "star/s added :" + sum);
                currentStarCount = currentStarCount + sum;
                Debug.Log("totalstars :" + currentStarCount);
                PlayerPrefs.SetInt("totalStars", currentStarCount);
                yield return new WaitForSeconds(0.1f);
            }
        }
        else {
            Debug.Log("returning false");
            PlayerPrefs.SetInt("totalStars", q);
        }
        
    }
}

