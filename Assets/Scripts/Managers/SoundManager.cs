using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public enum Sounds {
		Flick,
		Reaction
	}

	private Dictionary<Sounds, AudioClip> soundSamples;
	// private Dictionary<Sounds, Effect> soundEffects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySound(Sounds index) {
		//source = soundSamples[index];
		//effects = soundEffects[index];
		//source.apply(effects);
		//source.playOnce();
	}
}
