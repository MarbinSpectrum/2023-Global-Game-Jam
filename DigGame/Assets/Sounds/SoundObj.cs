using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObj : MonoBehaviour
{
    [SerializeField]
    private AudioSource sound;
    [SerializeField]
    private bool playOnEable;

    private void OnEnable()
    {
        if (playOnEable)
            RunSE();
    }

    public void RunSE()
    {
        SoundManager.PlaySE(sound);
    }
}
