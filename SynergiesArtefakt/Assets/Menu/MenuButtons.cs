using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    private bool paused;
    public void OnPlayClicked()
    {
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }

    public void OnPowersClicked()
    {
        SceneManager.LoadScene("PowersScene", LoadSceneMode.Single);
    }

    public void OnSettingsClicked()
    {
        SceneManager.LoadScene("SettingsScene", LoadSceneMode.Single);
    }

    public void OnMenuClicked()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    public void OnPauseClicked()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
        }
        else
        {
            Time.timeScale = 1;
            paused = false;
        }
       
    }
}
