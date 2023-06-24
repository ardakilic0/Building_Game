using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Source : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text gemText;

    private int currentGold = 10;
    private int currentGem = 10;

    void Start()
    {
        UpdateGoldText(GameManager.Instance.gold);
        UpdateGemText(GameManager.Instance.gem);

    }

    public void FixCuzdan()
    {
        UpdateGoldText(GameManager.Instance.gold);
        UpdateGemText(GameManager.Instance.gem);
    }
    public void UpdateGoldText(int NewGold)
    {
        goldText.text = NewGold.ToString();
    }

    public void UpdateGemText(int a)
    {
        gemText.text = a.ToString();
    }

    public void AddGold(int amount)
    {
        GameManager.Instance.AddGold(amount);
        //UpdateGoldText();
    }

    public void AddGem(int amount)
    {
        GameManager.Instance.AddGem(amount);
        UpdateGemText(GameManager.Instance.gem);
    }


    public void RemoveGold(int amount)
    {
        currentGold -= amount;
        //UpdateGoldText();
    }

    public void RemoveGem(int amount)
    {
        currentGem -= amount;
        UpdateGemText(GameManager.Instance.gem);
    }
}
