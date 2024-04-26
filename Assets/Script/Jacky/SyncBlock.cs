using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SyncBlock : MonoBehaviour
{
    /*
    public GameObject gb;
    List<int> block_type_list = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        StartCoroutine(InitialCoroutine());

    }

    // Update is called once per frame

    private void SaveInfo()
    {
        for (int i = 0; i < gb.transform.childCount-1; i++)
        {
            block_type_list.Add(gb.transform.GetChild(i).gameObject.GetComponent<BlockController>().block_type);
        }
        Hashtable table = new Hashtable();
        // Convert the list to an array for synchronization
        int[] listArray = block_type_list.ToArray();

        table["BlockType"] = listArray;
        // Set the list array as a custom property of the room
        PhotonNetwork.CurrentRoom.SetCustomProperties(table);
    }
    private void GetInfo()
    {
        var listArray = (int[])PhotonNetwork.CurrentRoom.CustomProperties["BlockType"];
        var Info = new List<int>(listArray);
        for (int i = 0; i < gb.transform.childCount-1; i++)
        {
            gb.transform.GetChild(i).gameObject.GetComponent<BlockController>().block_type = Info[i];
        }
    }

    private System.Collections.IEnumerator InitialCoroutine()
    {
        yield return new WaitForSeconds(0.7f);
        if (photonView.IsMine)
        for (int i = 0; i < gb.transform.childCount-1; i++)
        {
            gb.transform.GetChild(i).gameObject.GetComponent<BlockController>().block_id = i;
        }
        if (photonView.IsMine)
        {
            SaveInfo();
        }
        else
        {
            GetInfo();
        }

    }
    */
}
