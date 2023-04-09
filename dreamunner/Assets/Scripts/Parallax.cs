using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float endX = -20f;
    [SerializeField] private float startX = 20f;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endX)
        {
            transform.position = new Vector2(startX, transform.position.y);
        }
    }
}