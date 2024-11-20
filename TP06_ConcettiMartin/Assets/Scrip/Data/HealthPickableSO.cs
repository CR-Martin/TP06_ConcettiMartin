using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPickable SO", menuName = "ScriptableObjects/HealthPickable Data")]

public class HealthPickableSO : ScriptableObject
{
    [Header("Bullet Settings")]
    [SerializeField] private int amountOfHealth;

    public int AmountOfHealth { get => amountOfHealth; set => amountOfHealth = value; }
}
