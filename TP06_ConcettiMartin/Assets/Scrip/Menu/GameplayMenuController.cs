using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

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
       // gameOverMenu.SetActive(true);

    }
    private void WinGame()
    {
        SetTimeToZero();
        //winMenu.SetActive(true);
    }

    public void ChangeScene(string name)
    {
        SetTimeToOne();
        SceneManager.LoadScene(sceneName: name);
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

    public void Click()
    {
        AudioManager.Instance.PlayUI("Click");

    }
    public void Hover()
    {
        AudioManager.Instance.PlayUI("Hover");

    }
}
