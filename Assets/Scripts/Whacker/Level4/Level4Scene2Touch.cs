using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level4Scene2Touch : MonoBehaviour {
	public int pointsToAdd;
	public int toBeDeducted;
	public Level4Scene2 lvl4scene2;
	public bool allowTouch;
	public int indexCount;
	public AudioClip[] sfxclip;
	private musicTriggers mscTriggers;
    private WhackerPause whackerPause;
    public float secondsToWait;
    public bool allowClick = false;
    public bool startingGame = true;


    void Start(){
        //secondsToWait = 3.0f;
        allowTouch = true;
		mscTriggers = GameObject.Find ("SoundManager").GetComponent<musicTriggers> ();
        whackerPause = GameObject.Find("LevelManager").GetComponent<WhackerPause>();
        allowClick = false;
	}

	void Update(){
		indexCount = lvl4scene2.counting;
		mscTriggers = GameObject.Find("SoundManager").GetComponent<musicTriggers>();

        // TODO: ONLY APPLY TO FIRST BAT
        if (secondsToWait > 0)
        {
            secondsToWait = secondsToWait - Time.deltaTime;
            allowClick = false;
        }
        else
        {
            allowClick = true;
        }
    }

	public void OnMouseOver()
	{
        if (Time.timeScale >= 1.0f && allowClick==true)
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (gameObject.tag == "True")
                {
                    mscTriggers.PlaySingle(sfxclip[0]); 
                    ScoreManager.AddPoints(pointsToAdd);
                    GameObject.Find("Counter Slider").GetComponent<Level4Scene2>().timeBar.value = 7f;
                    GameObject.Find("Counter Slider").GetComponent<Level4Scene2>().counting += 1;
                    lvl4scene2.changeQuestions(lvl4scene2.counting);
                    lvl4scene2.changeUpperFrameQuestions(lvl4scene2.counting);
                    //change question - sprites - animation
                    //				SceneManager.LoadScene ("Level4Scene3");

                }
                else if (gameObject.tag == "False")
                {
                    mscTriggers.PlaySingle(sfxclip[1]);
                    ScoreManager.AddPoints(pointsToAdd);
                    HeartAndStars.MinusHeartAndStars(toBeDeducted);
                    GameObject.Find("Counter Slider").GetComponent<Level4Scene2>().timeBar.value = 7f;
                    GameObject.Find("Counter Slider").GetComponent<Level4Scene2>().counting += 1;
                    lvl4scene2.changeQuestions(lvl4scene2.counting);
                    lvl4scene2.changeUpperFrameQuestions(lvl4scene2.counting);
                    //				SceneManager.LoadScene ("Level4Scene3");
                }
            }
        }
	}
}
