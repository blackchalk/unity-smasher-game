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
		currentStarCount = currentStarCount + x;
        Debug.Log("adding :"+currentStarCount);
        PlayerPrefs.SetInt("totalStars", currentStarCount);
        yield return new WaitForSeconds (0.1f);
		//PlayerPrefs.SetInt ("totalStars", currentStarCount);
        //Debug.Log("successfully added star"+currentStarCount);
	}
		
}
