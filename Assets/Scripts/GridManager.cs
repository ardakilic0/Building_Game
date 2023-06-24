using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private GameObject[] _buildPrefabs;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y, 165f), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
            }
        }
    }

    public void PlaceBuildOnTile(GameObject buildPrefab, Tile tile)
    {
        if (!tile.isOccupied)
        {
            var spawnedBuild = Instantiate(buildPrefab, tile.transform.position, Quaternion.identity);
            spawnedBuild.GetComponent<Draggable>().ReturnToOriginalPosition();
            tile.isOccupied = true;
        }
    }
}
