using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public int moneyCount;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI ScaleText;
    public TextMeshProUGUI SpeedText;
    float playerSizeX,playerSizeZ;
    Controller _player;
    UpgradeSystem _upgradeSystem;
    public void Awake()
    {
        _player = FindObjectOfType<Controller>();
        _upgradeSystem = FindObjectOfType<UpgradeSystem>();
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
        PlayerPrefs.SetFloat("ScaleX", xSize);
        PlayerPrefs.SetFloat("ScaleZ", zSize);        
    }
    public void SetSpeed(float Setspeed)
    {      
        PlayerPrefs.SetFloat("SpeedSet", Setspeed);       
    }
    public void SetSkin(float SetSkin)
    {
        PlayerPrefs.SetFloat("SkinSet", SetSkin);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            moneyCount += 500;
        }
        moneyText.text = moneyCount.ToString();
        ScaleText.text = _upgradeSystem.scaleUpMoney.ToString() + "$" + " "+"Scale++";
        SpeedText.text = _upgradeSystem.speedUpMoney.ToString() + "$" + " "+"Speed++";
    }
}
