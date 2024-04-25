using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class BlockController : MonoBehaviourPunCallbacks
{
    public TurnManager TM;
    private SpriteRenderer spriteRenderer;
    public Sprite green_A;
    public Sprite green_B;
    public Sprite green_C;
    public Sprite green_D;
    public Sprite green_E;
    public Sprite green_F;
    public Sprite red_A;
    public Sprite red_B;
    public Sprite red_C;
    public Sprite red_D;
    public Sprite red_E;
    public Sprite red_F;
    public Sprite yellow;
    public Sprite purple;
    public Sprite grey;
    private int block_no;
    public int block_type;
    public int block_id;

    public bool left;
    public bool right;
    public bool up;
    public bool down;
    public bool CrossRoad;
    public bool startingpoint;
    public bool invisible;
    public GameObject Dialog;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        TM = GameObject.FindWithTag("TurnManager").GetComponent<TurnManager>();
        ChooseRandomBlockface();


    }
    void Update()
    {

    }

    void ChooseRandomBlockface()
    {
        block_no = Random.Range(1, 100);
        if (block_no <= 14)
        {
            spriteRenderer.sprite = green_A;
            block_type = 1;
        }
        else if (block_no <= 23)
        {
            spriteRenderer.sprite = green_B;
            block_type = 2;
        }
        else if (block_no <= 27)
        {
            spriteRenderer.sprite = green_C;
            block_type = 3;
        }
        else if (block_no <= 30)
        {
            spriteRenderer.sprite = green_D;
            block_type = 4;
        }
        else if (block_no <= 39)
        {
            spriteRenderer.sprite = green_E;
            block_type = 5;
        }
        else if (block_no <= 44)
        {
            spriteRenderer.sprite = green_F;
            block_type = 6;
        }
        else if (block_no <= 50)
        {
            spriteRenderer.sprite = red_A;
            block_type = 7;
        }
        else if (block_no <= 53)
        {
            spriteRenderer.sprite = red_B;
            block_type = 8;
        }
        else if (block_no <= 54)
        {
            spriteRenderer.sprite = red_C;
            block_type = 9;
        }
        else if (block_no <= 56)
        {
            spriteRenderer.sprite = red_D;
            block_type = 10;
        }
        else if (block_no <= 66)
        {
            spriteRenderer.sprite = red_E;
            block_type = 11;
        }
        else if (block_no <= 70)
        {
            spriteRenderer.sprite = red_F;
            block_type = 12;
        }
        else if (block_no <= 90)
        {
            spriteRenderer.sprite = yellow;
            block_type = 13;
        }
        else
        {
            spriteRenderer.sprite = grey;
            block_type = 14;
        }

        if (startingpoint)
        {
            spriteRenderer.sprite = grey;
            block_type = 14;
        }
    }
    public void change_purple()
    {
        spriteRenderer.sprite = purple;
        block_type = 15;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        

        CatController CC = other.GetComponent<CatController>();
        MoveManager MM = other.GetComponent<MoveManager>();
        PlayerInfo PI = other.GetComponent<PlayerInfo>();

        if (invisible)
        {
            MM.inv_steps += 1;
        }

        if (CC != null)
        {
            CC.OnBlockType = block_type;
            if (left)
            {
                CC.left_walkable = true;
            }
            else
            {
                CC.left_walkable = false;
            }
            if (right)
            {
                CC.right_walkable = true;
            }
            else
            {
                CC.right_walkable = false;
            }
            if (up)
            {
                CC.up_walkable = true;
            }
            else
            {
                CC.up_walkable = false;
            }
            if (down)
            {
                CC.down_walkable = true;
            }
            else
            {
                CC.down_walkable = false;
            }
            if (CrossRoad)
            {
                CC.CrossRoad = true;
            }
            else
            {
                CC.CrossRoad = false;
            }
        }
        if (block_type == 15)
        {
            MM.interacting = true;
            Dialog.SetActive(true);

        }
        if (MM.steps <= 0 && !startingpoint && !invisible)
        {
            switch (block_type)
            {
                case 1:
                    PI.catfood += 1;
                    break;
                case 2:
                    PI.catfood += 3;
                    break;
                case 3:
                    PI.catfood += 5;
                    break;
                case 4:
                    PI.HP += 7;
                    break;
                case 5:
                    PI.HP += 3;
                    break;
                case 6:
                    PI.HP += 5;
                    break;
                case 7:
                    PI.catfood -= 1;
                    break;
                case 8:
                    PI.catfood -= 3;
                    break;
                case 9:
                    PI.catfood -= 5;
                    break;
                case 10:
                    PI.HP -= 7;
                    break;
                case 11:
                    PI.HP -= 3;
                    break;
                case 12:
                    PI.HP -= 5;
                    break;
                case 13:
                    int random = Random.Range(0, 8);
                    PI.items[random] += 1;
                    break;
                case 14:
                    break;
                case 15:
                    break;
            }
            StartCoroutine(TurnEndCoroutine(MM));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        MoveManager MM = other.GetComponent<MoveManager>();
        if (!invisible)
        {
            MM.steps -= 1;
        }
        else
        {
            MM.inv_steps -= 1;
        }
        

    }

    private System.Collections.IEnumerator TurnEndCoroutine(MoveManager MM)
    {
        yield return new WaitForSeconds(1.5f);
        if (MM.interacting)
        {
            StartCoroutine(TurnEndCoroutine(MM));
        }
        else
        {
            TM.SwitchTurn();
        }
        
    }
}
