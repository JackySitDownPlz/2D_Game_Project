using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleChooser : MonoBehaviour
{
    public bool purple_exist;
    private GameObject[] blocks;
    private GameObject ChosenBlock;
    // Start is called before the first frame update
    void Start()
    {
        purple_exist = false;
        blocks = GameObject.FindGameObjectsWithTag("Block");
    }

    // Update is called once per frame
    void Update()
    {
        if (!purple_exist)
        {
            ChosenBlock = blocks[Random.Range(0, blocks.Length)];
            ChosenBlock.GetComponent<BlockController>().change_purple();
            purple_exist = true;
        }
        
    }
}
