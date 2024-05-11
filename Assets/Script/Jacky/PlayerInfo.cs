using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInfo : MonoBehaviour
{
    public int playerID;
    public int HP;
    public int catfood;
    public int catnip;
    public int[] items;
    public Animator anim;
    public int Speed;
    public int NSpeed;
    public bool slept;
    public bool shielded;
    public AudioClip s_died;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 1;
        NSpeed = 1;
        anim = GetComponent<Animator>();
        HP = 20;
        catfood = 0;
        catnip = 0;
        items = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    // Update is called once per frame
    void Update()
    {
        HP = Math.Clamp(HP, 0, 20);
        catfood = Math.Clamp(catfood, 0, 100);
        catnip = Math.Clamp(catnip, 0, 5);
        for (int i = 0;i <8;i++)
        {
            items[i]= Math.Clamp(items[i], 0, 10);
        }
        if (HP <= 0)
        {
            catfood -= 10;
            HP = 20;
            GameObject.FindWithTag("CharSound").GetComponent<AudioSource>().PlayOneShot(s_died);
            anim.SetBool("Death", true);
            StartCoroutine(DeathCoroutine());

        }
        if (catnip >= 5)
        {
            GameObject.FindWithTag("TurnManager").GetComponent<TurnManager>().PlayerReachedGoal = true;
        }
    }
    private System.Collections.IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(2f);
        anim.SetBool("Death", false);
    }



}
