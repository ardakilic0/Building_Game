using UnityEngine;

public class Build : MonoBehaviour
{
    public string name;
    public int goldCost;
    public int gemCost;
    public GameObject prefab;
    private Tile currentTile;

    public void SetTile(Tile tile)
    {
        currentTile = tile;
    }

    public Build(string name, int goldCost, int gemCost, GameObject prefab)
    {
        this.name = name;
        this.goldCost = goldCost;
        this.gemCost = gemCost;
        this.prefab = prefab;
    }
}
