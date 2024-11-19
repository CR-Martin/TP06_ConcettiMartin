using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private EnemySO data;

    int strength;
    void Start()
    {

        strength = data.Strength;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            ITakeDamage hit = collision.gameObject.GetComponent<ITakeDamage>();
            hit.TakeDamage(strength);
        }

    }
}
