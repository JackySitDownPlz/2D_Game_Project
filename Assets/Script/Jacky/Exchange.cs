using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Exchange : MonoBehaviour
{
    public GameObject dialog;
    private GameObject current_player;
    public GameObject YesButton;

    public GameObject PC;
    public AudioClip catnip;
    // Start is called before the first frame update
    void Start()
    {
        dialog.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        current_player = GameObject.FindWithTag("CPlayer");
        if (current_player.GetComponent<PlayerInfo>().catfood < 20)
        {
            YesButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            YesButton.GetComponent<Button>().interactable = true;
        }
    }

    public void Yes()
    {
        current_player = GameObject.FindWithTag("CPlayer");
        current_player.GetComponent<PlayerInfo>().catfood -= 20;
        current_player.GetComponent<PlayerInfo>().catnip += 1;
        current_player.GetComponent<MoveManager>().interacting = false;
        dialog.SetActive(false);
        GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player Exchanged For CatNip!";
        PC.GetComponent<PurpleChooser>().SwitchBlock();
        GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(catnip);
    }

    public void No()
    {
        current_player.GetComponent<MoveManager>().interacting = false;
        dialog.SetActive(false);
    }
    
}
