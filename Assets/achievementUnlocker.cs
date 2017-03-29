using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achievementUnlocker : MonoBehaviour {

	public GameObject lock1;
	public GameObject lock2;
	public GameObject lock3;
	public GameObject lock4;
	public GameObject mGameNumbers;
	private GameNumbers mgn;

	void Awake(){
        mGameNumbers = GameObject.Find("GameManager");
		mgn = mGameNumbers.GetComponentInChildren<GameNumbers>(); 
		lock1.SetActive (true);
		lock2.SetActive (true);
		lock3.SetActive (true);
		lock4.SetActive (true);
	}
	// Use this for initialization
	void Start () {
		
		if (mgn.currentStarCount >= 18) {
			lock1.SetActive (false);
		}
		if (mgn.currentStarCount >= 39) {
			lock2.SetActive (false);
		}
		if (mgn.currentStarCount >= 63) {
			lock3.SetActive (false);
		}
		if (mgn.currentStarCount >= 72) {
			lock4.SetActive (false);
		}


	}
	

}
