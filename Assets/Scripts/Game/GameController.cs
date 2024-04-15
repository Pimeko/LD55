using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    GameObject gameOverUI, gameOverTimerUi, victoryUI;
    [SerializeField]
    TimerController timerController;

    public Action onBeginSentence, onBeginAnswer, onGameOver, onVictory, onRestart;

    public void Restart()
    {
        gameOverTimerUi.SetActive(false);
        gameOverUI.SetActive(false);

        onRestart?.Invoke();

        DOTween.KillAll();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void RunGameOver(bool timer)
    {
        onGameOver?.Invoke();
        if (timer)
            gameOverTimerUi.SetActive(true);
        else
            gameOverUI.SetActive(true);
    }

    public void RunVictory()
    {
        onVictory?.Invoke();
        victoryUI.SetActive(true);
    }

    public void BeginSentence()
    {
        timerController.Stop();
        onBeginSentence?.Invoke();
    }

    public void BeginAnswer()
    {
        timerController.Begin();
        onBeginAnswer?.Invoke();
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}