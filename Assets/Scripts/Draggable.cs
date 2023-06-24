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
        Debug.Log("Ba�lat�a��r");
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
            buildPosition.z = currentTile.transform.position.z - 0.5f; // Z-koordinat�n� biraz daha d���k ayarla
            transform.position = buildPosition;
            currentTile.isOccupied = true; // Tile'� i�gal edilmi� olarak i�aretle
            currentTile.SetOccupiedTile(); // Tile'�n g�r�n�m�n� de�i�tir
            
            GameManager.Instance.RemoveGold(currentBuild.goldCost);// burda d���r goldu
            GameManager.Instance.RemoveGem(currentBuild.gemCost);
        }
        else
        {
            // E�er tile i�gal edilmi�se veya herhangi bir tile �zerinde de�ilse, build'i ilk konumuna geri d�nd�r
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

            // Tile'lar� kontrol et
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
