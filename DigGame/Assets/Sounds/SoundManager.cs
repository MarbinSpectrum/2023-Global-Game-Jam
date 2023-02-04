using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : DontDestroySingleton<SoundManager>
{
    public AudioClip se;

    public static void PlaySE(AudioSource pAudioSource)
    {
        pAudioSource.PlayOneShot(instance.se);
    }
}
