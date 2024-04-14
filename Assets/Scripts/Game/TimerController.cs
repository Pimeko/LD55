using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    GameObject container;
    [SerializeField]
    Image image;
    [SerializeField]
    float duration;
    

    float elapsedTime;
    bool isRunning;

    void Start()
    {
        Stop();
    }

    public void Begin()
    {
        container.SetActive(true);
        elapsedTime = 0;
        isRunning = true;
    }

    public void Stop()
    {
        container.SetActive(false);
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            float amount = (duration - elapsedTime) / duration;
            amount = Math.Max(amount, 0);
            image.fillAmount = amount;
            if (amount == 0)
            {
                GameController.Instance.RunGameOver(true);
            }
        }
    }
}