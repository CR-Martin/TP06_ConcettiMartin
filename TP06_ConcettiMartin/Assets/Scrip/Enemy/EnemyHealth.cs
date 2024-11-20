using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class EnemyHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField] private EnemySO data;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject deadParticles;

    private int health;
    void Start()
    {
        health = data.MaxHealth;
        UpdateHealthBar(health, data.MaxHealth);

    }
    private void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        float temp1 = currentHealth;
        float temp2 = maxHealth;
        healthBar.value = temp1 / temp2;

    }

    public void TakeDamage(int strength)
    {
        AudioManager.Instance.PlayEffect("Hurt");

        health -= strength;
        Debug.Log(health);
        if (health <= 0)
        {
            //Instantiate(deadParticles, transform.position, Quaternion.identity);
            AudioManager.Instance.PlayEffect("Explosion");
            Destroy(gameObject);
        }
        UpdateHealthBar(health, data.MaxHealth);

    }

}
