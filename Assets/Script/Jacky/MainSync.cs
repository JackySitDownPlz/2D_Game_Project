using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Linq;

public class MainSync : MonoBehaviour
{
    private PhotonView photonView;
    public List<List<int>> playerdata = new List<List<int>>();
    // Start is called before the first frame update
    void Start()
    {

        photonView = GetComponent<PhotonView>();
        StartCoroutine(InitialCoroutine());

    }

    private System.Collections.IEnumerator InitialCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(LoadingCoroutine());
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(UpdateCoroutine());
    }
    private System.Collections.IEnumerator LoadingCoroutine()
    {
        yield return new WaitForSeconds(1f);
        if (photonView.IsMine)
        {
            SaveList();
            SaveTag();
        }
        else
        {
            GetList();
            GetTag();
        }
        StartCoroutine(LoadingCoroutine());
    }

    private System.Collections.IEnumerator UpdateCoroutine()
    {
        yield return new WaitForSeconds(1f);
        photonView = GameObject.FindWithTag("CPlayer").GetComponent<PhotonView>();
        StartCoroutine(UpdateCoroutine());
    }
    
    public GameObject[] GetAllPlayer()
    {
        GameObject[] AllPlayers = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log("AllPlayers: "+AllPlayers.Length);
        GameObject[] AllCPlayers = GameObject.FindGameObjectsWithTag("CPlayer");
        //Debug.Log("AllCPlayers: " + AllCPlayers.Length);
        GameObject[] All = AllPlayers.Concat(AllCPlayers).ToArray();
        //Debug.Log("All: " + All.Length);
        return All;
    }

    private void SaveList()
    {
        List<int> selectedplayerdata;
        GameObject[] players = GetAllPlayer();
        foreach (var player in players)
        {
            selectedplayerdata = new List<int>();
            selectedplayerdata.Add(player.GetComponent<PlayerInfo>().HP);
            selectedplayerdata.Add(player.GetComponent<PlayerInfo>().catfood);
            selectedplayerdata.Add(player.GetComponent<PlayerInfo>().catnip);
            foreach (var item in player.GetComponent<PlayerInfo>().items)
            {
                selectedplayerdata.Add(item);
            }
            //////////////////////////////////////////
            int[] listArray = selectedplayerdata.ToArray();
            Hashtable table = new Hashtable();
            table[player.GetComponent<PlayerInfo>().playerID.ToString()] = listArray;
            // Set the list array as a custom property of the room
            PhotonNetwork.CurrentRoom.SetCustomProperties(table);
        }
    }

    private void GetList()
    {
        GameObject[] players = GetAllPlayer();
        foreach (var player in players)
        {
            int[] listArray = (int[])PhotonNetwork.CurrentRoom.CustomProperties[player.GetComponent<PlayerInfo>().playerID.ToString()];
            if (listArray != null)
            {
                player.GetComponent<PlayerInfo>().HP = listArray[0];
                player.GetComponent<PlayerInfo>().catfood = listArray[1];
                player.GetComponent<PlayerInfo>().catnip = listArray[2];
                player.GetComponent<PlayerInfo>().items[0] = listArray[3];
                player.GetComponent<PlayerInfo>().items[1] = listArray[4];
                player.GetComponent<PlayerInfo>().items[2] = listArray[5];
                player.GetComponent<PlayerInfo>().items[3] = listArray[6];
                player.GetComponent<PlayerInfo>().items[4] = listArray[7];
                player.GetComponent<PlayerInfo>().items[5] = listArray[8];
                player.GetComponent<PlayerInfo>().items[6] = listArray[9];
                player.GetComponent<PlayerInfo>().items[7] = listArray[10];

            }
        }
        

    }

    private void SaveTag()
    {
        GameObject[] players = GetAllPlayer();
        //Debug.Log(players.Length);
        foreach (GameObject player in players)
        {
            Hashtable table = new Hashtable();
            table[player.GetComponent<PlayerInfo>().playerID+"_tag"] = player.tag;
            //Debug.Log(player.tag);
            PhotonNetwork.CurrentRoom.SetCustomProperties(table);
        }
    }

    private void GetTag()
    {
        GameObject[] players = GetAllPlayer();
        foreach (var player in players)
        {
            player.tag = (string)PhotonNetwork.CurrentRoom.CustomProperties[player.GetComponent<PlayerInfo>().playerID + "_tag"];
        }
    }



    
}
