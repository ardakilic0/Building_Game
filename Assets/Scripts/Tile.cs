using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied = false;
    public Build build;
    [SerializeField] private GameObject _highlight;
    public Sprite emptyTileSprite;
    public Sprite occupiedTileSprite;
    public Build currentBuild { get; set; }

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = emptyTileSprite; // Ba�lang��ta tile'�n bo� sprite'�n� ayarla
        _highlight.SetActive(false); // Highlight'� ba�lang��ta devre d��� b�rak
    }

    void OnMouseEnter()
    {
        if (!isOccupied)
        {
            _highlight.SetActive(true); // Fare imleci Tile nesnesine girdi�inde highlight'� etkinle�tir
        }
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false); // Fare imleci Tile nesnesinden ��kt���nda highlight'� devre d��� b�rak
    }


    public void ClearTile()
    {
        isOccupied = false;
        spriteRenderer.sprite = emptyTileSprite; // Tile'� bo� sprite'�yla g�ncelle

        _highlight.SetActive(false); // Highlight'� kapat
    }

    public void SetOccupiedTile()
    {
        isOccupied = true;
        spriteRenderer.sprite = occupiedTileSprite; // Tile'� dolu sprite'�yla g�ncelle

        _highlight.SetActive(false); // Highlight'� kapat
    }

}
