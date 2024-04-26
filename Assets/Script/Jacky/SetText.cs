using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    private GameObject current_player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        current_player = GameObject.FindWithTag("CPlayer");
        GetComponent<TMP_Text>().text = current_player.GetComponent<MoveManager>().steps.ToString();
    }
}
