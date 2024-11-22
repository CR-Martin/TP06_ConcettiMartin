using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSO data;
    private float velocity;
    private Rigidbody2D rb;
    private int strength;
    private float lifeTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = data.Velocity;
        strength = data.Strength;
        lifeTime= data.LifeTime;
    }

    void Start()
    {
        rb.velocity = transform.right * velocity;
        StartCoroutine(LifeTimer());

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            ITakeDamage hit = collision.gameObject.GetComponent<ITakeDamage>();
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

    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
