using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmunity : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            IGetMoreInmune hit = other.gameObject.GetComponent<IGetMoreInmune>();

            if (hit != null)
            {
                AudioManager.Instance.PlayEffect("Power up");
                hit.InmunityExtends();
                Destroy(gameObject);
            }
        }
    }
}
