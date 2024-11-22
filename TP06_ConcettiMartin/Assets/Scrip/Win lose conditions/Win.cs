using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Win : MonoBehaviour
{
    public static event Action WinGame;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Here");
            WinGame?.Invoke();
        }
    }
}
