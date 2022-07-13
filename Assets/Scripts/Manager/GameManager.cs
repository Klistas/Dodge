using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TimerText TimerTextUI;
    public GameOverUI GameOverUi;
    public GameObject Player;
    private bool _isOver;
  
    public void End()
    {
        TimerTextUI.IsOn = false;

        int savedBestTime = PlayerPrefs.GetInt("BestTime", 0);

        int bestTime = Math.Max((int)TimerTextUI.SurvivalTime,savedBestTime);

        if(bestTime < savedBestTime)
        {
            bestTime = savedBestTime;
        }

        PlayerPrefs.SetInt("BestTime", bestTime);

        GameOverUi.Activate(bestTime);

       _isOver = true;
    }

    private void Update()
    {
        if(Player.activeSelf == false)
        {
            End();
        }

        if(_isOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

}
