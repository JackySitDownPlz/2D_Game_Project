using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public int steps;
    public int inv_steps;
    CatController CC;
    public bool choosingDirection;
    private ArrowControl AC;
    public bool interacting;
    public bool CanInteractWithBlock;

    // Start is called before the first frame update
    void Start()
    {
        AC = GameObject.FindWithTag("Arrow").GetComponent<ArrowControl>();
        CC = GetComponent<CatController>();
        choosingDirection = false;
        CanInteractWithBlock = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (interacting)
        {

        }
        else if ((inv_steps > 0 || steps > 0) && CC.move_x == 0 && CC.move_y == 0 && !choosingDirection)
        {
            if (!CC.CrossRoad)
            {
                if (CC.back_direction != 1 && CC.up_walkable)
                {
                    CC.MoveDirection(1);
                }
                if (CC.back_direction != 2 && CC.down_walkable)
                {
                    CC.MoveDirection(2);
                }
                if (CC.back_direction != 3 && CC.left_walkable)
                {
                    CC.MoveDirection(3);
                }
                if (CC.back_direction != 4 && CC.right_walkable)
                {
                    CC.MoveDirection(4);
                }
            }
            else
            {
                ChooseDirection();
                choosingDirection = true;
            }
        }
        else if (steps < 0)
        {
            steps = 0;
        }
        
    }
    void ChooseDirection()
    {
        if (CC.back_direction != 1 && CC.up_walkable)
        {
            AC.showArrow("up");
        }
        else
        {
            AC.hideArrow("up");
        }
        if (CC.back_direction != 2 && CC.down_walkable)
        {
            AC.showArrow("down");
        }
        else
        {
            AC.hideArrow("down");
        }
        if (CC.back_direction != 3 && CC.left_walkable)
        {
            AC.showArrow("left");
        }
        else
        {
            AC.hideArrow("left");
        }
        if (CC.back_direction != 4 && CC.right_walkable)
        {
            AC.showArrow("right");
        }
        else
        {
            AC.hideArrow("right");
        }
    }
    

}
