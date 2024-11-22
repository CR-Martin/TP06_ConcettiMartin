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
    [SerializeField] private Slider uiVolume;

    [Header("Player prefs")]
    [SerializeField] private string musicVolumePref = "musicVolume";
    [SerializeField] private string effectVolumePref = "effectVolume";
    [SerializeField] private string uiVolumePref = "uiVolume";

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(musicVolumePref) && !PlayerPrefs.HasKey(effectVolumePref) && !PlayerPrefs.HasKey(uiVolumePref))
        {
            PlayerPrefs.SetFloat(musicVolumePref, 1);
            PlayerPrefs.SetFloat(effectVolumePref, 1);
            PlayerPrefs.SetFloat(uiVolumePref, 1);
            musicVolume.value = 1;
            sfxVolume.value = 1;
            uiVolume.value = 1;

        }
        else
        {
            musicVolume.value = PlayerPrefs.GetFloat(musicVolumePref);
            sfxVolume.value = PlayerPrefs.GetFloat(effectVolumePref);
            uiVolume.value = PlayerPrefs.GetFloat(uiVolumePref);

        }

        musicVolume.onValueChanged.AddListener(SetMusicVolume);
        sfxVolume.onValueChanged.AddListener(SetSFXVolume);
        uiVolume.onValueChanged.AddListener(SetUIVolume);
    }

    private void Start()
    {
        AudioManager.Instance.PlayMusic("Main music");
        AudioManager.Instance.MusicVolume(PlayerPrefs.GetFloat(musicVolumePref));
        AudioManager.Instance.SfxVolume(PlayerPrefs.GetFloat(effectVolumePref));
        AudioManager.Instance.UIVolume(PlayerPrefs.GetFloat(uiVolumePref));

    }

    private void Destroy()
    {
        musicVolume.onValueChanged.RemoveListener(SetMusicVolume);
        sfxVolume.onValueChanged.RemoveListener(SetSFXVolume);
        uiVolume.onValueChanged.RemoveListener(SetUIVolume);

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
        PlayerPrefs.SetFloat(musicVolumePref, value);
        AudioManager.Instance.MusicVolume(PlayerPrefs.GetFloat(musicVolumePref));
    }

    public void SetSFXVolume(float value)
    {
        PlayerPrefs.SetFloat(effectVolumePref,value);
        AudioManager.Instance.SfxVolume(PlayerPrefs.GetFloat(effectVolumePref));
    }

    public void SetUIVolume(float value)
    {
        PlayerPrefs.SetFloat(uiVolumePref, value);
        AudioManager.Instance.UIVolume(PlayerPrefs.GetFloat(uiVolumePref));
    }

    public void Click()
    {
        AudioManager.Instance.PlayUI("Click");

    }

    public void Hover()
    {
        AudioManager.Instance.PlayUI("Hover");

    }
}