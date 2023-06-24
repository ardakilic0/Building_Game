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
        spriteRenderer.sprite = emptyTileSprite; // Baþlangýçta tile'ýn boþ sprite'ýný ayarla
        _highlight.SetActive(false); // Highlight'ý baþlangýçta devre dýþý býrak
    }

    void OnMouseEnter()
    {
        if (!isOccupied)
        {
            _highlight.SetActive(true); // Fare imleci Tile nesnesine girdiðinde highlight'ý etkinleþtir
        }
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false); // Fare imleci Tile nesnesinden çýktýðýnda highlight'ý devre dýþý býrak
    }


    public void ClearTile()
    {
        isOccupied = false;
        spriteRenderer.sprite = emptyTileSprite; // Tile'ý boþ sprite'ýyla güncelle

        _highlight.SetActive(false); // Highlight'ý kapat
    }

    public void SetOccupiedTile()
    {
        isOccupied = true;
        spriteRenderer.sprite = occupiedTileSprite; // Tile'ý dolu sprite'ýyla güncelle

        _highlight.SetActive(false); // Highlight'ý kapat
    }

}
