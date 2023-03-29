using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Text scoreText;
    public Text healthText; // added healthText field
    private int score = 0;
    public int health = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        healthText.text = "HP: " + health.ToString(); // set initial health text
    }

    void FixedUpdate()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }

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

        Vector3 playerPos = Camera.main.WorldToViewportPoint(transform.position);

        playerPos.x = Mathf.Clamp(playerPos.x, 0.0f, 1.0f);
        playerPos.y = Mathf.Clamp(playerPos.y, 0.0f, 1.0f);
        transform.position = Camera.main.ViewportToWorldPoint(playerPos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "Score: " + score.ToString();
        }

        else if(other.CompareTag("Enemy"))
        {
            health--;
            healthText.text = "HP: " + health.ToString();
        }
    }

    public void LoseHealth() // method to decrease health and update healthText
    {
        health--;
        healthText.text = "HP: " + health.ToString();
    }
}