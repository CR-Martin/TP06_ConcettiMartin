using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField] private PlayerSO data;
    [SerializeField] private Slider healthBar;

    private int health;
    private int inmunityTimer;
    private bool inmune;

    void Start()
    {
        health = data.MaxHealth;
        inmunityTimer=data.InmunityTimer;
        UpdateHealthBar(health, data.MaxHealth);
        inmune = false;

    }
    public void TakeDamage(int strength)
    {

        if (inmune)
        {

        }
        else
        {

            health -= strength;
            Debug.Log(health);

            if (health <= 0)
            {
                //AudioManager.Instance.PlayEffect("Game Over");
                //OnGameOver?.Invoke();
            }

            UpdateHealthBar(health, data.MaxHealth);

            StartCoroutine(InmunityTimer());
        }
    }

    private void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        float temp1 = currentHealth;
        float temp2 = maxHealth;
        healthBar.value = temp1 / temp2;

    }

    public bool IsHealthFull()
    {
        if (health == data.MaxHealth)
        {
            return true;
        }
        else
        {
            return false;    
        }
    }

    IEnumerator InmunityTimer()
    {
        inmune = true;
        yield return new WaitForSeconds(inmunityTimer);
        inmune = false;

    }
}
