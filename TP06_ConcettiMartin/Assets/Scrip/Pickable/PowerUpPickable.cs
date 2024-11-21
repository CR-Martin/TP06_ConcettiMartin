using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickable : MonoBehaviour
{
    //[SerializeField] private HealthPickableSO data;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            IGetPower hit = other.gameObject.GetComponent<IGetPower>();

            if (hit != null)
            {
                AudioManager.Instance.PlayEffect("Power up");
                hit.IncreasePower();
                Destroy(gameObject);
            }
        }
    }
}
