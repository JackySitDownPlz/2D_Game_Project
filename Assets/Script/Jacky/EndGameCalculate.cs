using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class EndGameCalculate : MonoBehaviour
{
    List<List<int>> Player_int;
    List<List<int>> scores;
    public GameObject[] characters;
    public AudioSource AS;
    public AudioClip congrat;
    // Start is called before the first frame update
    void Start()
    {
        AS.PlayOneShot(congrat);
        scores = new List<List<int>>();

        
        Player_int = new List<List<int>>(PlayerStaticData.Player_int);
        for (int i = 0; i < Player_int.Count; i++)
        {
            List<int> score = new List<int>();
            score.Add(i+1);
            score.Add(Player_int[i][3]);
            score.Add(Player_int[i][4]);
            scores.Add(score);
        }



        /*
        List<int> temp;
        temp = new List<int>();
        temp.Add(1);
        temp.Add(10);
        temp.Add(4);
        scores.Add(temp);


        temp = new List<int>();
        temp.Add(2);
        temp.Add(2);
        temp.Add(5);
        scores.Add(temp);


        temp = new List<int>();
        temp.Add(3);
        temp.Add(10);
        temp.Add(5);
        scores.Add(temp);



        temp = new List<int>();
        temp.Add(4);
        temp.Add(40);
        temp.Add(4);
        scores.Add(temp);
        */

        var ranking = scores.OrderByDescending(num => num[2] * 20 + num[1]);
        ranking = ranking.OrderByDescending(num => num[2]);
        List<List<int>> ranked = new List<List<int>>(ranking);

        for (int i = 0; i< ranked.Count();i++)
        {
            Debug.Log(ranked[i][0]);
            characters[i].GetComponent<EndGameCharacter>().Player = ranked[i][0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Swap<T>(IList<T> list, int indexA, int indexB)
    {
        T tmp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = tmp;
    }

    public void ResetData()
    {
        PlayerStaticData.save_no = 1;
        SceneManager.LoadScene("StartScene");
    }
}
