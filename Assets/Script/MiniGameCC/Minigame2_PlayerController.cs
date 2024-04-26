using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2_PlayerController : MonoBehaviour
{
    public int playerID;
    public int score;

    public float speed = 5f;
    public float jumpSpeed = 8.5f;
    private float direction = 0f;
    private Rigidbody2D player;

    private float player1_horizontal;
    private float player1_vertical;
    private float player2_horizontal;
    private float player2_vertical;
    private float player3_horizontal;
    private float player3_vertical;
    private float player4_horizontal;
    private float player4_vertical;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public static bool endGame;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        endGame = false;
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (playerID == 1)
        {
            player1_horizontal = Input.GetAxis("Player1Horizontal");
            player1_vertical = Input.GetAxis("Player1Vertical");

            Vector2 move = new Vector2(player1_horizontal, player1_vertical);
            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);

            if (player1_horizontal > 0f)
            {
                player.velocity = new Vector2(player1_horizontal * speed, player.velocity.y);
                animator.SetFloat("Look X", lookDirection.x);
            }
            else if (player1_horizontal < 0f)
            {
                player.velocity = new Vector2(player1_horizontal * speed, player.velocity.y);
                animator.SetFloat("Look X", lookDirection.x);
            }
            else
            {
                player.velocity = new Vector2(0, player.velocity.y);
            }

            if (Input.GetAxis("Player1Jump") > 0f && isTouchingGround)
            {
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            }
        }

        if (playerID == 2)
        {
            player2_horizontal = Input.GetAxis("Player2Horizontal");
            player2_vertical = Input.GetAxis("Player2Vertical");

            Vector2 move = new Vector2(player2_horizontal, player2_vertical);
            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);

            if (player2_horizontal > 0f)
            {
                player.velocity = new Vector2(player2_horizontal * speed, player.velocity.y);
                animator.SetFloat("Look X", lookDirection.x);
            }
            else if (player2_horizontal < 0f)
            {
                player.velocity = new Vector2(player2_horizontal * speed, player.velocity.y);
                animator.SetFloat("Look X", lookDirection.x);
            }
            else
            {
                player.velocity = new Vector2(0, player.velocity.y);
            }

            if (Input.GetAxis("Player2Jump") > 0f && isTouchingGround)
            {
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            }
        }

        if (playerID == 3)
        {
            player3_horizontal = Input.GetAxis("Player3Horizontal");
            player3_vertical = Input.GetAxis("Player3Vertical");

            Vector2 move = new Vector2(player3_horizontal, player3_vertical);
            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);

            if (player3_horizontal > 0f)
            {
                player.velocity = new Vector2(player3_horizontal * speed, player.velocity.y);
                animator.SetFloat("Look X", lookDirection.x);
            }
            else if (player3_horizontal < 0f)
            {
                player.velocity = new Vector2(player3_horizontal * speed, player.velocity.y);
                animator.SetFloat("Look X", lookDirection.x);
            }
            else
            {
                player.velocity = new Vector2(0, player.velocity.y);
            }

            if (Input.GetAxis("Player3Jump") > 0f && isTouchingGround)
            {
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            }
        }

        if (playerID == 4)
        {
            player4_horizontal = Input.GetAxis("Player4Horizontal");
            player4_vertical = Input.GetAxis("Player4Vertical");

            Vector2 move = new Vector2(player4_horizontal, player4_vertical);
            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);

            if (player4_horizontal > 0f)
            {
                player.velocity = new Vector2(player4_horizontal * speed, player.velocity.y);
                animator.SetFloat("Look X", lookDirection.x);
            }
            else if (player4_horizontal < 0f)
            {
                player.velocity = new Vector2(player4_horizontal * speed, player.velocity.y);
                animator.SetFloat("Look X", lookDirection.x);
            }
            else
            {
                player.velocity = new Vector2(0, player.velocity.y);
            }

            if (Input.GetAxis("Player4Jump") > 0f && isTouchingGround)
            {
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            }
        }
    }

    void FixedUpdate()
    {
        if (!Timer.timerIsRunning)
        {
            endGame = true;
        }

        if (endGame)
        {
            player.velocity = new Vector2(0, 0);
        }
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int scoreValue)
    {
        score = scoreValue;
    }
}
