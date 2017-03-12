using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WhackerChanges : MonoBehaviour {

	public void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if (gameObject.tag == "Level1") 
			{
				SceneManager.LoadScene("Level4Scene2");
			}
			else if (gameObject.tag == "Level2")
			{
				SceneManager.LoadScene("Level4Scene3");
			}
			else if (gameObject.tag == "Level3")
			{
				SceneManager.LoadScene("Level4Scene4");
			}
			else if (gameObject.tag == "Level4")
			{
				SceneManager.LoadScene("Level4Scene5");
			}
			else if (gameObject.tag == "Level5")
			{
				SceneManager.LoadScene("Congrats");
			}
			else if (gameObject.tag == "Wrong")
			{
				SceneManager.LoadScene ("GameOver");
			}
		}
	}
}
