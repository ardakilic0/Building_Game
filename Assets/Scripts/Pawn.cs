using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    private Build pawnBuild;

    private void Start()
    {
        // GameManager'a eriþmek için GameManager nesnesini al
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            // Pawn buildini al
            pawnBuild = gameManager.GetPawnBuild();
        }
        else
        {
            Debug.LogError("GameManager bulunamadý!");
        }
    }
}