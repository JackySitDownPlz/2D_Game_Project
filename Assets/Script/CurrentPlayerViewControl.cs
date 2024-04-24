using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CurrentPlayerViewControl : MonoBehaviour
{
    private GameObject current_player;
    PhotonView view;
    public GameObject[] Arrows;
    public GameObject[] Dices;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        current_player = GameObject.FindWithTag("CPlayer");
        if (current_player != null) {
            view = current_player.GetComponent<PhotonView>();
            if (view.IsMine)
            {
                foreach (GameObject dice in Dices)
                {
                    dice.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject arrow in Arrows)
                {
                    arrow.SetActive(false);
                }
                foreach (GameObject dice in Dices)
                {
                    dice.SetActive(false);
                }
            }
        }
        

        
    }
}
