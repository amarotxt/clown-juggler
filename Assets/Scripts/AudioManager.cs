using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	// Use this for initialization
	void Start () {
		foreach(Sound sound in sounds){
			sound.source = gameObject.AddComponent<AudioSource> ();
			sound.source.clip = sound.clip;
			sound.source.volume = sound.volume;
			sound.source.playOnAwake = false;
			sound.source.pitch = sound.pitch;
			Debug.Log (sound.source.isPlaying);
		}
	}
	public void Play (string name){
		Sound s = Array.Find (sounds, sound => sound.name == name);
		s.source.Play ();
	}

}
