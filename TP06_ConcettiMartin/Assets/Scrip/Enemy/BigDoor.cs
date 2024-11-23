using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoor : MonoBehaviour, ITakeDamage
{
    public void TakeDamage(int strength)
    {
        if (strength >= 3)
        {
            AudioManager.Instance.PlayEffect("Enemy explosion");
            Destroy(gameObject);
        }

    }
}
