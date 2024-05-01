using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    
    public void ActiveSounds()
    {
        audioSource.Play();
    }

    public void StopSounds()
    {
        audioSource.Stop();
    }

    public void MuteSounds()
    {
        audioSource.mute = true;
    }

    public void UnmuteSounds()
    {
        audioSource.mute = false;
    }
}
