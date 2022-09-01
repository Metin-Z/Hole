using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    CanvasManager _canvasmanager;
    Controller _player;
    public float scaleMultiply;
    public int scaleUpId, ScaleUpValue,scaleUpMoney =250;
    public int speedUpId, SpeedUpValue,speedUpMoney =350;
    public int skinChangeId, SkinChangeValue,skinChangeMoney=500;
    public GameObject ScaleBuy, ScaleBuyMax,SpeedBuy,SpeedBuyMax,SkinBuy,SkinBuyMax;
    public GameObject noMoneyText;
    float playerX = 1,playerY = 1,playerZ = 1;
    public PlayerSettings settings;
    Vector3 PlayerSCALE;
    public List<Color> ChangeColor;
    public bool nextLevel = false;
    void Start()
    {
        _canvasmanager = FindObjectOfType<CanvasManager>();
        _player = FindObjectOfType<Controller>();
    }
    public void UpScale()
    {
        if (_canvasmanager.moneyCount >= scaleUpMoney)
        {
            scaleUpId++;
            ScaleUpValue = scaleUpId;
            PlayerPrefs.SetInt("ScaleUpControl", ScaleUpValue);
            _canvasmanager.SetTotalMoneyCount(-scaleUpMoney);
            Vector3 scale = new Vector3(_player.transform.localScale.x * scaleMultiply, _player.transform.localScale.y * scaleMultiply, _player.transform.localScale.z* scaleMultiply);
            _player.transform.DOScale(scale, .35f).SetEase(Ease.Linear);
            StartCoroutine(GetPrefScale());
        }
        else
        {
            noMoneyText.SetActive(true);
        }
    }
    public IEnumerator GetPrefScale()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerSCALE = _player.transform.localScale;
        playerX = PlayerSCALE.x;
        playerY = PlayerSCALE.y;
        playerZ = PlayerSCALE.z;
        _canvasmanager.SetScaleSize(playerX,playerY,playerZ);
    }
    public void UpSpeed()
    {
        if (_canvasmanager.moneyCount >= speedUpMoney)
        {
            speedUpId++;
            SpeedUpValue = speedUpId;
            PlayerPrefs.SetInt("SpeedUpControl", SpeedUpValue);
            _canvasmanager.SetTotalMoneyCount(-350);
            _player.speed += 0.95f;
            _canvasmanager.SetSpeed(_player.speed);
        }
        else
        {
            noMoneyText.SetActive(true);
        }
    }
    public void ChangeSkin()
    {
        if (_canvasmanager.moneyCount >= 150)
        {
            skinChangeId++;
            SkinChangeValue = skinChangeId;          
            _canvasmanager.SetTotalMoneyCount(-150);
            _player.transform.GetChild(1).GetComponent<MeshRenderer>().material.DOColor(ChangeColor[skinChangeId] ,1f);
            PlayerPrefs.SetInt("SkinChangeControl", SkinChangeValue);
        }
        else
        {
            noMoneyText.SetActive(true);
        }
    }
    public void Update()
    {
        if (PlayerPrefs.GetInt(CommonTypes.LEVEL_DATA_KEY) == 0)
        {
            scaleMultiply = 1.15f;
        }
        if (PlayerPrefs.GetInt(CommonTypes.LEVEL_DATA_KEY) == 1)
        {
            scaleMultiply = 1.06f;
        }
        #region Id-Money;
        if (PlayerPrefs.GetInt("ScaleUpControl") == 1) { scaleUpMoney = 500; }if (PlayerPrefs.GetInt("ScaleUpControl") == 2) { scaleUpMoney = 750; }if (PlayerPrefs.GetInt("ScaleUpControl") == 3) { scaleUpMoney = 1000; }if (PlayerPrefs.GetInt("ScaleUpControl") == 4) { scaleUpMoney = 1250; }
        if (PlayerPrefs.GetInt("SpeedUpControl") == 1) { speedUpMoney = 700; }if (PlayerPrefs.GetInt("SpeedUpControl") == 2) { speedUpMoney = 1050; }if (PlayerPrefs.GetInt("SpeedUpControl") == 3) { speedUpMoney = 1400; }if (PlayerPrefs.GetInt("SpeedUpControl") == 4) { speedUpMoney = 1750; }
        #endregion
        #region Max-Money
        if (PlayerPrefs.GetInt("ScaleUpControl") == 5)
        {
            ScaleBuy.SetActive(false);
            ScaleBuyMax.SetActive(true);
        }
        if (PlayerPrefs.GetInt("SpeedUpControl") == 5)
        {
            SpeedBuy.SetActive(false);
            SpeedBuyMax.SetActive(true);
        }
        if (PlayerPrefs.GetInt("SkinChangeControl") == 5)
        {
            SkinBuy.SetActive(false);
            SkinBuyMax.SetActive(true);
        }         

        if (_canvasmanager.moneyCount >= scaleUpMoney)
        {
            noMoneyText.SetActive(false);
        }
        if (_canvasmanager.moneyCount >= speedUpMoney)
        {
            noMoneyText.SetActive(false);
        }
        if (_canvasmanager.moneyCount >= 500)
        {
            noMoneyText.SetActive(false);
        }
        #endregion

        if (nextLevel == true && PlayerPrefs.GetInt(CommonTypes.LEVEL_FAKE_DATA_KEY) <2)
        {
            ScaleBuy.SetActive(true);
            ScaleBuyMax.SetActive(false);
            SpeedBuy.SetActive(true);
            SpeedBuyMax.SetActive(false);
            SkinBuy.SetActive(true);
            SkinBuyMax.SetActive(false);
            nextLevel = false;
        }
    }
}