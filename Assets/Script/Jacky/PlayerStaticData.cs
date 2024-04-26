using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaticData : MonoBehaviour
{
    public static List<List<int>> Player_int;
    public static List<List<bool>> Player_bool;
    public static List<int[]> Player_inta;
    public static List<Vector3> Transform_Vector3;
    public static List<int> BlockController_int;
    public static int TurnManager_int;
    public static bool PurpleChooser_bool;

    public static int save_no = 1;

    public static int winnerNo = 0;
    public static int winner = 0;
    public static int swinner = 0;
    public static int twinner = 0;
    public static int fwinner = 0;

}
