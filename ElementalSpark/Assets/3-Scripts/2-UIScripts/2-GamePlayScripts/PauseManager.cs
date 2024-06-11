using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject winPanel;
    public WinCondition winCondition;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        WinFunction();
    }

    private void WinFunction() 
    {
        if (winCondition.win)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void PauseButton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void QuitPauseButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1f;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ResetButton() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("EscenaBase");
    }

    
}
