using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text healthText = null;
    [SerializeField] private AudioClip hitSound = null;
    [SerializeField] private AudioClip starDestroySound = null;
    [SerializeField] private int health = 5;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private int score = 0;
    private int highScore = 0;
    private string highScoreKey = "Highscore";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        scoreText.text = "Score: " + score;
        healthText.text = "HP: " + health;
    }

    private void Update()
    {
        CheckIfDead();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        ClampPlayerPosition();
    }

    private void MovePlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.velocity = movement * moveSpeed;

        spriteRenderer.flipX = moveHorizontal < 0 ? true : false;
    }

    private void ClampPlayerPosition()
    {
        Vector3 playerPos = Camera.main.WorldToViewportPoint(transform.position);
        playerPos.x = Mathf.Clamp(playerPos.x, 0.1f, 0.9f);
        playerPos.y = Mathf.Clamp(playerPos.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(playerPos);
    }

    private void CheckIfDead()
    {
        if (health <= 0)
        {
            SaveScore();
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(highScoreKey, highScore);
        }
    }

    private IEnumerator BlinkHealthText()
    {
        for (int i = 0; i < 6; i++)
        {
            healthText.color = i % 2 == 0 ? Color.red : Color.yellow;
            yield return new WaitForSeconds(0.1f);
        }
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
            LoseHealth();
            audioSource.PlayOneShot(hitSound);
            health--;
            StartCoroutine(BlinkHealthText());
            healthText.text = "HP: " + health;
        }
    }

    public void LoseHealth()
    {
        // To be implemented
    }
}