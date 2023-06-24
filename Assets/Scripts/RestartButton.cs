using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isHighlighted = false;
    [SerializeField] private GameObject _highlight;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        if (!isHighlighted)
        {
            _highlight.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (!isHighlighted)
        {
            _highlight.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        RestartGame();
    }

    private void RestartGame()
    {
        // Aktif sahneyi yeniden yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
