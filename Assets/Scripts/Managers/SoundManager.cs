using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    public AudioClip[] clackSounds;
    public AudioClip levelUp;
    public AudioClip levelDown;
    public AudioClip combine;

    public void playClackSound(AudioSource source)
    {
        source.PlayOneShot(clackSounds[Random.Range(0, clackSounds.Length)]);
    }

    public void playLevelUpSound(AudioSource source)
    {
        source.PlayOneShot(levelUp);
    }

    public void playLevelDownSound(AudioSource source)
    {
        source.PlayOneShot(levelDown);
    }

    public void playCombineSound(AudioSource source)
    {
        source.PlayOneShot(combine);
    }
}
