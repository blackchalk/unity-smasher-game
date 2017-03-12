using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicTriggers : MonoBehaviour {

	public bool waitForSequence=false;
	public bool keepTimeAndVolume=false;
	public float trackVolume;
	public float fadeIn;
	public float fadeOutPrevious;
	public int clip;
	public string playInScene;
	private MusicManager bgmusic;

	//soundeffects
	public AudioSource efxSound;
	public bool isMusicOff;
	public bool isEffectsOff;

	void Awake(){
		bgmusic=this.gameObject.GetComponent<MusicManager>();

	}
	// Use this for initialization
	void Start () {
		isMusicOff = false;
		isEffectsOff = false;
}
	// Update is called once per frame

	void Update () {

		playInScene=Application.loadedLevelName;
		Debug.Log("playInScene:"+playInScene);
		if(playInScene=="Map"||playInScene=="Main"){	
			clip=0;
			bgmusic.ChangeMusic(clip,waitForSequence,keepTimeAndVolume,trackVolume,fadeIn,fadeOutPrevious);
		}
		if(playInScene=="Level1"||playInScene=="Level2-mod"||playInScene=="Level3-mod"||
			playInScene=="Level4Scene1MODMOD"||playInScene=="Level5MOD"||playInScene=="Level6MOD"||
			playInScene=="Level7MOD"||playInScene=="Level8Scene1MOD"){
			clip=1;
			bgmusic.ChangeMusic(clip,waitForSequence,keepTimeAndVolume,trackVolume,fadeIn,fadeOutPrevious);
		}
		if(playInScene=="Level9MOD"||playInScene=="Level10MOD"||playInScene=="Level11MOD"||
			playInScene=="Level12Scene1MOD"||playInScene=="Level13MOD"||playInScene=="Level14MOD"||
			playInScene=="Level5MOD"||playInScene=="Level16Scene1MOD"){
			clip=2;
			bgmusic.ChangeMusic(clip,waitForSequence,keepTimeAndVolume,trackVolume,fadeIn,fadeOutPrevious);
		}
		if(playInScene=="Level17MOD"||playInScene=="Level18MOD"||playInScene=="Level19MOD"||
			playInScene=="Level20Scene1MOD"||playInScene=="Level21MOD"||playInScene=="Level22MOD"||
			playInScene=="Level23MOD"||playInScene=="Level24Scene1MOD"){
			clip=3;
			bgmusic.ChangeMusic(clip,waitForSequence,keepTimeAndVolume,trackVolume,fadeIn,fadeOutPrevious);
		}
		if(playInScene=="Storyline"){
//			clip=4;
//			bgmusic.ChangeMusic(clip,waitForSequence,keepTimeAndVolume,trackVolume,fadeIn,fadeOutPrevious);
		}


		//handle sounds
		if (isMusicOff) {
			this.gameObject.GetComponent<AudioSource> ().volume = 0;
		} else {
			this.gameObject.GetComponent<AudioSource> ().volume = 1;
		}

		if (isEffectsOff) {
			efxSound.volume = 0;
		} else {
			efxSound.volume = 1;
		}

	}

	//Used to play single sound clips.
	public void PlaySingle(AudioClip clip)
	{
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		efxSound.clip = clip;

		//Play the clip.
		efxSound.Play ();
	}

	public void updateSoundSettings(string musicORsound,bool value){

		if (musicORsound == "musicOn") {
			isMusicOff = value;
		}
		if (musicORsound == "soundOn") {
			isEffectsOff = value;
		}
	}

}