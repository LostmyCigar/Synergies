using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
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

    public void OnPauseClicked()
    {
        Time.timeScale = 0;
    }
}
