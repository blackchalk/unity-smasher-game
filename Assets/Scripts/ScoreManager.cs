using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {
	public static int score;
	public Text text;
	public Text highScoreText;
	public float hiScoreCount;

	void Start () {
		text = GetComponent<Text> ();
		score = 0;
	}

	void Update () {
		if (score < 0) 
			score = 0;
			text.text = "" + score;

			if (score > hiScoreCount) {
				hiScoreCount = score;
			}
		highScoreText = this.gameObject.GetComponent<Text> ();
//			highScoreText.text = "" + hiScoreCount;
		highScoreText.text = "" +score;

		}


	public static void AddPoints(int pointsToAdd)
	{
		score += pointsToAdd;
	}


}
