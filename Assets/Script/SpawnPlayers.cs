using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;


public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject TurnManager;
    public GameObject playerPrefab;
    public float X;
    public float Y;
    public List<int> players = new List<int>();
    private int currentPlayerIndex;
    // Start is called before the first frame update
    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (!PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("PlayerList"))
            {
                Hashtable table = new Hashtable();
                int[] listArray = players.ToArray();
                table["PlayerList"] = listArray;
                PhotonNetwork.CurrentRoom.SetCustomProperties(table);
                Debug.Log("Initiated PlayerList");
                
            }
            StartCoroutine(LoadingCoroutine());
            StartCoroutine(GetListCoroutine());
        }
        
    }

    private System.Collections.IEnumerator LoadingCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SpawnPlayer();
    }

    private System.Collections.IEnumerator GetListCoroutine()
    {
        currentPlayerIndex = TurnManager.GetComponent<TurnManager>().currentPlayerIndex;
        GetList();
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(GetListCoroutine());
    }

    private void Update()
    {

    }


    private void SaveList()
    {
        Hashtable table = new Hashtable();
        // Convert the list to an array for synchronization
        int[] listArray = players.ToArray();

        table["PlayerList"] = listArray;
        // Set the list array as a custom property of the room
        PhotonNetwork.CurrentRoom.SetCustomProperties(table);
        Debug.Log("Saved");
    }

    private void GetList()
    {
        int[] listArray = (int[])PhotonNetwork.CurrentRoom.CustomProperties["PlayerList"];
        if(listArray != null)
        {
            players = new List<int>(listArray);
        }
        
    }

    private void SpawnPlayer()
    {
        GetList();
        Vector2 Position = new Vector2(X, Y);
        // Instantiate the player prefab for the local player
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, Position, Quaternion.identity);
        player.GetComponent<PlayerInfo>().playerID = player.GetComponent<PhotonView>().ViewID;
        // Add the player to the list
        players.Add(player.GetComponent<PlayerInfo>().playerID);

        // Update the player's tag based on the turn
        UpdatePlayerTag(player);
        SaveList();

    }

    private void UpdatePlayerTag(GameObject player)
    {
        int playerIndex = players.IndexOf(player.GetComponent<PlayerInfo>().playerID);
        bool isCurrentPlayer = playerIndex == currentPlayerIndex;
        player.tag = isCurrentPlayer ? "CPlayer" : "Player";
    }





    /*
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // Spawn the player character for the new player
            //SpawnPlayer();
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
    */
}
