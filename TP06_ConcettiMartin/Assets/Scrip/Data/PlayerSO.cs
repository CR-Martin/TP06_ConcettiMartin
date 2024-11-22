using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObjects/Player Data")]

public class PlayerSO : ScriptableObject
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementEffectDelay;
    [SerializeField] private float jumpForce;
    [SerializeField] private int startJumpsAmount;
    [SerializeField] private float jumpDelayTime;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float airSpeedModifier;


    [Header("Player health Settings")]
    [SerializeField] private int maxHealth;
    [SerializeField] private int inmunityTimer;

    [Header("Player power Settings")]
    [SerializeField] private int initialPowerLevel;

    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public float MovementEffectDelay { get => movementEffectDelay; set => movementEffectDelay = value; }
    public int StartJumpsAmount { get => startJumpsAmount; set => startJumpsAmount = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int InmunityTimer { get => inmunityTimer; set => inmunityTimer = value; }
    public int InitialPowerLevel { get => initialPowerLevel; set => initialPowerLevel = value; }
    public float JumpDelayTime { get => jumpDelayTime; set => jumpDelayTime = value; }
    public float NormalSpeed { get => normalSpeed; set => normalSpeed = value; }
    public float AirSpeedModifier { get => airSpeedModifier; set => airSpeedModifier = value; }

}
