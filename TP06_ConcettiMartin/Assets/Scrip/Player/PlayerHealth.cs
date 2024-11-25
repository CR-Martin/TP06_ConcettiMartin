using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour, ITakeDamage, IInmunity, IGetMoreInmune
{
    public static event Action OnGameOver;

    [SerializeField] private PlayerSO data;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject shield;

    private int health;
    private int inmunityTimer;
    private int longInmunityTimer;
    private bool inmune;

    void Start()
    {
        health = data.MaxHealth;
        inmunityTimer = data.InmunityTimer;
        UpdateHealthBar(health, data.MaxHealth);
        longInmunityTimer = data.LongInmunityTimer;
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
            AudioManager.Instance.PlayEffect("Player hurt");

            if (health <= 0)
            {
                AudioManager.Instance.PlayEffect("Player dead");

                OnGameOver?.Invoke();
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
        Debug.Log("Inmune time is: " + inmunityTimer);
        inmune = true;
        shield.SetActive(true);

        yield return new WaitForSeconds(inmunityTimer);
        shield.SetActive(false);

        inmune = false;

    }

    public void InmunityExtends()
    {
        inmunityTimer = longInmunityTimer;
    }

    public void ActivateSuperInmunity()
    {
        StartCoroutine(LongInmunityTimer());

    }

    IEnumerator LongInmunityTimer()
    {
        inmune = true;
        shield.SetActive(true);

        yield return new WaitForSeconds(longInmunityTimer);
        shield.SetActive(false);

        inmune = false;
    }

}
