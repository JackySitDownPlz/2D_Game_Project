using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisabler : MonoBehaviour
{
    public GameObject[] buttons;
    public bool noself;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(noself)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (GameObject.FindWithTag("CPlayer").GetComponent<PlayerInfo>().playerID == i + 1)
                {
                    buttons[i].GetComponent<Button>().interactable = false;
                }
                else
                {
                    buttons[i].GetComponent<Button>().interactable = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Button>().interactable = true;
            }
        }
        
    }

}
