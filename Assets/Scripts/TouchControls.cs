using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TouchControls : MonoBehaviour {
	
	private musicTriggers mscTrigger;
	public Sprite spr;
	public int pointsToAdd;
	public int counterToAdd;
	public int toBeDeducted;
	private IEnumerator cor;
	public int didHit = 0;
	public AudioClip[] sfxClip;

    public bool singleTap = false;
    public bool doubleTap = false;

    bool tapping = false;
    float tapTime = 0;
    float duration = .4f;


    void Start(){
//		cor = doTransitionOfSprite;
		mscTrigger = GameObject.Find("SoundManager").GetComponent<musicTriggers>();
	}
	void Update(){
		mscTrigger = GameObject.Find("SoundManager").GetComponent<musicTriggers>();
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (tapping)
        //    {
        //        doubleTap = true;
        //        Debug.Log("DoubleTap");
        //        tapping = false;
        //    }
        //    else
        //    {
        //        tapping = true;
        //        tapTime = duration;

        //    }
        //}
        //if (tapping)
        //{
        //    tapTime = tapTime - Time.deltaTime;
        //    if (tapTime <= 0)
        //    {
        //        tapping = false;
        //        singleTap = true;
        //        Debug.Log("SingleTap");
        //    }
        //}
    }

    public void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //if (tapping)
            //{
            //    doubleTap = true;
            //    Debug.Log("DoubleTap");
            //    tapping = false;
            //}
            //else
            //{
            //    tapping = true;
            //    tapTime = duration;

            //}


           // if (singleTap && !gameObject.name.Contains("ggg"))
           // {

                if (gameObject.tag == "Right")
                {
                    mscTrigger.PlaySingle(sfxClip[0]);
                    ScoreManager.AddPoints(pointsToAdd);
                    this.gameObject.GetComponent<Animator>().enabled = false;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = spr;
                    Counter.AddCounter(counterToAdd);
                    StartCoroutine(doTransitionOfSprite());


                }
                else if (gameObject.tag == "Wrong")
                {
                    mscTrigger.PlaySingle(sfxClip[1]);
                    ScoreManager.AddPoints(pointsToAdd);
                    this.gameObject.GetComponent<Animator>().enabled = false;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = spr;
                    HeartAndStars.MinusHeartAndStars(toBeDeducted);
                    StartCoroutine(doTransitionOfSprite());
                }
            //}
            //if (doubleTap && gameObject.name.Contains("ggg"))
           // {
              //  Debug.Log("catch");

                if (gameObject.tag == "Right")
                {
                    mscTrigger.PlaySingle(sfxClip[0]);
                    ScoreManager.AddPoints(pointsToAdd);
                    this.gameObject.GetComponent<Animator>().enabled = false;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = spr;
                    Counter.AddCounter(counterToAdd);
                    StartCoroutine(doTransitionOfSprite());


                }
                else if (gameObject.tag == "Wrong")
                {
                    mscTrigger.PlaySingle(sfxClip[1]);
                    ScoreManager.AddPoints(pointsToAdd);
                    this.gameObject.GetComponent<Animator>().enabled = false;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = spr;
                    HeartAndStars.MinusHeartAndStars(toBeDeducted);
                    StartCoroutine(doTransitionOfSprite());
                }
           // }

        }

    }
    IEnumerator doTransitionOfSprite(){
		yield return new WaitForSeconds (0.4f);
		Destroy (gameObject);
	}
}
