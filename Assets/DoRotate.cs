using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoRotate : MonoBehaviour {

	public float rotateSpeed;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		RotateLeft ();
	}
	void RotateLeft () {
		transform.Rotate (Vector3.forward*rotateSpeed*-90);
	}
}
