using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private Build houseBuild;

    private void Start()
    {
        GameManager gameManager = GameManager.Instance;

        if (gameManager != null)
        {
            houseBuild = gameManager.GetHouseBuild();
        }
        else
        {
            Debug.LogError("GameManager bulunamadý!");
        }
    }

    // Diðer kodlar...
}
