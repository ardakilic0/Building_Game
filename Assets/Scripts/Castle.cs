using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    private Build castleBuild;

    private void Start()
    {
        GameManager gameManager = GameManager.Instance;

        if (gameManager != null)
        {
            castleBuild = gameManager.GetCastleBuild();
        }
        else
        {
            Debug.LogError("GameManager bulunamadý!");
        }
    }

    // Diðer kodlar...
}
