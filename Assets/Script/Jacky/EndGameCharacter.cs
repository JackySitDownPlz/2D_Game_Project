using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameCharacter : MonoBehaviour
{
    public int Rank;
    public int Player;
    Animator anim;
    public GameObject cname;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Player == 0)
        {
            GetComponent<CanvasGroup>().alpha = 0f;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            anim.SetInteger("Rank", Rank);
            anim.SetInteger("Player", Player);
            cname.GetComponent<TMP_Text>().text = "P" + Player.ToString();
        }
    }
}
