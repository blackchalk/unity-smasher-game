using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
	public static int score;
	public Text text;
	public Text highScoreText;
	public int hiScoreCount;
    private int levelIndex;
    void Start () { 
       
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        text = GetComponent<Text> ();//score
		score = 0;
        hiScoreCount = PlayerPrefs.GetInt("highScoreCount" + levelIndex.ToString());
    }

	void Update () {
		if (score < 0) 
			score = 0;
			text.text = "" + score;//score

			//if (score > hiScoreCount) {
			//	hiScoreCount = score;
			//}

		highScoreText.text = "" + hiScoreCount;

		}


	public static void AddPoints(int pointsToAdd)
	{
		score += pointsToAdd;
	}

    public static void MinusPoints()
    {
        score += -20;
    }
    public void manageHighScoreData() {
        if (score > hiScoreCount)
        {
            hiScoreCount = score;
        }

        highScoreText.text = "" + hiScoreCount;

    }

}
