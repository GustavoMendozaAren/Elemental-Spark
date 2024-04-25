using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;

    public void PauseButton()
    {
        pausePanel.SetActive(true);
    }
    public void QuitPauseButton()
    {
        pausePanel.SetActive(false);
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

    
}
