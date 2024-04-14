using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region SINGLETON
    public static GameController Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
    }
    #endregion

    [SerializeField]
    GameObject gameOverUI, gameOverTimerUi;
    [SerializeField]
    TimerController timerController;

    public void RunGameOver(bool timer)
    {
        if (timer)
            gameOverTimerUi.SetActive(true);
        else
            gameOverUI.SetActive(true);
    }

    public void BeginTimer()
    {
        timerController.Begin();
    }

    public void StopTimer()
    {
        timerController.Stop();
    }
}