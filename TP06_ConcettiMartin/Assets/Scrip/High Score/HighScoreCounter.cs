using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreCounter : MonoBehaviour
{
    [Header("HighScore prefs")]
    [SerializeField] private string highScorePref = "highScore";

    [SerializeField] public static HighScoreCounter instance;

    public TMP_Text highScoreText;
    private int currentCounter;
    private void Awake()
    {
        instance = this;
        if (!PlayerPrefs.HasKey(highScorePref)) 
        {
            PlayerPrefs.SetFloat(highScorePref,0);

        }
    }

    void Start()
    {
        currentCounter = 0;
        SetText();
    }

    public void IncreaseHighScore(int v)
    {
        currentCounter += v;
        if (currentCounter > PlayerPrefs.GetFloat(highScorePref)
)
        {
            PlayerPrefs.SetFloat(highScorePref, currentCounter);

        }
        SetText();


    }

    private void SetText()
    {
        highScoreText.text = "COINS: " + currentCounter.ToString() + " High Score: " + PlayerPrefs.GetFloat(highScorePref).ToString();

    }
}
