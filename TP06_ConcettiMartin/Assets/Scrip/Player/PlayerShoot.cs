using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour, IGetPower
{
    [SerializeField] private PlayerSO entityData;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject superBulletPrefab;
    [SerializeField] private GameObject megaBulletPrefab;

    private int powerLevel;
    private bool isAttacking = false;

    private void Start()
    {
        powerLevel = entityData.InitialPowerLevel;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            isAttacking = true;
            Debug.Log(isAttacking);
        }
        else
        {
            //isAttacking = false;
        }
    }

    void Shoot()
    {
        if (Time.timeScale == 1f)
        {
            AudioManager.Instance.PlayEffect("Weapon sounds");
            SelectBullet();
        }
    }

    void SelectBullet()
    {
        if (powerLevel == 1)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        }

        if (powerLevel == 2)
        {
            Instantiate(superBulletPrefab, firePoint.position, firePoint.rotation);

        }

        if (powerLevel >= 3)
        {
            Instantiate(megaBulletPrefab, firePoint.position, firePoint.rotation);

        }
    }

    public void IncreasePower()
    {
        powerLevel++;
        Debug.Log(powerLevel);
    }

    public bool GetIsAttacking()
    {
        return isAttacking;
    }

    public void SetAttackToFalse()
    {
        isAttacking = false;
    }
}
