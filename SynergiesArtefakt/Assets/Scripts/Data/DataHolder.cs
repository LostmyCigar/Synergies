using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataHolder : MonoBehaviour
{
    public List<GameObject> ballEffectIcons = new List<GameObject>();
    public List<BallEffect> ballEffects = new List<BallEffect>();


    public BallEffect effect1;
    public BallEffect effect2;

    [SerializeField] private Transform panel;
    private PowerHolder powerHolder;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        powerHolder = GetComponentInChildren<PowerHolder>();

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "PowersScene")
        {
            panel = GameObject.Find("Canvas").transform.Find("Effects").Find("NonActive").Find("Panel");

            for (int i = 0; i < ballEffectIcons.Count; i++)
            {
                Instantiate(ballEffectIcons[i], panel);
            }
        }

        if (sceneName == "PlayScene")
        {
            powerHolder.UpdateOnPlayScene();
        }
    } 

    public void EquippEffect(int slott, string effect)
    {
        for (int i = 0; i < ballEffects.Count; i++)
        {
            if (ballEffects[i].effectName == effect)
            {
                if (slott == 1)
                {
                    effect1 = ballEffects[i];
                }
                else
                {
                    effect2 = ballEffects[i];
                }
                break;
            }
        }
    }

    public void UnEquippEffect(int slott)
    {
        if (slott == 1)
        {
            effect1 = null;
        }
        else
        {
            effect2 = null;
        }
    }
}
