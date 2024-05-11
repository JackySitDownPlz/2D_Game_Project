using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    //float horizontal;
    //float vertical;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    public float speed = 3.0f;
    public float move_x;
    public float move_y;
    float step;
    public int back_direction; //1:up 2:down 3:left 4:right
    public bool left_walkable;
    public bool right_walkable;
    public bool up_walkable;
    public bool down_walkable;
    public int OnBlockType;
    public int WalkStep;
    public bool CrossRoad;
    private bool walking;
    public AudioSource AS;
    public AudioClip Aclip;
    



    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        step = 50;
        back_direction = 1;
        walking = false;
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(move_x, move_y);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if ((move_x != 0 || move_y != 0) && !walking)
        {
            Debug.Log("Walking");
            StartCoroutine(SoundCoroutine());
            walking = true;
        }

    }

    private System.Collections.IEnumerator SoundCoroutine()
    {
        AS.PlayOneShot(Aclip);
        yield return new WaitForSeconds(0.5f);
        if(move_x * move_y != 0)
        {
            StartCoroutine(SoundCoroutine());
        }
        else
        {
            walking = false;
        }
    }

    void FixedUpdate()
    {
        
        //Vector2 position = rigidbody2d.position;
        //position.x = position.x + speed * horizontal * Time.deltaTime;
        //position.y = position.y + speed * vertical * Time.deltaTime;
        //rigidbody2d.MovePosition(position);
        if (move_x > 0)
        {
            Walk_Right();
            move_x -= 1 / step;
        }
        else if (move_x < 0)
        {
            Walk_Left();
            move_x += 1 / step;
        }
        else if (move_y > 0)
        {
            Walk_Up();
            move_y -= 1 / step;
        }
        else if (move_y < 0)
        {
            Walk_Down();
            move_y += 1 / step;
        }
        move_x = Mathf.Round(move_x * 100f) / 100f;
        move_y = Mathf.Round(move_y * 100f) / 100f;

        if (move_x == 0 && move_y == 0)
        {
            Vector2 position = rigidbody2d.position;
            position.y = Mathf.Round(position.y * 10f) / 10f;
            position.x = Mathf.Round(position.x * 10f) / 10f;
            rigidbody2d.MovePosition(position);
        }
        
    }
    public void Walk_Down()
    {
        Vector2 position = rigidbody2d.position;
        position.y = position.y - 2 / step;
        rigidbody2d.MovePosition(position);
        back_direction = 1;
    }
    public void Walk_Up()
    {
        Vector2 position = rigidbody2d.position;
        position.y = position.y + 2 / step;
        rigidbody2d.MovePosition(position);
        back_direction = 2;
    }
    public void Walk_Left()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x - 2 / step;
        rigidbody2d.MovePosition(position);
        back_direction = 4;
    }
    public void Walk_Right()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 2 / step;
        rigidbody2d.MovePosition(position);
        back_direction = 3;
    }
    public void MoveDirection(int direction)
    {
        if (direction == 1) {
            move_y = 1;
        }else if (direction == 2)
        {
            move_y = -1;
        }else if (direction == 3)
        {
            move_x = -1;
        }else if (direction == 4)
        {
            move_x = 1;
        }
    }
}
