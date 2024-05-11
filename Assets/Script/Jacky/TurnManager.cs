using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TurnManager : MonoBehaviour
{
    public GameObject[] players;
    public int currentPlayerIndex = 0;
    public GameObject Dice1;
    public GameObject Dice2;
    public GameObject Dice3;
    public int round = 1;
    public GameObject RoundNo;
    public GameObject Inventory;
    public GameObject GameController;
    public bool PlayerReachedGoal;
    public string[] minigames;
    private int NoOfRound;

    bool cloudmove;
    public GameObject cloud_blocker;

    // Start is called before the first frame update
    void Start()
    {
        PlayerReachedGoal = false;
        players[currentPlayerIndex].tag = "CPlayer";
        if (LobbyStaticData.NoOfRound > 0)
        {
            NoOfRound = LobbyStaticData.NoOfRound;
        }
        else
        {
            NoOfRound = 1;
        }

        cloudmove = false;
    }
    void Update()
    {
        if (cloudmove)
        {
            cloud_blocker.GetComponent<CanvasGroup>().alpha += 0.01f;
        }
    }
    void FixedUpdate()
    {
        RoundNo.GetComponent<TMP_Text>().text = "Round\n" + round.ToString() + "/" + NoOfRound.ToString();
        if (players[currentPlayerIndex].GetComponent<PlayerInfo>().slept)
        {
            players[currentPlayerIndex].GetComponent<PlayerInfo>().slept = false;
            StartCoroutine(SleptCoroutine());
        }
    }

    // Update is called once per frame

    public void SwitchTurn()
    {
        players[currentPlayerIndex].tag = "Player";
        if (currentPlayerIndex + 1 >= players.Length)
        {
            round += 1;


            StartCoroutine(RoundEndCoroutine());
        }
        else
        {
            
            Dice1.GetComponent<CanvasGroup>().interactable = true;
            Dice2.GetComponent<CanvasGroup>().interactable = true;
            Dice3.GetComponent<CanvasGroup>().interactable = true;
            Inventory.GetComponent<CanvasGroup>().interactable = true;
            Inventory.GetComponent<CanvasGroup>().alpha = 255f;
        }
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        players[currentPlayerIndex].tag = "CPlayer";
        GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player P" + (currentPlayerIndex+1).ToString() + "'s Turn" ;
    }

    private System.Collections.IEnumerator RoundEndCoroutine()
    {
        if (round < (NoOfRound+1) && !PlayerReachedGoal)
        {
            cloudmove = true;
            GameController.GetComponent<InitiateChange>().SaveChange();
            yield return new WaitForSeconds(1f);
            cloudmove = false;
            int minigame = Random.Range(0, minigames.Length);
            GameObject.FindWithTag("Music").GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene(minigames[minigame]);

            
        }
        else
        {
            GameController.GetComponent<InitiateChange>().SaveChange();
            yield return new WaitForSeconds(1f);
            GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Game Over!";
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("EndGame");
        }
    }

    private System.Collections.IEnumerator SleptCoroutine()
    {
        GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player Is Sleeping, Switching To Next Player ...";
        yield return new WaitForSeconds(2f);
        SwitchTurn();
    }
}