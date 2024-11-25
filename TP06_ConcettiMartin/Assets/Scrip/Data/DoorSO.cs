using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Door SO", menuName = "ScriptableObjects/Door Data")]
public class DoorSO : ScriptableObject
{

    [Header("Door Settings")]
    [SerializeField] private int strength;

    public int Strength { get => strength; set => strength = value; }

}
