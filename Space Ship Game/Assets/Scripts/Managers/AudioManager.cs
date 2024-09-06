using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //AudioManager instance
    public static AudioManager instance;

    private AudioSource audioSource;

    public AudioClip[] audioClips;

    public AudioClip audioClip;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }

    //Trigger Fire Sound Effect when player shoots
    public void PlayFireSound(string audio)
    {
        //Search for the audio clip in the audioClips array with the name of the audio
        for (int i = 0; i < audioClips.Length; i++)
        {
            if (audioClips[i].name == audio)
            {
                audioClip = audioClips[i];
            }
        }

        //if the audio clip is not found, return
        if (audioClip == null)
        {
            return;
        }
        audioSource.clip = audioClip;
        audioSource.PlayOneShot(audioClip);
        audioClip = null;
    }
}
