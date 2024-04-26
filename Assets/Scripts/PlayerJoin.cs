using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJoin : MonoBehaviour
{
    [SerializeField]
    Button buttonStartGame;

    public int playerNumber = 0;

    private void Start()
    {
        playerNumber = 0;
    }

    private void Update()
    {
        if(playerNumber == 0)
        {
            buttonStartGame.interactable = false;
        }
        else
        {
            buttonStartGame.interactable = true;
        }
    }

    public void Join()
    {
        playerNumber++;
    }

    public void Leave()
    {
        playerNumber--;
    }
}
