using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip coupleClip, diabloClip;
    
    
    void Start()
    {
        DiabloController.Instance.onBegin += PlayDiablo;
        DiabloController.Instance.onStop += PlayCouple;
    }

    void PlayCouple()
    {
        int exactTime = audioSource.timeSamples;
        audioSource.clip = coupleClip;
        audioSource.timeSamples = exactTime;

        audioSource.Play(); 
    }

    void PlayDiablo()
    {
        int exactTime = audioSource.timeSamples;
        audioSource.clip = diabloClip;
        audioSource.timeSamples = exactTime;

        audioSource.Play(); 
    }

    private void OnDestroy()
    {
        DiabloController.Instance.onBegin -= PlayDiablo;
        DiabloController.Instance.onStop -= PlayCouple;
    }
}