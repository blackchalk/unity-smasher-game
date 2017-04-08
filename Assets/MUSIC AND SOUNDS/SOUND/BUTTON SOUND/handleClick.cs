using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handleClick : MonoBehaviour {

	public bool isToggleButton;
	public Sprite originalSpr;
	public Sprite sprToChange;
	public Sprite sprOn;
	public Sprite sprOff;
	public GameObject target;
	public GameObject textOnOff;
	public bool isTargetChangingSpr;
	public string temp = "";
	public musicTriggers soundTriggers;

	void Start(){
		isToggleButton = true;
		soundTriggers = GameObject.Find ("SoundManager").GetComponentInChildren<musicTriggers> ();
		temp = textOnOff.name;
}

	public void clickItem ()
	{
		ToggleMode ();
	}

	void ToggleMode(){

		if(!isToggleButton){
			isToggleButton=true;	

			if (isTargetChangingSpr) {
				target.GetComponent<Image> ().sprite = originalSpr;
				textOnOff.GetComponent<Image> ().sprite = sprOn;
				soundTriggers.updateSoundSettings (temp, false);

			}
			return;
		}
		if(isToggleButton)
		{
			isToggleButton=false;	

			if (isTargetChangingSpr) {
				target.GetComponent<Image> ().sprite = sprToChange;
				textOnOff.GetComponent<Image> ().sprite = sprOff;
				soundTriggers.updateSoundSettings (temp, true);
			}
//			return;
		}
	}


}
