﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

	private static Singleton _instance;

	public static Singleton instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<Singleton>();

				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}

			return _instance;
		}
	}

	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}
}
