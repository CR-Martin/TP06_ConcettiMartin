using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO data;
    private float velocity;
    private Rigidbody2D rb;
    private int strength;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = data.Velocity;
        strength = data.Strength;
    }
    void Start()
    {
        rb.velocity = transform.right * velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            ITakeDamage hit = collision.gameObject.GetComponent<ITakeDamage>();
            Debug.Log(hit);
            if (hit != null)
            {
                hit.TakeDamage(strength);
            }
            if (collision.gameObject.tag == "Enemy aim")
            {
            }
            else
            {
                Destroy(gameObject);

            }
        }
            
    }

}
