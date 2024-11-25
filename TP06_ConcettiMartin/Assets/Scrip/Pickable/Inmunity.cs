using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmunity : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            IInmunity hit = other.gameObject.GetComponent<IInmunity>();

            if (hit != null)
            {
                AudioManager.Instance.PlayEffect("Power up");
                hit.InmunityExtends();
                Destroy(gameObject);
            }
        }
    }
}
