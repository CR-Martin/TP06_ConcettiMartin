using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet SO", menuName = "ScriptableObjects/Bullet Data")]
public class BulletSO : ScriptableObject
{

    [Header("Bullet Settings")]
    [SerializeField] private int strength;
    [SerializeField] private float fireRate;
    [SerializeField] private float velocity;
    [SerializeField] private float lifeTime;
    [SerializeField] private float range;

    public int Strength { get => strength; set => strength = value; }
    public float Velocity { get => velocity; set => velocity = value; }
    public float LifeTime { get => lifeTime; set => lifeTime = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public float Range { get => range; set => range = value; }

}
