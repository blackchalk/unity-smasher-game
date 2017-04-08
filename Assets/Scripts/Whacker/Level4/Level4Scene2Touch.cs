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
    //private WhackerPause whackerPause;
    public float secondsToWait;
    public bool allowClick = false;
    public bool startingGame = true;
	public Sprite answerTag;


    void Start(){
        allowTouch = true;
		mscTriggers = GameObject.Find ("SoundManager").GetComponent<musicTriggers> ();
        //whackerPause = GameObject.Find("LevelManager").GetComponent<WhackerPause>();
        allowClick = false;
	}

	void Update(){
		indexCount = lvl4scene2.counting;
		mscTriggers = GameObject.Find("SoundManager").GetComponent<musicTriggers>();

        // MARK: ONLY APPLY TO FIRST BATCH
        if (secondsToWait > 0)
        {
            secondsToWait = secondsToWait - Time.deltaTime;
            allowClick = false;
        }
        else
        {
            allowClick = true;
        }

		if (lvl4scene2.forceThemToChange==true && allowClick==true) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = answerTag;
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
					mscTriggers.PlaySingle (sfxclip [0]);
					ScoreManager.AddPoints (pointsToAdd);
					lvl4scene2.forceThemToChange = true;
					StartCoroutine(showIndicator (0.8f,true));
                }
                else if (gameObject.tag == "False")
                {
					mscTriggers.PlaySingle(sfxclip[1]);
					ScoreManager.AddPoints(pointsToAdd);
					HeartAndStars.MinusHeartAndStars(toBeDeducted);
					lvl4scene2.forceThemToChange = true;
					StartCoroutine(showIndicator (0.8f,false));
                }
            }
        }
	}
	IEnumerator showIndicator(float delay,bool tagToChange){

		yield return new WaitForSeconds (delay);
		lvl4scene2.forceThemToChange = false;
		if (tagToChange == true) {
			GameObject.Find ("Counter Slider").GetComponent<Level4Scene2> ().countDownNumber = 7f;
			GameObject.Find ("Counter Slider").GetComponent<Level4Scene2> ().timeBar.value = 7f;
			GameObject.Find ("Counter Slider").GetComponent<Level4Scene2> ().counting += 1;
			StartCoroutine(lvl4scene2.waitShowIndicator(0.1f));
		} else {
			GameObject.Find ("Counter Slider").GetComponent<Level4Scene2> ().countDownNumber = 7f;
			GameObject.Find("Counter Slider").GetComponent<Level4Scene2>().timeBar.value = 7f;
			GameObject.Find("Counter Slider").GetComponent<Level4Scene2>().counting += 1;
			StartCoroutine(lvl4scene2.waitShowIndicator(0.1f));
		}

	}
}
