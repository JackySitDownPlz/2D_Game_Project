using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject TurnManager;
    public GameObject playerPrefab;
    public float X;
    public float Y;
    public List<GameObject> players = new List<GameObject>();
    private int currentPlayerIndex;
    // Start is called before the first frame update
    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            // Spawn the player character for the local player
            SpawnPlayer();
        }
    }
    private void Update()
    {
        currentPlayerIndex = TurnManager.GetComponent<TurnManager>().currentPlayerIndex;
    }

    private void SpawnPlayer()
    {
        Vector2 Position = new Vector2(X, Y);
        // Instantiate the player prefab for the local player
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, Position, Quaternion.identity);

        // Add the player to the list
        players.Add(player);

        // Update the player's tag based on the turn
        UpdatePlayerTag(player);
    }

    private void UpdatePlayerTag(GameObject player)
    {
        int playerIndex = players.IndexOf(player);
        bool isCurrentPlayer = playerIndex == currentPlayerIndex;
        player.tag = isCurrentPlayer ? "CPlayer" : "Player";
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // Spawn the player character for the new player
            SpawnPlayer();
        }
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // Remove the player from the list
            GameObject playerToRemove = players.Find(player => player.GetPhotonView().Owner == otherPlayer);
            players.Remove(playerToRemove);

            // Update the current player index if necessary
            if (currentPlayerIndex >= players.Count)
            {
                currentPlayerIndex = 0;
            }

            // Update the tags for the remaining players
            foreach (GameObject player in players)
            {
                UpdatePlayerTag(player);
            }
        }
    }
}
