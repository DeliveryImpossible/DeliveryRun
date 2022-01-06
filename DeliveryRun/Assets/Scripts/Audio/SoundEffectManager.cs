using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public const int rightGood = 1;
    public const int wrongGood = 2;
    public const int itemClick = 3;

    private AudioSource effectSource;
    public AudioClip audioRight;
    public AudioClip audioWrong;
    public AudioClip itemClickAudio;

    private void Start()
    {
        effectSource = GetComponent<AudioSource>();
    }
    public void OnEffectSound(int situation)
    {
        switch (situation)
        {
            case 1:
                effectSource.clip = audioRight;
                break;
            case 2:
                effectSource.clip = audioWrong;
                break;
            case 3:
                effectSource.clip = itemClickAudio;
                break;
        }
        effectSource.Play();
    }
}
