using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatNip : MonoBehaviour
{
    public int catnip;
    public GameObject[] catnips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var cn in catnips)
        {
            cn.SetActive(false);
        }
        for (int i = 0;i< catnip; i++)
        {
            catnips[i].SetActive(true);
        }
    }
}
