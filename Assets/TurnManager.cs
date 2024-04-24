using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TurnManager : MonoBehaviour
{
    private List<GameObject> players;
    public GameObject SpawnPlayers;
    public int currentPlayerIndex = -1;
    private bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        players = SpawnPlayers.GetComponent<SpawnPlayers>().players;
        if (players.Count >= 2 && !started)
        {
            started = true;
            SwitchTurn();
        }
    }

    public void SwitchTurn()
    {
        // Set the current player's tag back to "Player"
        players[currentPlayerIndex].tag = "Player";

        // Move to the next player
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;

        // Set the new player's tag to "CPlayer"
        players[currentPlayerIndex].tag = "CPlayer";
    }
}
