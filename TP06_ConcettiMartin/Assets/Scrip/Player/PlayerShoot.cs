using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.timeScale == 1f)
        {
            AudioManager.Instance.PlayEffect("Shooting");
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

    }
}
