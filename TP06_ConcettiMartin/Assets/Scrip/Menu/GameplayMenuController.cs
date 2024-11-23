using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayMenuController : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider musicVolume;
    [SerializeField] private Slider sfxVolume;
    [SerializeField] private Slider uiVolume;

    [Header("Player prefs")]
    [SerializeField] private string musicVolumePref = "musicVolume";
    [SerializeField] private string effectVolumePref = "effectVolume";
    [SerializeField] private string uiVolumePref = "uiVolume";

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject gameOverMenu;

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
    private void OnEnable()
    {
        GameManager.ActivateWinGame += WinGame;
        GameManager.ActivateGameOver += GameOver;

    }
    private void OnDisable()
    {
        GameManager.ActivateWinGame -= WinGame;
        GameManager.ActivateGameOver -= GameOver;

    }
    private void Start()
    {
        AudioManager.Instance.PlayMusic("Main music");
        AudioManager.Instance.MusicVolume(PlayerPrefs.GetFloat(musicVolumePref));
        AudioManager.Instance.SfxVolume(PlayerPrefs.GetFloat(effectVolumePref));
        AudioManager.Instance.UIVolume(PlayerPrefs.GetFloat(uiVolumePref));

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        if (Time.timeScale == 1)
        {
            pauseMenu.SetActive(true);
            SetTimeToZero();
        }
        else
        {
            ResumeGameplay();
        }
    }

    private void GameOver()
    {
        SetTimeToZero();
       gameOverMenu.SetActive(true);

    }
    private void WinGame()
    {
        SetTimeToZero();
        winMenu.SetActive(true);
    }

    public void RelaodLevel()
    {
        SetTimeToOne();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void ChangeScene(string name)
    {
        SetTimeToOne();
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

    public void ResumeGameplay()
    {
        pauseMenu.SetActive(false);
        SetTimeToOne();
    }
    private void SetTimeToZero()
    {
        Time.timeScale = 0f;
    }

    private void SetTimeToOne()
    {
        Time.timeScale = 1f;
    }

    public void CloseGame()
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
        PlayerPrefs.SetFloat(effectVolumePref, value);
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
