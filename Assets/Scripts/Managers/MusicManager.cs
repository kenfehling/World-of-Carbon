using UnityEngine;
using UnityEditor;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public bool debugControls;

    private AudioClip[] clips = new AudioClip[3];
    private AudioSource source1, source2;
    private int currentClipIndex;
    
	void Start () {
        //Music clips
        clips[0] = (AudioClip)AssetDatabase.LoadAssetAtPath(ResourcePaths.song1, typeof(AudioClip));
        clips[1] = (AudioClip)AssetDatabase.LoadAssetAtPath(ResourcePaths.song2, typeof(AudioClip));
        clips[2] = (AudioClip)AssetDatabase.LoadAssetAtPath(ResourcePaths.song3, typeof(AudioClip));

        //Audio sources
        source1 = gameObject.AddComponent<AudioSource>();
        source2 = gameObject.AddComponent<AudioSource>();

        source1.clip = clips[0];
        source2.clip = clips[0];

        source1.loop = false;
        source2.loop = false;

        source1.Play();
        source2.PlayDelayed(source1.clip.length);
    }
	
	void Update () {
        if (debugControls)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                moveDownLayer();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                moveUpLayer();
            }
        }

        if (!source1.isPlaying)
        {
            source1.clip = clips[currentClipIndex];
            source1.PlayDelayed(source2.clip.length);
        }

        if (!source2.isPlaying)
        {
            source2.clip = clips[currentClipIndex];
            source2.PlayDelayed(source1.clip.length);
        }
	}

    void updateQueuedClip()
    {
        if (source1.time == 0)
        {
            source1.clip = clips[currentClipIndex];
            source1.PlayDelayed(source2.clip.length - source2.time);
        }
        else
        {
            source2.clip = clips[currentClipIndex];
            source2.PlayDelayed(source1.clip.length - source1.time);
        }
    }

    public void moveDownLayer()
    {
        if (currentClipIndex == clips.Length - 1)
        {
            currentClipIndex = 0;
        }
        else
        {
            ++currentClipIndex;
        }
        updateQueuedClip();
    }

    public void moveUpLayer()
    {
        if (currentClipIndex == 0)
        {
            currentClipIndex = clips.Length - 1;
        }
        else
        {
            --currentClipIndex;
        }
        updateQueuedClip();
    }
}
