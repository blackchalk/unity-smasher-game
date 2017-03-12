using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour {
	public int objectHitDestroyer;

//	void OnCollisionEnter2D(Collision2D col)
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Right") 
		{
			Debug.Log ("hit correct :"+this.gameObject.name);
			HeartAndStars.MinusHeartAndStars (objectHitDestroyer);
			Destroy (col.gameObject);
		} 
		else if (col.gameObject.tag == "Wrong") 
		{
			Destroy (col.gameObject);
		}
	}
}
