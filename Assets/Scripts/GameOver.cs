using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    public delegate void GameIsOver();

    public static GameIsOver gameOver;

    private void Start()
    {
        gameOver += ShowGameOverUI;
    }

    //  коли стейт гейм_овер викликати цей метод, через добавлення в інспекторі посилання на кнопку з цим методом тощо
    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void HideGameOverUI()
    {
        gameOverUI.SetActive(false);
    }
}
