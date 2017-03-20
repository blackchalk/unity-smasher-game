using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCountClass : MonoBehaviour {
	
	public GameObject[] targetGO;
	public int howManyStars=0;
    public int finishWithStars = 0;
    public GameObject LevelSuccess;


    void Start(){
        LevelSuccess = GameObject.Find("Success Frame");
    }
	void Update(){
//		CountActive ();
	}
	public int CountActive()
	{
		for (int i = 0; i < targetGO.Length; i++)
		{
			if (targetGO[i].activeSelf == true)
			{
				howManyStars++;
//				namesOfActive.Add(yourObjects[i].name);
			}
		}
		return howManyStars;
	}
}
