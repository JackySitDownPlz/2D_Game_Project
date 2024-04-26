using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1_PlayerController : MonoBehaviour
{
    public int playerID;
    public int score;

    public float speed = 3.0f;

    Rigidbody2D rigidbody2d;

    private float player1_horizontal;
    private float player1_vertical;
    private float player2_horizontal;
    private float player2_vertical;
    private float player3_horizontal;
    private float player3_vertical;
    private float player4_horizontal;
    private float player4_vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public static bool endGame;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        endGame = false;
        score = 0;
    }

    void Update()
    {
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
        }
    }
    void FixedUpdate()
    {
        if (!Timer.timerIsRunning)
        {
            endGame = true;
        }

        if (!endGame)
        {
            if (playerID == 1)
            {
                Vector2 position = rigidbody2d.position;
                position.x = position.x + speed * player1_horizontal * Time.deltaTime;
                position.y = position.y + speed * player1_vertical * Time.deltaTime;

                rigidbody2d.MovePosition(position);
            }

            if (playerID == 2)
            {
                Vector2 position = rigidbody2d.position;
                position.x = position.x + speed * player2_horizontal * Time.deltaTime;
                position.y = position.y + speed * player2_vertical * Time.deltaTime;

                rigidbody2d.MovePosition(position);
            }

            if (playerID == 3)
            {
                Vector2 position = rigidbody2d.position;
                position.x = position.x + speed * player3_horizontal * Time.deltaTime;
                position.y = position.y + speed * player3_vertical * Time.deltaTime;

                rigidbody2d.MovePosition(position);
            }

            if (playerID == 4)
            {
                Vector2 position = rigidbody2d.position;
                position.x = position.x + speed * player4_horizontal * Time.deltaTime;
                position.y = position.y + speed * player4_vertical * Time.deltaTime;

                rigidbody2d.MovePosition(position);
            }
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
}
