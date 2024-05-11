using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

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
    public AudioClip hurt;
    public AudioClip heal;
    public AudioClip get;
    public AudioClip lose;
    public AudioClip item;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        TM = GameObject.FindWithTag("TurnManager").GetComponent<TurnManager>();
        ChooseRandomBlockface();
        

    }
    void Update()
    {
        switch (block_type)
        {
            case 1:
                spriteRenderer.sprite = green_A;
                break;
            case 2:
                spriteRenderer.sprite = green_B;
                break;
            case 3:
                spriteRenderer.sprite = green_C;
                break;
            case 4:
                spriteRenderer.sprite = green_D;
                break;
            case 5:
                spriteRenderer.sprite = green_E;
                break;
            case 6:
                spriteRenderer.sprite = green_F;
                break;
            case 7:
                spriteRenderer.sprite = red_A;
                break;
            case 8:
                spriteRenderer.sprite = red_B;
                break;
            case 9:
                spriteRenderer.sprite = red_C;
                break;
            case 10:
                spriteRenderer.sprite = red_D;
                break;
            case 11:
                spriteRenderer.sprite = red_E;
                break;
            case 12:
                spriteRenderer.sprite = red_F;
                break;
            case 13:
                spriteRenderer.sprite = yellow;
                break;
            case 14:
                spriteRenderer.sprite = grey;
                break;
            case 15:
                spriteRenderer.sprite = purple;
                break;
        }
    }

    public void ChooseRandomBlockface()
    {
        block_no = Random.Range(1, 100);
        if (block_no <= 14)
        {
            block_type = 1;
        }
        else if (block_no <= 23)
        {
            block_type = 2;
        }
        else if (block_no <= 27)
        {
            block_type = 3;
        }
        else if (block_no <= 30)
        {
            block_type = 4;
        }
        else if (block_no <= 39)
        {
            block_type = 5;
        }
        else if (block_no <= 44)
        {
            block_type = 6;
        }
        else if (block_no <= 50)
        {
            block_type = 7;
        }
        else if (block_no <= 53)
        {
            block_type = 8;
        }
        else if (block_no <= 54)
        {
            block_type = 9;
        }
        else if (block_no <= 56)
        {
            block_type = 10;
        }
        else if (block_no <= 66)
        {
            block_type = 11;
        }
        else if (block_no <= 70)
        {
            block_type = 12;
        }
        else if (block_no <= 90)
        {
            block_type = 13;
        }
        else
        {
            block_type = 14;
        }

        if (startingpoint)
        {
            block_type = 14;
        }
    }
    public void change_purple()
    {
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
        if (block_type == 15 && MM.CanInteractWithBlock)
        {
            MM.interacting = true;
            Dialog.SetActive(true);

        }
        if (MM.steps <= 0 && !startingpoint && !invisible && MM.CanInteractWithBlock)
        {
            switch (block_type)
            {
                case 1:
                    PI.catfood += 1;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player Gains 1 CatFood!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(get);
                    break;
                case 2:
                    PI.catfood += 3;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player Gains 3 CatFood!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(get);
                    break;
                case 3:
                    PI.catfood += 5;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player Gains 5 CatFood!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(get);
                    break;
                case 4:
                    PI.HP += 7;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player HP Is Increased By 7!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(heal);
                    break;
                case 5:
                    PI.HP += 3;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player HP Is Increased By 3!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(heal);
                    break;
                case 6:
                    PI.HP += 5;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player HP Is Increased By 5!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(heal);
                    break;
                case 7:
                    PI.catfood -= 1;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player Loses 1 CatFood!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(lose);
                    break;
                case 8:
                    PI.catfood -= 3;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player Loses 3 CatFood!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(lose);
                    break;
                case 9:
                    PI.catfood -= 5;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player Loses 5 CatFood!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(lose);
                    break;
                case 10:
                    PI.HP -= 7;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player HP Is Decreased By 7!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(hurt);
                    other.GetComponent<Animator>().SetBool("TakeDamage", true);
                    StartCoroutine(HurtCoroutine(other));
                    break;
                case 11:
                    PI.HP -= 3;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player HP Is Decreased By 3!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(hurt);
                    other.GetComponent<Animator>().SetBool("TakeDamage", true);
                    StartCoroutine(HurtCoroutine(other));
                    break;
                case 12:
                    PI.HP -= 5;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player HP Is Decreased By 5!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(hurt);
                    other.GetComponent<Animator>().SetBool("TakeDamage", true);
                    StartCoroutine(HurtCoroutine(other));
                    break;
                case 13:
                    int random = Random.Range(0, 8);
                    PI.items[random] += 1;
                    GameObject.FindWithTag("Notice").GetComponent<TMP_Text>().text = "Player Gets A Random Skill!";
                    GameObject.FindWithTag("SoundEffect").GetComponent<AudioSource>().PlayOneShot(item);
                    break;
                case 14:
                    break;
                case 15:
                    break;
            }
            MM.CanInteractWithBlock = false;
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

    private System.Collections.IEnumerator HurtCoroutine(Collider2D other)
    {
        yield return new WaitForSeconds(1f);
        other.GetComponent<Animator>().SetBool("TakeDamage", false);
    }
}
