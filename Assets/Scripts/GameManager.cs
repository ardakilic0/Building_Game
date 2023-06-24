using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    UI_Source UýManager;

    private int currentGold = 10;
    private int currentGem = 10;

    private bool isBuildEnabled = true;

    public int gold = 10;
    public int gem = 10;
    public GameObject pawnPrefab;
    public GameObject carPrefab;
    public GameObject housePrefab;
    public GameObject shipPrefab;
    public GameObject trainPrefab;
    public GameObject castlePrefab;
    public Text goldText;
    public Text gemText;
    public Draggable draggable;

    private Build pawn;
    private Build car;
    private Build house;
    private Build ship;
    private Build train;
    private Build castle;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //UýManager.goldText.text = gold.ToString();
    }

    private void Start()
    {
        // Buildleri oluþtur
        pawn = new Build("Pawn", 1, 0, pawnPrefab);
        car = new Build("Car", 1, 1, carPrefab);
        house = new Build("House", 2, 1, housePrefab);
        ship = new Build("Ship", 2, 3, shipPrefab);
        train = new Build("Train", 3, 3, trainPrefab);
        castle = new Build("Castle", 5, 4, castlePrefab);
        Debug.Log(gold);

        UýManager = GameObject.FindWithTag("Canvas").GetComponent<UI_Source>();

        gold = 10;
        gem = 10;
        UýManager.FixCuzdan();
    }

    public void UseBuild(Build build)
    {
        if (GetGoldAmount() >= build.goldCost && GetGemAmount() >= build.gemCost)
        {
            RemoveGold(build.goldCost);
            RemoveGem(build.gemCost);

            Debug.Log("Build " + build.name + " kullanýldý.");

            FindObjectOfType<UI_Source>().RemoveGold(build.goldCost);
            FindObjectOfType<UI_Source>().RemoveGem(build.gemCost);
        }
        else
        {
            Debug.Log("Yetersiz kaynaklar.");
        }
    }

    public int GetGoldAmount()
    {
        return gold;
    }

    public int GetGemAmount()
    {
        return gem;
    }

    public void RemoveGold(int amount)
    {
        gold -= amount;
        Debug.Log(gold);
        UýManager.UpdateGoldText(gold);
    }

    public void RemoveGem(int amount)
    {
        gem -= amount;
        UýManager.UpdateGemText(gem);
    }

    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void AddGem(int amount)
    {
        gem += amount;
    }

    public void PlaceBuildOnTile(Build build, Tile tile)
    {
        draggable.Initialize(build);

       /* if (build != null && tile != null && !tile.isOccupied)
        {
            Debug.Log("bunugör");
            Vector3 buildPosition = tile.transform.position;
            buildPosition.z = tile.transform.position.z - 0.5f;
            build.transform.position = buildPosition;

            build.transform.SetParent(tile.transform);

            tile.isOccupied = true;
            tile.SetOccupiedTile();
            RemoveGold(build.goldCost);
            UpdateGoldText();
        }
        else
        {
            Debug.LogError("Invalid build or tile, or tile is already occupied.");
        }*/
    }


    public void RemoveBuildFromTile(Build build, Tile tile)
    {
        tile.currentBuild = null;
        build.SetTile(null);
        build.transform.SetParent(null);
    }

    private void UpdateGoldText()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + gold.ToString();
        }
    }

    public Build GetPawnBuild()
    {
        return ship;
    }
    public Build GetCarBuild()
    {
        return ship;
    }
    public Build GetHouseBuild()
    {
        return ship;
    }
    public Build GetShipBuild()
    {
        return ship;
    }
    public Build GetTrainBuild()
    {
        return ship;
    }
    public Build GetCastleBuild()
    {
        return ship;
    }
}
