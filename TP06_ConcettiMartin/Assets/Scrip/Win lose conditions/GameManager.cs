using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static event Action ActivateGameOver;
    public static event Action ActivateWinGame;

    private void OnEnable()
    {
        PlayerHealth.OnGameOver += GameOver;
        Win.WinGame += WinGame;

    }
    private void OnDisable()
    {
        PlayerHealth.OnGameOver -= GameOver;
        Win.WinGame -= WinGame;

    }

    private void GameOver()
    {
        ActivateGameOver?.Invoke();
    }

    private void WinGame()
    {
        ActivateWinGame?.Invoke();
    }
}
