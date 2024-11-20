using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPickable : MonoBehaviour
{
    [SerializeField] private HealthPickableSO data;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (!other.gameObject.GetComponent<PlayerHealth>().IsHealthFull())
            {
                Debug.Log("Life is not full");

                ITakeDamage hit = other.gameObject.GetComponent<ITakeDamage>();
                AudioManager.Instance.PlayEffect("Power up");
                hit.TakeDamage(data.AmountOfHealth);
                Destroy(gameObject);
            }          
        }
    }
}
