using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, ITakeDamage
{
    public void TakeDamage(int strength)
    {
        if (strength >= 2)
        {
            AudioManager.Instance.PlayEffect("Enemy explosion");
            Destroy(gameObject);
        }

    }
}
