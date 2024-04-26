using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame3_EndGameCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Minigame3_PlayerController.endGame = true;
        }
        
    }
}
