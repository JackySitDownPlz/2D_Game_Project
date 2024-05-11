using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPurple : MonoBehaviour
{
    private GameObject[] blocks;
    // Start is called before the first frame update
    void Start()
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var block in blocks)
        {
            if(block.GetComponent<BlockController>().block_type == 15)
            {
                transform.position = block.transform.position + new Vector3(-1f, -1f, 0);
            }
        }
    }
}
