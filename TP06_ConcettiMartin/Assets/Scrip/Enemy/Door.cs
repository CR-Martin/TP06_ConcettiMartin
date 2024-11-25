using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, ITakeDamage
{
    [SerializeField] private DoorSO data;

    public void TakeDamage(int strength)
    {
        if (strength >= data.Strength)
        {
            AudioManager.Instance.PlayEffect("Enemy explosion");
            Destroy(gameObject);
        }
    }
}
