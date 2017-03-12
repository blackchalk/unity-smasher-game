using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapChangeScenes : MonoBehaviour {
	public int starCount,achievement1,achievement2,achievement3;
	public GameObject targetobj;
	public int targetnumbertounlock;
//	public string achievementToUnlock;
	public Sprite spr;
	void Start (){
		achievement1 = 18;
		achievement2 = 21;
		achievement3 = 24;
//		PlayerPrefs.SetInt ("totalStars", 18);
		starCount = PlayerPrefs.GetInt ("totalStars");
		handleSpriteImageStarsCount ();
	}

	public void Level1Button(string x){
		SceneManager.LoadScene (x);
	}

	public void Level2Button(){
		SceneManager.LoadScene ("Level2");
	}

	public void Level3Button(){
		SceneManager.LoadScene ("Level3");
	}

	public void Level4Button(){
		SceneManager.LoadScene ("Level4");
	}

	public void Level5Button(){
		SceneManager.LoadScene ("Level5");
	}

	public void Level6Button(){
		SceneManager.LoadScene ("Level6");
	}

	public void Level7Button(){
		SceneManager.LoadScene ("Level7");
	}

	public void Level8Button(){
		SceneManager.LoadScene ("Level8");
	}

	public void Level9Button(){
			SceneManager.LoadScene ("Level9");

	}

	public void Level10Button(){
		SceneManager.LoadScene ("Level10");
	}
	public void Level11Button(){
		SceneManager.LoadScene ("Level11");
	}

	public void Level12Button(){
		SceneManager.LoadScene ("Level12");
	}

	public void Level13Button(){
		SceneManager.LoadScene ("Level13");
	}

	public void Level14Button(){
		SceneManager.LoadScene ("Level14");
	}

	public void Level15Button(){
		SceneManager.LoadScene ("Level15");
	}

	public void Level16Button(){
		SceneManager.LoadScene ("Level16");
	}

	public void Level17Button(){
		SceneManager.LoadScene ("Level17");
	}

	public void Level18Button(){
		SceneManager.LoadScene ("Level18");
	}

	public void Level19Button(){
		SceneManager.LoadScene ("Level19");
	}

	public void Level20Button(){
		SceneManager.LoadScene ("Level20");
	}

	public void Level21Button(){
		SceneManager.LoadScene ("Level21");
	}

	public void Level22Button(){
		SceneManager.LoadScene ("Level22");
	}

	public void Level23Button(){
		SceneManager.LoadScene ("Level23");
	}

	public void Level24Button(){
		SceneManager.LoadScene ("Level24");
	}
	public void handleSpriteImageStarsCount(){
		if (starCount >= targetnumbertounlock) {
			targetobj.GetComponent<Image> ().sprite = spr;
		}
	}
}
