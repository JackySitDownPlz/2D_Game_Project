using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;
using TMPro;
using UnityEngine.UI;


public class TurnManager : MonoBehaviour
{
    public GameObject[] players;
    public int currentPlayerIndex = 0;
    public GameObject Dice1;
    public GameObject Dice2;
    public GameObject Dice3;
    private int round = 1;
    public GameObject RoundNo;
    public GameObject Inventory;

    // Start is called before the first frame update
    void Start()
    {
        players[currentPlayerIndex].tag = "CPlayer";
    }

    void FixedUpdate()
    {
        RoundNo.GetComponent<TMP_Text>().text = "Round\n"+ round.ToString() + "/15";
    }

    // Update is called once per frame

    public void SwitchTurn()
    {
        players[currentPlayerIndex].tag = "Player";
        if (currentPlayerIndex + 1 >= players.Length)
        {
            round += 1;
        }
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        players[currentPlayerIndex].tag = "CPlayer";
        Dice1.GetComponent<CanvasGroup>().interactable = true;
        Dice2.GetComponent<CanvasGroup>().interactable = true;
        Dice3.GetComponent<CanvasGroup>().interactable = true;
        Inventory.GetComponent<CanvasGroup>().interactable = true;
        Inventory.GetComponent<CanvasGroup>().alpha = 255f;
    }
}
