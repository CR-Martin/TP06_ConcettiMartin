using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlayEffect("Coin");
            HighScoreCounter.instance.IncreaseHighScore(1);
            Destroy(gameObject);
        }
    }
}
