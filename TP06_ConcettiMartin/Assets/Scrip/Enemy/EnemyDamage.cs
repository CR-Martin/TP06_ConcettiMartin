using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private EnemySO data;

    int strength;
    void Start()
    {
        Debug.Log("We got enemy damage");

        strength = data.Strength;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("We got collition");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collition entres");

            ITakeDamage hit = collision.gameObject.GetComponent<ITakeDamage>();
            hit.TakeDamage(strength);
        }

    }
}
