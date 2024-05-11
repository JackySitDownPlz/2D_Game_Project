using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerIndicator : MonoBehaviour
{
    public GameObject[] indicators;
    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0;i<indicators.Length;i++)
        {
            if (players[i].tag == "CPlayer")
            {
                indicators[i].transform.localScale = new Vector3(2f, 2f, 2f);
            }
            else
            {
                indicators[i].transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}
