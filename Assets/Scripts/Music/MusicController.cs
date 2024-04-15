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
        audioSource.clip = coupleClip;
        audioSource.Play();
    }

    void PlayDiablo()
    {
        audioSource.clip = diabloClip;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        DiabloController.Instance.onBegin -= PlayDiablo;
        DiabloController.Instance.onStop -= PlayCouple;
    }
}