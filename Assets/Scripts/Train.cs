using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    private Build trainBuild;

    private void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            trainBuild = gameManager.GetTrainBuild();
        }
        else
        {
            Debug.LogError("GameManager bulunamadý!");
        }
    }

}
