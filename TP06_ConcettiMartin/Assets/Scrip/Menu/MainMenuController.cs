using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    [Header("Sliders")]
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider sfxVolume;

    private void Awake()
    {

        musicVolume.onValueChanged.AddListener(SetMusicVolume);
        sfxVolume.onValueChanged.AddListener(SetSFXVolume);
    }

    private void Start()
    {
        //AudioManager.Instance.PlayMusic("Main music");
    }

    private void Destroy()
    {
        musicVolume.onValueChanged.RemoveListener(SetMusicVolume);
        sfxVolume.onValueChanged.RemoveListener(SetSFXVolume);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(sceneName: name);
    }

    public void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void DeActivatePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetMusicVolume(float value)
    {
       // AudioManager.Instance.MusicVolume(value);
    }

    public void SetSFXVolume(float value)
    {
        //AudioManager.Instance.SfxVolume(value);
    }

    public void Click()
    {
        //AudioManager.Instance.PlayEffect("Click");

    }
}