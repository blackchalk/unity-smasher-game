using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NotesFrameHandler : MonoBehaviour {

    private int counting;
    private Level4Scene2 lvl4scene2;
    public Sprite[] notesSpr = new Sprite[4];

    // Use this for initialization
    void Start () {
        counting = lvl4scene2.counting;
        this.gameObject.GetComponent<Image>().sprite = notesSpr[counting];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
