using UnityEngine;
using UnityEngine.SceneManagement;

public class SquareClickHandler : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("LoseScene");
    }
}