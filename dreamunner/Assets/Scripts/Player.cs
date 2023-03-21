using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int score = 0;
    public Text scoreText;
    public int health = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        rb.velocity = movement * moveSpeed;

        if(movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "Score: " + score.ToString();
        }
    }
}