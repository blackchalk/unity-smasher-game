using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animDisabler : MonoBehaviour {
	public unpaused disabler;

	// Use this for initialization  
	void Start () {
        disabler = GameObject.Find("Count").GetComponent<unpaused>();
    }
	
	// Update is called once per frame
	void Update () {
    
        if (disabler.isActiveAndEnabled == true)
            {
                if (disabler.begin == false)
                {   
                //Debug.Log("pausing");
                    this.gameObject.GetComponent<Animator>().enabled = false;
                }
                if (disabler.begin == true)
                {
                //Debug.Log("unpausing");
                this.gameObject.GetComponent<Animator>().enabled = true;
                }
            }
            else
           {
           }
	
	}

}
