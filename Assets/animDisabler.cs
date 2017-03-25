using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animDisabler : MonoBehaviour {
	public unpaused disabler;
    public GameObject goCount;
	// Use this for initialization
	void Start () {
        disabler = GameObject.Find("Count").GetComponent<unpaused>();
        goCount = GameObject.Find("Count");
    }
	
	// Update is called once per frame
	void Update () {
    
        if (goCount.activeSelf == true)
            {
                if (disabler.begin == false)
                {   
                Debug.Log("pausing");
                    this.gameObject.GetComponent<Animator>().enabled = false;
                }
                if (disabler.begin == true)
                {
                Debug.Log("unpausing");
                this.gameObject.GetComponent<Animator>().enabled = true;
                }
            }
            else if (goCount.activeSelf == false || !goCount.GetComponent<unpaused>().isActiveAndEnabled || disabler==null)
           {
           }
	
	}

}
