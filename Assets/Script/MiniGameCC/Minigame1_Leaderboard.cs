using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Minigame1_Leaderboard : MonoBehaviour
{
    public int noOfPlayers = 4;
    public GameObject[] playerList;
    [Header("Options")]
    public float refreshRate = 1f;

    [Header("UI")]
    public GameObject[] slots;

    [Space]
    public Text[] scoreTexts;
    public Text[] nameTexts;

    public GameObject showWinner;
    public static string winnerName;
    public static string swinnerName;
    public static string twinnerName;
    public static string fwinnerName;
    public Text winnerNameText;

    public float waitTime = 5f;

    public string nextScene;

    public GameObject[] playerSkinList;

    public AudioClip won;
    private bool played;

    void Start()
    {
        InvokeRepeating(nameof(Refresh), 1f, refreshRate);
        if (PlayerStaticData.Player_int != null)
        {
            noOfPlayers = PlayerStaticData.Player_int.Count;
        }
        else
        {
            noOfPlayers = 4;
        }
        played = false;
    }

    public void Refresh()
    {
        foreach (var slot in slots)
        {
            slot.SetActive(false);
        }
       
        var sortPlayerList = (from player in playerList orderby player.GetComponent<Minigame1_PlayerController>().GetScore() descending select player).ToList();

        int i = 0;
        foreach (var player in sortPlayerList)
        {
            if (i >= noOfPlayers) break;

            var playerController = player.GetComponent<Minigame1_PlayerController>();

            slots[i].SetActive(true);

            var nickname = player.name;

            nameTexts[i].text = nickname;
            scoreTexts[i].text = playerController.GetScore().ToString();

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

        if (Minigame1_PlayerController.endGame == true)
        {
            showWinner.SetActive(true);

            if (scoreTexts[0].text == scoreTexts[1].text && scoreTexts[0].text == scoreTexts[2].text && scoreTexts[0].text == scoreTexts[3].text)
            {
                winnerName = nameTexts[0].text;
                swinnerName = nameTexts[1].text;
                twinnerName = nameTexts[2].text;
                fwinnerName = nameTexts[3].text;
                winnerNameText.text = winnerName + "/" + swinnerName + "/" + twinnerName + "/" + fwinnerName;
                PlayerStaticData.winnerNo = 4;
            }
            else if(scoreTexts[0].text == scoreTexts[1].text && scoreTexts[0].text == scoreTexts[2].text)
            {
                winnerName = nameTexts[0].text;
                swinnerName = nameTexts[1].text;
                twinnerName = nameTexts[2].text;
                fwinnerName = "P0";
                winnerNameText.text = winnerName + "/" + swinnerName + "/" + twinnerName;
                PlayerStaticData.winnerNo = 3;
            }
            else if (scoreTexts[0].text == scoreTexts[1].text)
            {
                winnerName = nameTexts[0].text;
                swinnerName = nameTexts[1].text;
                twinnerName = "P0";
                fwinnerName = "P0";
                winnerNameText.text = winnerName + "/" + swinnerName;
                PlayerStaticData.winnerNo = 2;
            }
            else
            {
                winnerName = nameTexts[0].text;
                swinnerName = "P0";
                twinnerName = "P0";
                fwinnerName = "P0";
                winnerNameText.text = winnerName;
                PlayerStaticData.winnerNo = 1;
            }

            if (winnerName == "P1")
            {
                playerSkinList[0].SetActive(true);
            }
            else if (winnerName == "P2")
            {
                playerSkinList[1].SetActive(true);
            }
            else if (winnerName == "P3")
            {
                playerSkinList[2].SetActive(true);
            }
            else if (winnerName == "P4")
            {
                playerSkinList[3].SetActive(true);
            }
            

            PlayerStaticData.winner = int.Parse(winnerName[1].ToString());
            PlayerStaticData.swinner = int.Parse(swinnerName[1].ToString());
            PlayerStaticData.twinner = int.Parse(twinnerName[1].ToString());
            PlayerStaticData.fwinner = int.Parse(fwinnerName[1].ToString());
            StartCoroutine(changeScene(nextScene));

            if (!played)
            {
                GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(won);
                played = true;
            }
            

        }
    }
    IEnumerator changeScene(string scene)
    {
        yield return new WaitForSeconds(3f);
        GameObject.FindWithTag("Music").GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(scene);
    }

    public string GetWinner()
    {
        return winnerName;
    }
}
