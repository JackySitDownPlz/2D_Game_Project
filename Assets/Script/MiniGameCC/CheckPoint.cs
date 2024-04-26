using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public float scoreValue = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Minigame2_PlayerController player = other.GetComponent<Minigame2_PlayerController>();
            player.AddScore(5);
        }
    }
}
