using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy SO", menuName = "ScriptableObjects/Enemy Data")]
public class EnemySO : ScriptableObject
{
    [Header("Enemy life Settings")]
    [SerializeField] private int maxHealth;

    [Header("Bullet Settings")]
    [SerializeField] private int strength;

    public int Strength { get => strength; set => strength = value; }

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

}
