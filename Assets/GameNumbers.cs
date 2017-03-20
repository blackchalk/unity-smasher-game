using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNumbers : MonoBehaviour {

	public int achievement1;//18
	public int achievement2;//21
	public int achievement3;//24
	public int achievement4;//all stars
	public int currentStarCount;//current star in this level
	public int isFirstTime = 0;

	// Use this for initialization  
	void Start () {
		currentStarCount = PlayerPrefs.GetInt ("totalStars");
        if (currentStarCount > 44) {
            currentStarCount = 44;
        }

		isFirstTime = PlayerPrefs.GetInt ("isFirstTime");
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
		currentStarCount= currentStarCount+x;
		yield return new WaitForSeconds (0.1f);
		PlayerPrefs.SetInt ("totalStars", currentStarCount);
	}
		
}
