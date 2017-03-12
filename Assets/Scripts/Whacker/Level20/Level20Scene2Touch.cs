﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level20Scene2Touch : MonoBehaviour {
	public int pointsToAdd;

	public void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if (gameObject.tag == "True") 
			{
				ScoreManager.AddPoints (pointsToAdd);
				SceneManager.LoadScene ("Level20Scene3");
			}
			else if (gameObject.tag == "False")
			{
				ScoreManager.AddPoints (pointsToAdd);
				SceneManager.LoadScene ("Level20Scene3");
			}
		}
	}
}
