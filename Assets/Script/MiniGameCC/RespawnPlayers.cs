using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RespawnPlayers : MonoBehaviour
{
    public GameObject respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Minigame2_PlayerController player = other.GetComponent<Minigame2_PlayerController>();
            if (player != null)
            {
                other.transform.position = respawnPoint.transform.position;
                player.SetScore(0);
            }
        }
    }
}
