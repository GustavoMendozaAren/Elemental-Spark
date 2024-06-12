using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string nivel01Name;

    public void StartButton()
    {
        SceneManager.LoadScene(nivel01Name);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
