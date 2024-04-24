using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
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

    public bool left;
    public bool right;
    public bool up;
    public bool down;
    public bool CrossRoad;
    public bool startingpoint;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ChooseRandomBlockface();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private System.Collections.IEnumerator TurnEndCoroutine()
    {
        Debug.Log("Coroutine started");

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);
        Debug.Log("Coroutine finished");
    }

    void ChooseRandomBlockface()
    {
        block_no = Random.Range(1, 100);
        if (block_no <= 7)
        {
            spriteRenderer.sprite = green_A;
            block_type = 1;
        }
        else if (block_no <= 12)
        {
            spriteRenderer.sprite = green_B;
            block_type = 2;
        }
        else if (block_no <= 15)
        {
            spriteRenderer.sprite = green_C;
            block_type = 3;
        }
        else if (block_no <= 17)
        {
            spriteRenderer.sprite = green_D;
            block_type = 4;
        }
        else if (block_no <= 25)
        {
            spriteRenderer.sprite = green_E;
            block_type = 5;
        }
        else if (block_no <= 30)
        {
            spriteRenderer.sprite = green_F;
            block_type = 6;
        }
        else if (block_no <= 36)
        {
            spriteRenderer.sprite = red_A;
            block_type = 7;
        }
        else if (block_no <= 39)
        {
            spriteRenderer.sprite = red_B;
            block_type = 8;
        }
        else if (block_no <= 40)
        {
            spriteRenderer.sprite = red_C;
            block_type = 9;
        }
        else if (block_no <= 41)
        {
            spriteRenderer.sprite = red_D;
            block_type = 10;
        }
        else if (block_no <= 47)
        {
            spriteRenderer.sprite= red_E;
            block_type = 11;
        }
        else if (block_no <= 50)
        {
            spriteRenderer.sprite = red_F;
            block_type = 12;
        }
        else if (block_no <= 60)
        {
            spriteRenderer.sprite = yellow;
            block_type = 13;
        }
        else
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
        MoveManager MM = other.GetComponent<MoveManager>();
        PlayerInfo PI = other.GetComponent<PlayerInfo>();
        if (MM.steps<= 0 && !startingpoint)
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
                    int random = Random.Range(1, 9);
                    if (random < 9)
                    {
                        PI.items[random] += 1;
                    }
                    else
                    {

                    }
                    break;
                case 15:
                    break; ;
                default:
                    break;

            }
        }
        StartCoroutine(TurnEndCoroutine());




    }
    private void OnTriggerExit2D(Collider2D other)
    {
        MoveManager MM = other.GetComponent<MoveManager>();
        MM.steps -= 1;
    }
}
