using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level12Scene1Touch : MonoBehaviour {
	public int pointsToAdd;

	public void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if (gameObject.tag == "True") 
			{
				ScoreManager.AddPoints (pointsToAdd);
				SceneManager.LoadScene ("Level12Scene2");
			}
			else if (gameObject.tag == "False")
			{
				ScoreManager.AddPoints (pointsToAdd);
				SceneManager.LoadScene ("Level12Scene2");
			}
		}
	}
}
