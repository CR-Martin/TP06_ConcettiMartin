using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField] private PlayerSO data;
    [SerializeField] private Slider lifeBar;

    private int life;
    private bool inmune;

    void Start()
    {
        life = data.MaxHealth;
        UpdateHealthBar(life, data.MaxHealth);
        inmune = false;

    }
    public void TakeDamage(int strength)
    {
        if (inmune)
        {

        }
        else
        {

            life -= strength;

            if (life <= 0)
            {
                //AudioManager.Instance.PlayEffect("Game Over");
                //OnGameOver?.Invoke();
            }

            UpdateHealthBar(life, data.MaxHealth);

            StartCoroutine(InmunityTimer());
        }
    }

    private void UpdateHealthBar(int currentLife, int maxHealth)
    {
        float temp1 = currentLife;
        float temp2 = maxHealth;
        lifeBar.value = temp1 / temp2;

    }
    IEnumerator InmunityTimer()
    {
        inmune = true;
        yield return new WaitForSeconds(5f);
        inmune = false;

    }
}