using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Build shipBuild;

    private void Start()
    {
        GameManager gameManager = GameManager.Instance;

        if (gameManager != null)
        {
            shipBuild = gameManager.GetShipBuild();
        }
        else
        {
            Debug.LogError("GameManager bulunamadý!");
        }
    }

    // Diðer kodlar...
}
