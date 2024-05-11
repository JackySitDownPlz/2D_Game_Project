using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySetting : MonoBehaviour
{
    public int NoOfPlayer;
    public int NoOfRound;

    public GameObject[] Players;
    public string scene;
    public AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        NoOfPlayer = 4;
        LobbyStaticData.NoOfPlayer = 4;
        NoOfRound = 20;
        LobbyStaticData.NoOfRound = 20;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNoOfPlayer();
    }

    public void SetNoOfPlayer(int noOfPlayer)
    {
        NoOfPlayer = noOfPlayer;
        LobbyStaticData.NoOfPlayer = noOfPlayer;
    }

    void UpdateNoOfPlayer()
    {
        foreach (var player in Players)
        {
            player.SetActive(false);
        }
        for (int i = 0; i < NoOfPlayer; i++)
        {
            Players[i].SetActive(true);
        }
    }

    public void SetNoOfRound(int noOfRound)
    {
        NoOfRound = noOfRound;
        LobbyStaticData.NoOfRound = noOfRound;
    }

    public void StartGame()
    {
        LobbyStaticData.NoOfRound = NoOfRound;
        LobbyStaticData.NoOfPlayer = NoOfPlayer;
        audiosource.Stop();
        SceneManager.LoadScene(scene);

    }

}
