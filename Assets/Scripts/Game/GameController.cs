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
    GameObject gameOverUI;

    public void RunGameOver()
    {
        gameOverUI.SetActive(true);
    }
}