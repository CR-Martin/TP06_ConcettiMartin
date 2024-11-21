using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObjects/Player Data")]

public class PlayerSO : ScriptableObject
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int startJumpsAmount;


    [Header("Player health Settings")]
    [SerializeField] private int maxHealth;

    [Header("Player power Settings")]
    [SerializeField] private int initialPowerLevel;

    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public int StartJumpsAmount { get => startJumpsAmount; set => startJumpsAmount = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int InitialPowerLevel { get => initialPowerLevel; set => initialPowerLevel = value; }

}
