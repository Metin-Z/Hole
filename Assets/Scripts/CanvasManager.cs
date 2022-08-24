using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public int moneyCount;
    public TextMeshProUGUI moneyText;
    public void Awake()
    {
        moneyCount = PlayerPrefs.GetInt("key");
        moneyText.text = moneyCount.ToString();
    }
    public void SetTotalMoneyCount(int moneyValue)
    {
        moneyCount+=moneyValue;
        PlayerPrefs.SetInt("key", moneyCount);
        moneyText.text = moneyCount.ToString();       
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            moneyCount += 500;
        }
        moneyText.text = moneyCount.ToString();
    }
}
