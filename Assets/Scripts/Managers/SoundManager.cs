using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


public class SoundManager : MonoBehaviour {

    public AudioClip[] clackSounds = new AudioClip[4];
    public AudioClip levelUpSound;
    public AudioClip levelDownSound;

    void Start()
    {
        clackSounds[0] = (AudioClip)AssetDatabase.LoadAssetAtPath(ResourcePaths.clack1, typeof(AudioClip));
        clackSounds[1] = (AudioClip)AssetDatabase.LoadAssetAtPath(ResourcePaths.clack2, typeof(AudioClip));
        clackSounds[2] = (AudioClip)AssetDatabase.LoadAssetAtPath(ResourcePaths.clack3, typeof(AudioClip));
        clackSounds[3] = (AudioClip)AssetDatabase.LoadAssetAtPath(ResourcePaths.clack4, typeof(AudioClip));

        levelUpSound = (AudioClip)AssetDatabase.LoadAssetAtPath(ResourcePaths.levelUp, typeof(AudioClip));
        levelDownSound = (AudioClip)AssetDatabase.LoadAssetAtPath(ResourcePaths.levelDown, typeof(AudioClip));
    }

    public void playClackSound(AudioSource source)
    {
        source.PlayOneShot(clackSounds[Random.Range(0, clackSounds.Length)]);
    }

    public void playLevelUpSound(AudioSource source)
    {
        source.PlayOneShot(levelUpSound);
    }

    public void playLevelDownSound(AudioSource source)
    {
        source.PlayOneShot(levelDownSound);
    }
}
