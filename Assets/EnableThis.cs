using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableThis : MonoBehaviour {
    public float secondsToDisable;
	// Use this for initialization
	void Start () {
		

	}
    void Update() {
        if (this.gameObject.activeInHierarchy){
            if (secondsToDisable < 0f)
            {

                this.gameObject.SetActive(false);
                // Destroy(this.gameObject);
            }
            else
            {
                secondsToDisable -= Time.deltaTime;
            }
        }

    }
    public void enableHelpAndDestroy()
    {
        this.gameObject.SetActive(true);

    }

}   
