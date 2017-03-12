using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))] //requires the script to have an audiosource into its gameobject-raygon

public class MusicManager : MonoBehaviour {


		public AudioClip[] clips;
		public int startingClip = 0;
		public int currentClip;
		public int nextClip;
		private bool isFadingOut=false;
		private float fadeOutTime = 1.0f;//
		private bool isFadingIn=false;//
		private float fadeInTime=1.0f;//
		private bool waitSequence = true;
		private bool keepTime = false;//
		private float targetVolume=1.0f;
		private float oldVolume=0.0f;//
		private float fadeOutStart=0.0f;//
		private float fadeInStart=0.0f;//

		// Use this for initialization
		void Start () {
		
			GetComponent<AudioSource> ().clip = clips[startingClip];
			GetComponent<AudioSource> ().Play();
			currentClip=startingClip;
		}

		// Update is called once per frame
		void Update () {


			if(isFadingOut){ //use for fadeinout
			if(GetComponent<AudioSource> ().volume>0){
					float elapsOut=Time.time-fadeOutStart;
					float indOut=elapsOut/fadeOutTime;
				GetComponent<AudioSource> ().volume=oldVolume-(indOut*oldVolume);
				}
			}else{
				isFadingOut = false;
				PlayMusic();
				StartCoroutine(PlayMusic());
			}
			if(isFadingIn){
			if(GetComponent<AudioSource> ().volume<targetVolume){
					float elapsIn=Time.time-fadeInStart;
					float indIn=elapsIn/fadeInTime;
				GetComponent<AudioSource> ().volume=indIn;
				}else{
				GetComponent<AudioSource> ().volume=targetVolume;
					isFadingIn=false;
				}
			}
		}
		public void ChangeMusic(int newClip,bool waitMusicToEnd,bool keepPreviousTime,float trackVolume,float fadein,float fadeOutPrevious)
		{ //sets the track number and if waits to end before playing next song -r
			nextClip = newClip;
			waitSequence = waitMusicToEnd;
			keepTime=keepPreviousTime;
			fadeInTime=fadein;
			if(newClip!=currentClip){
				currentClip=newClip;
				StartCoroutine(PlayMusic());
				if(fadeOutPrevious!=0){
				oldVolume=GetComponent<AudioSource> ().volume;
					fadeOutStart=Time.time;
					fadeOutTime=fadeOutPrevious;
					isFadingOut=true;
				}
				else{
					StartCoroutine(PlayMusic());
				}
			}
		}
		IEnumerator PlayMusic(){ //plays music
			if(waitSequence)
			yield return new WaitForSeconds(GetComponent<AudioSource> ().clip.length-(float)(GetComponent<AudioSource> ().timeSamples/(float)GetComponent<AudioSource> ().clip.frequency));//waits for the current track to finish before playing
			if(fadeInTime!=0){
			GetComponent<AudioSource> ().volume=0;
				fadeInStart=Time.time;
				isFadingIn=true;
			}
			float StartingPoint=0.0f;
			if(keepTime){
			StartingPoint=GetComponent<AudioSource> ().timeSamples;
			GetComponent<AudioSource> ().clip = clips[nextClip];
			GetComponent<AudioSource> ().timeSamples=Mathf.RoundToInt(StartingPoint);
			GetComponent<AudioSource> ().Play ();
				//			Debug.Log (""+clips[nextClip]);
			}
		}
}
