using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Player : MonoBehaviour
{
    [SerializeField]
    private AudioClip sound;
    [SerializeField]
    private bool playOnEable;

    private void OnEnable()
    {
        if (playOnEable)
            RunBGM();
    }

    public void RunBGM()
    {
        SoundManager.PlayBGM(sound);
    }
}
