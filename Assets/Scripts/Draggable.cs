using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 originalPosition;
    private Tile currentTile;
    private Collider2D objCollider;
    private Tile previousTile;
    private Build currentBuild;

    int goldprice;

    [SerializeField] private GameObject _highlight;
    [SerializeField] private LayerMask tileLayer;

    public void Initialize(Build build)
    {
        currentBuild = build;
        Debug.Log("Baþlatçaðýr");
    }
    void Start()
    {
        objCollider = GetComponent<Collider2D>();
        currentBuild = GetComponent<Build>();
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    public void ReturnToOriginalPosition()
    {
        transform.position = originalPosition;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        originalPosition = transform.position;

        if (currentTile != null)
        {
            previousTile = currentTile;
            previousTile.ClearTile();
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        Debug.Log("yazburda");
        if (currentTile != null && !currentTile.isOccupied)
        {
            Vector3 buildPosition = currentTile.transform.position;
            buildPosition.z = currentTile.transform.position.z - 0.5f; // Z-koordinatýný biraz daha düþük ayarla
            transform.position = buildPosition;
            currentTile.isOccupied = true; // Tile'ý iþgal edilmiþ olarak iþaretle
            currentTile.SetOccupiedTile(); // Tile'ýn görünümünü deðiþtir
            
            GameManager.Instance.RemoveGold(currentBuild.goldCost);// burda düþür goldu
            GameManager.Instance.RemoveGem(currentBuild.gemCost);
        }
        else
        {
            // Eðer tile iþgal edilmiþse veya herhangi bir tile üzerinde deðilse, build'i ilk konumuna geri döndür
            transform.position = originalPosition;
        }

        if (previousTile != null && previousTile != currentTile)
        {
            previousTile.ClearTile();
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = +163.1f;

            transform.position = mousePosition;

            // Tile'larý kontrol et
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, tileLayer);
            if (hit.collider != null)
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                if (tile != null)
                {
                    currentTile = tile;
                }
            }
            else
            {
                currentTile = null;
            }
        }
    }
}
