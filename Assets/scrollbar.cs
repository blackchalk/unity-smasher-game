using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollbar : MonoBehaviour {
	
	public Scrollbar bar; 
	public int isFirstTime = 0;
	public bool bottom;
	public int runonce;
	// Use this for initialization
	void Start () {
		bottom = false;
		runonce = 0;
		bar = this.gameObject.GetComponent<Scrollbar> ();
		bar.value = 1;
		Time.timeScale = 0.5f;

		isFirstTime = PlayerPrefs.GetInt("isFirstRun");

	}
	
	// Update is called once per frame
	void Update () {
		if (isFirstTime == 0) {
			if (!bottom && runonce == 0) {
				bar.value -= 0.2f * Time.deltaTime;
				if (bar.value == 0.0f) {
					bottom = true;
				}
			} else {
				bar.value += 0.2f * Time.deltaTime;
				if (bar.value == 1f) {

					if (isFirstTime == 0) {
						isFirstTime = 1;
						PlayerPrefs.SetInt("isFirstRun", isFirstTime);
					} else {
						//do nothing here
					}
					bottom = false;
					runonce = 1;
					Destroy (this);
				}
			}

		} else {
			Destroy (this);
		}


		}
	public IEnumerator wait()
	{
		yield return new WaitForSeconds(0.1f);
		Debug.Log ("Run");
	}
}
