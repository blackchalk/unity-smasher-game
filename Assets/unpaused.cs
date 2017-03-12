using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unpaused : MonoBehaviour {
	public Sprite spr;
	public bool begin;
	public float secondTowait;
	private Coroutine coroutine;
	void Start () {
		begin = false;


	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (this.gameObject.GetComponent<Image> ().sprite == spr) {
			StartCoroutine (someSecondsMore(1f));
		
		} else {
			StopCoroutine ("someSecondsMore");
			begin = false;

		}
	}

	private IEnumerator someSecondsMore(float waitTime){
		yield return new WaitForSeconds (waitTime);
		begin = true;
	}
}
