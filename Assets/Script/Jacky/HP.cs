using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HP : MonoBehaviour
{
    public int hp;
    public GameObject text;
    public GameObject bg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.GetComponent<TMP_Text>().text = hp.ToString();
        bg.GetComponent<RectTransform>().sizeDelta = new Vector2(hp * (60 / 20),30);
    }
}
