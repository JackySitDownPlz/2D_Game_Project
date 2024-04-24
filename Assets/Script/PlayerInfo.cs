using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInfo : MonoBehaviour
{
    public int HP;
    public int catfood;
    public int catnip;
    public int[] items;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
