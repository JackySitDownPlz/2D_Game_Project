using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ArrowControl : MonoBehaviour
{
    public GameObject arrow_up;
    public GameObject arrow_down;
    public GameObject arrow_left;
    public GameObject arrow_right;
    private GameObject current_player;
    private MoveManager MM;
    private CatController CC;
    // Start is called before the first frame update
    void Start()
    {
        arrow_up.SetActive(false);
        arrow_down.SetActive(false);
        arrow_left.SetActive(false);
        arrow_right.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        current_player = GameObject.FindWithTag("CPlayer");
        MM = current_player.GetComponent<MoveManager>();
        CC = current_player.GetComponent<CatController>();
    }
    public void showArrow(string arrowName)
    {
        switch (arrowName)
        {
            case "up":
                arrow_up.SetActive(true);
                break;
            case "down":
                arrow_down.SetActive(true);
                break;
            case "left":
                arrow_left.SetActive(true);
                break;
            case "right":
                arrow_right.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void hideArrow(string arrowName)
    {
        switch (arrowName)
        {
            case "up":
                arrow_up.SetActive(false);
                break;
            case "down":
                arrow_down.SetActive(false);
                break;
            case "left":
                arrow_left.SetActive(false);
                break;
            case "right":
                arrow_right.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void ChooseUp()
    {
        DisableArrows();
        CC.MoveDirection(1);
        MM.choosingDirection = false;
    }
    public void ChooseDown()
    {
        DisableArrows();
        CC.MoveDirection(2);
        MM.choosingDirection = false;
    }
    public void ChooseLeft()
    {
        DisableArrows();
        CC.MoveDirection(3);
        MM.choosingDirection = false;
    }
    public void ChooseRight()
    {
        DisableArrows();
        CC.MoveDirection(4);
        MM.choosingDirection = false;
    }
    void DisableArrows()
    {
        hideArrow("up");
        hideArrow("down");
        hideArrow("left");
        hideArrow("right");
    }
}
