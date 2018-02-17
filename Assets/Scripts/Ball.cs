using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSource;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Player or Opponent Paddle?
        if (collision.gameObject.name == "Player_Paddle" ||
            collision.gameObject.name == "Opponent_Paddle")
        {
            HandlePaddleHit(col: collision);
        }

        // Bottom or Top Wall?
        if (collision.gameObject.name == "Top_Wall" ||
            collision.gameObject.name == "Bottom_Wall")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBloop);
        }

        // LeftGoal or RightGoal
        if (collision.gameObject.name == "Left_Goal" ||
            collision.gameObject.name == "Right_Goal")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);

            if (collision.gameObject.name == "Left_Goal")
            {
                IncreaseTextUIScore("Opponent_Score");
            }

            if (collision.gameObject.name == "Right_Goal")
            {
                IncreaseTextUIScore("Player_Score");
            }

            transform.position = new Vector2(0, 0);
        }
    }

    private void HandlePaddleHit(Collision2D col)
    {
        float y = BallHitPaddleWhere(
            transform.position,
            col.transform.position,
            col.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if (col.gameObject.name == "Player_Paddle")
        {
            dir = new Vector2(1, y).normalized;
        }

        if (col.gameObject.name == "Opponent_Paddle")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed;

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);
    }

    private float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }

    void IncreaseTextUIScore(string textUIName)
    {
        var textUIComp = GameObject.Find(textUIName).GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score++;
        textUIComp.text = score.ToString();
    }
}
