using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(AudioSource))] // 1
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text healthText = null;
    [SerializeField] private AudioClip hitSound = null; // 22
    [SerializeField] private AudioClip starDestroySound = null; // 22
    [SerializeField] private int health = 5;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private int score = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        scoreText.text = "Score: " + score;
        healthText.text = "HP: " + health;
    }

    private void Update()
    {
        if (health <= 0)
        {
            PlayerPrefs.SetInt("Score", score); // 33
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.velocity = movement * moveSpeed;

        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        Vector3 playerPos = Camera.main.WorldToViewportPoint(transform.position);
        playerPos.x = Mathf.Clamp01(playerPos.x);
        playerPos.y = Mathf.Clamp01(playerPos.y);
        transform.position = Camera.main.ViewportToWorldPoint(playerPos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(starDestroySound);
            score++;
            scoreText.text = "Score: " + score;
        }
        else if (other.CompareTag("Enemy"))
        {
            health--;
            healthText.text = "HP: " + health;
            audioSource.PlayOneShot(hitSound);
        }
    }

    public void LoseHealth()
    {
        health--;
        healthText.text = "HP: " + health;
    }
}