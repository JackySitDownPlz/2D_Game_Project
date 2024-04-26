using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue;

    void OnTriggerEnter2D(Collider2D other)
    {
        Minigame1_PlayerController controller = other.GetComponent<Minigame1_PlayerController>();

        if (controller != null)
        {
            controller.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
