using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Build carBuild;

    private void Start()
    {
        GameManager gameManager = GameManager.Instance;

        if (gameManager != null)
        {
            carBuild = gameManager.GetCarBuild();
        }
        else
        {
            Debug.LogError("GameManager bulunamadý!");
        }
    }

    // Diðer kodlar...
}
