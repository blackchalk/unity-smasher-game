using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		offset = transform.position;
	}



	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = new Vector3(
			offset.x, player.transform.position.y + offset.y,
			offset.z);
	}
}
