using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateChange : MonoBehaviour
{
    public GameObject[] players;
    public GameObject TurnManager;
    public GameObject[] blocks;
    public GameObject PurpleChooser;

    List<List<int>> Player_int;
    List<List<bool>> Player_bool;
    List<int[]> Player_inta;
    List<Vector3> Transform_Vector3;
    List<int> BlockController_int;
    int TurnManager_int;
    bool PurpleChooser_bool;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerStaticData.winner);
        Player_int = new List<List<int>>();
        Player_bool = new List<List<bool>>();
        Player_inta = new List<int[]>();
        Transform_Vector3 = new List<Vector3>();
        BlockController_int = new List<int>();
        TurnManager_int = 0;
        PurpleChooser_bool = false;

        if (PlayerStaticData.save_no > 1)
        {

            StartCoroutine(ReloadCoroutine());
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveChange()
    {
        foreach (var player in players)
        {
            List<int> player_data = new List<int>();
            player_data.Add(player.GetComponent<CatController>().back_direction);
            player_data.Add(player.GetComponent<CatController>().OnBlockType);
            player_data.Add(player.GetComponent<PlayerInfo>().HP);
            player_data.Add(player.GetComponent<PlayerInfo>().catfood);
            player_data.Add(player.GetComponent<PlayerInfo>().catnip);
            Player_int.Add(player_data);
        }
        foreach (var player in players)
        {
            List<bool> player_data = new List<bool>();
            player_data.Add(player.GetComponent<CatController>().left_walkable);
            player_data.Add(player.GetComponent<CatController>().right_walkable);
            player_data.Add(player.GetComponent<CatController>().up_walkable);
            player_data.Add(player.GetComponent<CatController>().down_walkable);
            player_data.Add(player.GetComponent<CatController>().CrossRoad);
            Player_bool.Add(player_data);
        }
        foreach (var player in players)
        {
            Player_inta.Add(player.GetComponent<PlayerInfo>().items);
            Transform_Vector3.Add(player.transform.position);
        }
        foreach (var block in blocks)
        {
            BlockController_int.Add(block.GetComponent<BlockController>().block_type);
        }
        TurnManager_int = TurnManager.GetComponent<TurnManager>().round;
        PurpleChooser_bool = PurpleChooser.GetComponent<PurpleChooser>().purple_exist;

        PlayerStaticData.Player_int = new List<List<int>>(Player_int);
        PlayerStaticData.Player_bool = new List<List<bool>>(Player_bool);
        PlayerStaticData.Player_inta = new List<int[]>(Player_inta);
        PlayerStaticData.Transform_Vector3 = new List<Vector3>(Transform_Vector3);
        PlayerStaticData.BlockController_int = new List<int>(BlockController_int);
        PlayerStaticData.TurnManager_int = TurnManager_int;
        PlayerStaticData.PurpleChooser_bool = PurpleChooser_bool;
        PlayerStaticData.save_no += 1;
        Debug.Log("Saved: " + PlayerStaticData.save_no);
    }

    public void GetChange()
    {
        Player_int = new List<List<int>>(PlayerStaticData.Player_int);
        Player_bool = new List<List<bool>>(PlayerStaticData.Player_bool);
        Player_inta = new List<int[]>(PlayerStaticData.Player_inta);
        Transform_Vector3 = new List<Vector3>(PlayerStaticData.Transform_Vector3);
        BlockController_int = new List<int>(PlayerStaticData.BlockController_int);
        TurnManager_int = PlayerStaticData.TurnManager_int;
        PurpleChooser_bool = PlayerStaticData.PurpleChooser_bool;

        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<CatController>().back_direction = Player_int[i][0];
            players[i].GetComponent<CatController>().OnBlockType = Player_int[i][1];
            players[i].GetComponent<PlayerInfo>().HP = Player_int[i][2];
            players[i].GetComponent<PlayerInfo>().catfood = Player_int[i][3];
            players[i].GetComponent<PlayerInfo>().catnip = Player_int[i][4];

            players[i].GetComponent<CatController>().left_walkable = Player_bool[i][0];
            players[i].GetComponent<CatController>().right_walkable = Player_bool[i][1];
            players[i].GetComponent<CatController>().up_walkable = Player_bool[i][2];
            players[i].GetComponent<CatController>().down_walkable = Player_bool[i][3];
            players[i].GetComponent<CatController>().CrossRoad = Player_bool[i][4];

            players[i].GetComponent<PlayerInfo>().items = Player_inta[i];
            players[i].transform.position = Transform_Vector3[i];
        }
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].GetComponent<BlockController>().block_type = BlockController_int[i];
        }
        TurnManager.GetComponent<TurnManager>().round = TurnManager_int;
        PurpleChooser.GetComponent<PurpleChooser>().purple_exist = PurpleChooser_bool;
    }
    private System.Collections.IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(1f);
        GetChange();
        Debug.Log("Loaded: " + PlayerStaticData.save_no);
        if (PlayerStaticData.winnerNo > 0)
        {
            if (PlayerStaticData.winnerNo == 1)
            {
                players[PlayerStaticData.winner - 1].GetComponent<PlayerInfo>().catfood += 7;

            }
            else if (PlayerStaticData.winnerNo == 2)
            {
                players[PlayerStaticData.winner - 1].GetComponent<PlayerInfo>().catfood += 7;
                players[PlayerStaticData.swinner - 1].GetComponent<PlayerInfo>().catfood += 7;
            }
            else if (PlayerStaticData.winnerNo == 3)
            {
                players[PlayerStaticData.winner - 1].GetComponent<PlayerInfo>().catfood += 7;
                players[PlayerStaticData.swinner - 1].GetComponent<PlayerInfo>().catfood += 7;
                players[PlayerStaticData.twinner - 1].GetComponent<PlayerInfo>().catfood += 7;
            }
            else if (PlayerStaticData.winnerNo == 4)
            {
                players[PlayerStaticData.winner - 1].GetComponent<PlayerInfo>().catfood += 7;
                players[PlayerStaticData.swinner - 1].GetComponent<PlayerInfo>().catfood += 7;
                players[PlayerStaticData.twinner - 1].GetComponent<PlayerInfo>().catfood += 7;
                players[PlayerStaticData.fwinner - 1].GetComponent<PlayerInfo>().catfood += 7;
            }
            foreach (var player in players)
            {
                player.GetComponent<PlayerInfo>().catfood += 3;
            }
        }

    }
}
