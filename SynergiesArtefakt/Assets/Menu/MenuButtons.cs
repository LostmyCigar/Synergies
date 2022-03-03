using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Sprite pause;
    [SerializeField] private Sprite play;
    [SerializeField] private Image pausePlay;
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
            pausePlay.sprite = play;
        }
        else
        {
            Time.timeScale = 1;
            paused = false;
            pausePlay.sprite = pause;
        }
       
    }
}
