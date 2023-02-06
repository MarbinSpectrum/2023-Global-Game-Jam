using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : DontDestroySingleton<SoundManager>
{
    public AudioSource se;
    public AudioSource bgm;

    public static void PlayBGM(AudioClip pAudioClip)
    {
        instance.bgm.clip = pAudioClip;
        instance.bgm.Play();
    }

    public static void PlaySE(AudioClip pAudioClip)
    {
        instance.se.PlayOneShot(pAudioClip);
    }
}
