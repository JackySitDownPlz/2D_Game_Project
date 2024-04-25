using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DiceHandler : MonoBehaviour
{
    public GameObject Dice1;
    public GameObject Dice2;
    public GameObject Dice3;
    //private Image dice_image;
    //public Sprite dice_one;
    //public Sprite dice_two;
    //public Sprite dice_three;
    //public Sprite dice_four;
    //public Sprite dice_five;
    //public Sprite dice_six;
    public int roll_result;
    public int roll_res1;
    public int roll_res2;
    public int roll_res3;
    Animator animator1;
    Animator animator2;
    Animator animator3;
    private float roll_timer = 0;
    public float rolltime;
    public GameObject current_player;
    private bool stopped;
    public GameObject Inventory;
    



    // Start is called before the first frame update
    void Start()
    {
        //dice_image = Dice.GetComponent<Image>();
        animator1 = Dice1.GetComponent<Animator>();
        animator2 = Dice2.GetComponent<Animator>();
        animator3 = Dice3.GetComponent<Animator>();
        stopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        current_player = GameObject.FindGameObjectWithTag("CPlayer");
        if (roll_timer >= 0.5)
        {
            Dice1.GetComponent<CanvasGroup>().interactable = false;
            Dice2.GetComponent<CanvasGroup>().interactable = false;
            Dice3.GetComponent<CanvasGroup>().interactable = false;
            Inventory.GetComponent<CanvasGroup>().interactable = false;
            Inventory.GetComponent<CanvasGroup>().alpha = 0f;

            animator1.SetBool("Roll", true);
            animator2.SetBool("Roll", true);
            animator3.SetBool("Roll", true);
            roll_timer -= Time.deltaTime;
            stopped = false;
        }
        else if (roll_timer > 0 && roll_timer < 0.5 && !stopped)
        {
            animator1.SetBool("Roll", false);
            animator2.SetBool("Roll", false);
            animator3.SetBool("Roll", false);
            roll_timer -= Time.deltaTime;
            stopped = false;
        }
        else if (roll_timer <= 0 && !stopped)
        {
            MoveManager MM = current_player.GetComponent<MoveManager>();
            roll_result = roll_res1 + roll_res2 + roll_res3;
            MM.steps = roll_result;
            stopped = true;
        }

        
    }
    public void RollDice()
    {
        roll_timer = rolltime;
        roll_res1 = Random.Range(1, 7);
        roll_res2 = Random.Range(1, 7);
        roll_res3 = Random.Range(1, 7);
        switch (roll_res1)
        {
            case 1:
                animator1.SetInteger("result", 1);
                break;
            case 2:
                animator1.SetInteger("result", 2);
                break;
            case 3:
                animator1.SetInteger("result", 3);
                break;
            case 4:
                animator1.SetInteger("result", 4);
                break;
            case 5:
                animator1.SetInteger("result", 5);
                break;
            case 6:
                animator1.SetInteger("result", 6);
                break;
        }
        switch (roll_res2)
        {
            case 1:
                animator2.SetInteger("result", 1);
                break;
            case 2:
                animator2.SetInteger("result", 2);
                break;
            case 3:
                animator2.SetInteger("result", 3);
                break;
            case 4:
                animator2.SetInteger("result", 4);
                break;
            case 5:
                animator2.SetInteger("result", 5);
                break;
            case 6:
                animator2.SetInteger("result", 6);
                break;
        }
        switch (roll_res3)
        {
            case 1:
                animator3.SetInteger("result", 1);
                break;
            case 2:
                animator3.SetInteger("result", 2);
                break;
            case 3:
                animator3.SetInteger("result", 3);
                break;
            case 4:
                animator3.SetInteger("result", 4);
                break;
            case 5:
                animator3.SetInteger("result", 5);
                break;
            case 6:
                animator3.SetInteger("result", 6);
                break;
        }
    }
}
