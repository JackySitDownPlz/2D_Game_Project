using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class TurnManager : MonoBehaviourPunCallbacks
{
    private List<int> players;
    public GameObject SpawnPlayers;
    public int currentPlayerIndex = 0;
    public int currentPlayerID;
    public bool started = false;
    GameObject the_player;
    bool finishLoading = false;

    //Sync variable
    private void SaveInfo()
    {
        Hashtable table = new Hashtable();
        // Convert the list to an array for synchronization
        int[] listArray = new List<int>{ currentPlayerIndex, currentPlayerID}.ToArray();

        table["TurnManager"] = listArray;
        // Set the list array as a custom property of the room
        PhotonNetwork.CurrentRoom.SetCustomProperties(table);
    }
    private void GetInfo()
    {
        var listArray = (int[])PhotonNetwork.CurrentRoom.CustomProperties["TurnManager"];
        var Info = new List<int>(listArray);
        currentPlayerIndex = Info[0];
        currentPlayerID = Info[1];
    }

    //-------------------------------------------------------------

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
        }

        if (finishLoading)
        {
            if (photonView.IsMine)
            {
                currentPlayerID = players[currentPlayerIndex];
                SaveInfo();
            }
            else
            {
                GetInfo();
            }
        }
        else
        {
            StartCoroutine(InitialCoroutine());
        }
        

    }



    public void SwitchTurn()
    {
        if (photonView.IsMine) {
        int[] listArray = (int[])PhotonNetwork.CurrentRoom.CustomProperties["PlayerList"];
        players = new List<int>(listArray);
        // Set the current player's tag back to "Player"
        GetPlayerByID(players[currentPlayerIndex]).tag = "Player";

        // Move to the next player
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;

        // Set the new player's tag to "CPlayer"
        GetPlayerByID(players[currentPlayerIndex]).tag = "CPlayer";
        }
    }










    public GameObject GetPlayerByID(int ID)
    {
        var AllPlayers = GameObject.FindGameObjectsWithTag("Player").ToList();
        var AllCPlayers = GameObject.FindGameObjectsWithTag("Player").ToList();
        var All = AllPlayers.Union(AllCPlayers).ToList();
        foreach (GameObject player in AllPlayers)
        {
            if (player.GetComponent<PlayerInfo>().playerID == ID)
            {
                the_player = player;
            }
        }
        return the_player;
    }



    private System.Collections.IEnumerator InitialCoroutine()
    {
        yield return new WaitForSeconds(0.6f);
        finishLoading = true;
    }

}
