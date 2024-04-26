using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Minigame3_LeaderBoard : MonoBehaviour
{
    public int noOfPlayers = 4;
    public GameObject[] playerList;
    public GameObject[] playerSkinList;

    [Header("Options")]
    public float refreshRate = 1f;

    [Header("UI")]
    public GameObject[] slots;

    [Space]
    public TextMeshProUGUI[] nameTexts;

    public GameObject showWinner;
    public static string winnerName;
    public TextMeshProUGUI winnerNameText;


    public float waitTime = 5f;

    public string nextScene;

    void Start()
    {
        InvokeRepeating(nameof(Refresh), 1f, refreshRate);
    }

    public void Refresh()
    {
        foreach (var slot in slots)
        {
            slot.SetActive(false);
        }

        var sortPlayerList = (from player in playerList orderby player.GetComponent<Minigame3_PlayerController>().currentY descending select player).ToList();

        int i = 0;
        foreach (var player in sortPlayerList)
        {
            if (i >= noOfPlayers) break;

            var playerController = player.GetComponent<Minigame3_PlayerController>();

            slots[i].SetActive(true);

            nameTexts[i].text = player.name;

            i++;
        }

        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        var sortPlayerObjects = playerObjects.OrderBy(player => player.name).ToList();

        for (int n = 0; n < playerObjects.Length; n++)
        {
            if (n < noOfPlayers)
            {
                sortPlayerObjects[n].SetActive(true);
            }
            else
            {
                sortPlayerObjects[n].SetActive(false);
            }
        }

        if (Minigame3_PlayerController.endGame == true)
        {
            showWinner.SetActive(true);

            winnerName = nameTexts[0].text;

            if(winnerName == "P1" || winnerName == "P3")
            {
                playerSkinList[0].SetActive(true);
            }
            else if(winnerName == "P2" || winnerName == "P4")
            {
                playerSkinList[1].SetActive(true);
            }
            winnerNameText.text = winnerName;

            Minigame3_Timer.timerIsRunning = false;
            StartCoroutine(changeScene(nextScene));
        }
    }
    IEnumerator changeScene(string scene)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene);
    }
}