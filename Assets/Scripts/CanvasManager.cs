using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public int moneyCount;
    public TextMeshProUGUI moneyText;
    public float playerSizeX,playerSizeZ;
    Controller _player;
    public void Awake()
    {
        _player = FindObjectOfType<Controller>();
        moneyCount = PlayerPrefs.GetInt("Money");
        moneyText.text = moneyCount.ToString();
       _player.transform.localScale = new Vector3(PlayerPrefs.GetFloat("ScaleX"), 1, PlayerPrefs.GetFloat("ScaleZ"));
    }
    public void SetTotalMoneyCount(int moneyValue)
    {
        moneyCount+=moneyValue;
        PlayerPrefs.SetInt("Money", moneyCount);
        moneyText.text = moneyCount.ToString();       
    }
    public void SetScaleSize(float xSize, float zSize)
    {
        playerSizeX = xSize;
        playerSizeZ = zSize;
        PlayerPrefs.SetFloat("ScaleX", playerSizeX);
        PlayerPrefs.SetFloat("ScaleZ", playerSizeZ);
        

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
