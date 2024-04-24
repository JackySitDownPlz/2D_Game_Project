using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject[] items;
    private PlayerInfo Pinfo;
    private GameObject CPlayer;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject item in items)
        {
            item.GetComponent<CanvasGroup>().alpha = 0.5f;
            item.GetComponent<CanvasGroup>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CPlayer = GameObject.FindWithTag("CPlayer");
        if (CPlayer != null)
        {
            Pinfo = CPlayer.GetComponent<PlayerInfo>();
            for (int i = 0; i < 8; i++)
            {
                if (Pinfo.items[i] <= 0)
                {
                    items[i].GetComponent<CanvasGroup>().alpha = 0.5f;
                    items[i].transform.GetChild(0).GetComponent<TMP_Text>().text = 0.ToString();
                    items[i].GetComponent<CanvasGroup>().interactable = false;
                }
                else
                {
                    items[i].GetComponent<CanvasGroup>().alpha = 1f;
                    items[i].transform.GetChild(0).GetComponent<TMP_Text>().text = Pinfo.items[i].ToString();
                    items[i].GetComponent<CanvasGroup>().interactable = true;
                }
            }
        }
        
    }

    
}
