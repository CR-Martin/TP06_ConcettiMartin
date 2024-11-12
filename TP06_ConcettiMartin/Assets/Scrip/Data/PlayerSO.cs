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

    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public int StartJumpsAmount { get => startJumpsAmount; set => startJumpsAmount = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }

}
