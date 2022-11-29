using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TextMeshProUGUI = TMPro.TextMeshProUGUI;
using UnityEngine;

public class MainSceneUIManager : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public bool timerIsRunning = false;
    public float maxTimeRemainning = 180f;
    
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    
    [SerializeField] public float timeRemainning = 180f;

    private void Awake()
    {
        timeRemainning = maxTimeRemainning;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemainning > 0)
            {
                timeRemainning -= Time.deltaTime;
                DisplayTime(timeRemainning);
            }
            else
            {
                timeRemainning = 0;
                timerIsRunning = false;
                GameOverMenuOn();
            }
        }

        PauseMenuOn();

    }
    
    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public void PauseMenuOn()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            timerIsRunning = false;
            Time.timeScale = 0;
        }
    }
    
    private void GameOverMenuOn()
    {
        gameOverMenu.SetActive(true);
        timerIsRunning = false;
        Time.timeScale = 0;
    }
    
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void BackToGame()
    {
        pauseMenu.SetActive(false);
        timerIsRunning = true;
        Time.timeScale = 1;
    }
}
