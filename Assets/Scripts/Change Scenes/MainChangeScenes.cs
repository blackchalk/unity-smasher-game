using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainChangeScenes : MonoBehaviour {

	public GameObject AchievementsButton;
	public GameObject AchievementFrame;
	public GameObject SettingsButton;
	public GameObject SettingsFrame;
	public GameObject ExitButton;
	public GameObject ExitFrame;
	public GameObject HelpButton;
	public GameObject HelpFrame;
	public GameObject NumberSmasher;
	public GameObject creditsFrame;
//	public Slider Timer;
	public float startingTime;
	public string x;


	void Start(){
//		Timer = GetComponent<Slider> ();
		x = SceneManager.GetActiveScene().name;
	}
	void Update(){
		
		if (x.Equals("Main")||x.Equals("Map")||x.Equals("Storyline")) {
			
//			Debug.Log ("main or map scene");
		} else {
			startingTime -= Time.deltaTime;
			Debug.Log (startingTime);
			if (startingTime <= 0.0f) {
				Debug.Log ("timer ended");
				SceneManager.LoadScene ("Main");
			}
		}
	
	}
	


	public void PlayButton(){
		SceneManager.LoadScene ("Map");
	}

	public void Achievement(){
		AchievementFrame.SetActive (true);
		AchievementsButton.SetActive (false);
		SettingsButton.SetActive (false);
		ExitButton.SetActive (false);
		HelpButton.SetActive (false);
		NumberSmasher.SetActive (false);
	}
	public void showCredits(){
		AchievementsButton.SetActive (false);
		SettingsButton.SetActive (false);
		ExitButton.SetActive (false);
		HelpButton.SetActive (false);
		AchievementsButton.SetActive (false);
		creditsFrame.SetActive (true);
	}

	public void BackAchievement(){
		creditsFrame.SetActive(false);
		AchievementFrame.SetActive (false);
		AchievementsButton.SetActive (true);
		SettingsButton.SetActive (true);
		SettingsFrame.SetActive (false);
		ExitButton.SetActive (true);
		HelpButton.SetActive (true);
		NumberSmasher.SetActive (true);
	}

    public void BackCredits()
    {
        creditsFrame.SetActive(false);
        SettingsFrame.SetActive(true);
    }


    public void Settings (){
		SettingsFrame.SetActive (true);
		SettingsButton.SetActive (false);
		AchievementsButton.SetActive (false);
		ExitButton.SetActive (false);
		HelpButton.SetActive (false);
		NumberSmasher.SetActive (false);
	}

	public void BackSettings(){
		SettingsFrame.SetActive (false);
		SettingsButton.SetActive (true);
		AchievementsButton.SetActive (true);
		ExitButton.SetActive (true);
		HelpButton.SetActive (true);
		NumberSmasher.SetActive (true);
	}

	public void Exit(){
		ExitFrame.SetActive (true);
		ExitButton.SetActive (false);
		AchievementsButton.SetActive (false);
		SettingsButton.SetActive (false);
		HelpButton.SetActive (false);
		NumberSmasher.SetActive (false);
	}

	public void PlayOn(){
		NumberSmasher.SetActive (true);
		ExitFrame.SetActive (false);
		ExitButton.SetActive (true);
		AchievementsButton.SetActive (true);
		HelpButton.SetActive (true);
		SettingsButton.SetActive (true);

	}
	public void Help(){
		HelpFrame.SetActive (true);
		HelpButton.SetActive (false);
		AchievementsButton.SetActive (false);
		SettingsButton.SetActive (false);
		ExitButton.SetActive (false);
		HelpButton.SetActive (false);
		NumberSmasher.SetActive (false);
	
	}
	public void goHome(){
		SceneManager.LoadScene ("Main");
	}

	public void exitGame(){
		Application.Quit ();
	}

		
}
