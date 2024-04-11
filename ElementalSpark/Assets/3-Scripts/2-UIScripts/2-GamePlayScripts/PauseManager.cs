using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;
    public void PauseButton()
    {
        // Invert the paused state
        isPaused = !isPaused;

        // Activate/deactivate the pause menu panel based on the paused state
        pausePanel.SetActive(isPaused);

        // If the game is paused, freeze time
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            // If the game is unpaused, resume time
            Time.timeScale = 1f;
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1f;
    }
}
