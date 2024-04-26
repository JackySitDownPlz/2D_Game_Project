using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public List<GameObject> players;
    private List<GameObject> unsorted;
    private List<GameObject> sorted;

    public List<GameObject> Names;
    public List<GameObject> CatFoods;
    public List<GameObject> CatNips;
    public List<Sprite> Colors;
    public List<GameObject> HPs;
    public List<GameObject> Infos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        unsorted = new List<GameObject>();
        sorted = new List<GameObject>();
        sorting();
        UpdateLB();
    }

    void sorting()
    {

        unsorted = new List<GameObject>(players);
        for (int i = 0;i< players.Count;i++)
        {
            GameObject current_max = null;
            foreach(GameObject GO in unsorted)
            {
                if (current_max == null)
                {
                    current_max = GO;
                }
                else
                {
                    if (GO.GetComponent<PlayerInfo>().catfood + 20*GO.GetComponent<PlayerInfo>().catnip > current_max.GetComponent<PlayerInfo>().catfood + 20 * current_max.GetComponent<PlayerInfo>().catnip)
                    {
                        current_max = GO;
                    }
                }
            }
            sorted.Add(current_max);
            unsorted.Remove(current_max);
        }
    }

    void UpdateLB()
    {
        for (int i = 0; i< sorted.Count; i++)
        {
            Names[i].GetComponent<TMP_Text>().text = "P" + sorted[i].GetComponent<PlayerInfo>().playerID.ToString();
            CatFoods[i].GetComponent<TMP_Text>().text = sorted[i].GetComponent<PlayerInfo>().catfood.ToString();
            CatNips[i].GetComponent<CatNip>().catnip = sorted[i].GetComponent<PlayerInfo>().catnip;
            HPs[i].GetComponent<HP>().hp = sorted[i].GetComponent<PlayerInfo>().HP;
            Infos[i].GetComponent<Image>().sprite = Colors[sorted[i].GetComponent<PlayerInfo>().playerID - 1];
        }
    }
}
