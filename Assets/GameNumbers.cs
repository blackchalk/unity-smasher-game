using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scenemanagement;

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
        if (PlayerPrefs.HasKey("totalStars") == true && PlayerPrefs.GetInt("totalStars")!=0)
        {
            currentStarCount = PlayerPrefs.GetInt("totalStars");
        }
        else {
            PlayerPrefs.SetInt("totalStars", 0);
        }

        Debug.Log(currentStarCount);
  //      if (currentStarCount > 44) {
  //          currentStarCount = 44;
  //      }

		//isFirstTime = PlayerPrefs.GetInt ("isFirstTime"); 
	}
    void Update() {
	//object is of simpleton instance pattern; check it every time
	levelIndex = SceneManager.GetActiveScene().buildIndex;
        currentStarCount = PlayerPrefs.GetInt("totalStars");
        //if (currentStarCount > 44)
        //{
         //   currentStarCount = 44;
        //}
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
	var int p = 0; //previous
	var int q = x //recent
	var int sum = 0; //unique star to be added
		if(PlayerPrefs.HasKey("startsCount" + level.LevelIndex.ToString()))
		{
			p = PlayerPrefs.GetInt("startsCount"+ level.LevelIndex.ToString());
			//compare previous to recent collected stars recent>previous
			if(q>p)
			{
				//minus unique stars
				sum = q - p;
				currentStarCount = currentStarCount + sum;
				Debug.Log("adding :"+currentStarCount);
        			PlayerPrefs.SetInt("totalStars", currentStarCount);
			}
		}
        	yield return new WaitForSeconds (0.1f);
	}
}
