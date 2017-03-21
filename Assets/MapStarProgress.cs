using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapStarProgress : MonoBehaviour {

    public Text textStarCount;
    public Text textAchievement;
    private GameNumbers gameNumbers;

	// Use this for initialization
	void Start () {
        gameNumbers = GameObject.Find("Gameplay").GetComponent<GameNumbers>();
        textStarCount.text = ""+gameNumbers.currentStarCount;

        if (gameNumbers.currentStarCount >= 18 && gameNumbers.currentStarCount < 21)
        {
            textAchievement.text = "1";
        }
        else if (gameNumbers.currentStarCount >= 21 && gameNumbers.currentStarCount < 24)
        {
            textAchievement.text = "2";
        }
        else if (gameNumbers.currentStarCount >= 24 && gameNumbers.currentStarCount < 44)
        {
            textAchievement.text = "3";
        }
        else if (gameNumbers.currentStarCount >= 44)
        {
            textAchievement.text = "4";
        }
        else {
            textAchievement.text = "0";
        }

    }
    void Update() {
        textStarCount.text = "" + gameNumbers.currentStarCount;

        if (gameNumbers.currentStarCount >= 18 && gameNumbers.currentStarCount < 21)
        {
            textAchievement.text = "1";
        }
        else if (gameNumbers.currentStarCount >= 21 && gameNumbers.currentStarCount < 24)
        {
            textAchievement.text = "2";
        }
        else if (gameNumbers.currentStarCount >= 24 && gameNumbers.currentStarCount < 44)
        {
            textAchievement.text = "3";
        }
        else if (gameNumbers.currentStarCount >= 44)
        {
            textAchievement.text = "4";
        }
        else
        {
            textAchievement.text = "0";
        }
    }
	
    public void goToScene(string x)
    {
        SceneManager.LoadScene(x);
        
    }
}
