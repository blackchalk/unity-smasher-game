using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class touchcount : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.touchCount > 0 || Input.GetMouseButton(0)) {
  //          GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
  //          foreach (GameObject go in allObjects)
  //              if (go.activeInHierarchy)
  //              {
  //                  Destroy(go);
  //              }
  //          SceneManager.LoadScene (2);
		//}
	}
    public void clickbutton(string scene2load)
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
            if (go.activeInHierarchy)
            {
                Destroy(go);
            }
        SceneManager.LoadScene(scene2load);
    }
}
