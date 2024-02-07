using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource audio;

    public void PlaySound(AudioClip clip)
    {
    }
}
