using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    CanvasManager _canvasmanager;
    Controller _player;
    int scaleUpCount, ScaleUpValue;
    int speedUpCount, SpeedUpValue;
    int skinChangeCount, SkinChangeValue;
    public GameObject ScaleBuy, ScaleBuyMax,SpeedBuy,SpeedBuyMax,SkinBuy,SkinBuyMax;
    public GameObject noMoneyText;
    float playerX=1, playerZ=1;
    public PlayerSettings settings;

    Vector3 PlayerSCALE;
    void Start()
    {
        _canvasmanager = FindObjectOfType<CanvasManager>();
        _player = FindObjectOfType<Controller>();
    }
    public void UpScale()
    {
        if (_canvasmanager.moneyCount >= 250)
        {
            scaleUpCount++;
            ScaleUpValue = scaleUpCount;
            PlayerPrefs.SetInt("ScaleUpControl", ScaleUpValue);
            _canvasmanager.SetTotalMoneyCount(-250);
            Vector3 scale = new Vector3(_player.transform.localScale.x * 1.3f, _player.transform.localScale.y, _player.transform.localScale.z * 1.3f);
            _player.transform.DOScale(scale, .5f).SetEase(Ease.Linear);
            PlayerSCALE = _player.transform.localScale;
            playerX = PlayerSCALE.x;
            playerZ = PlayerSCALE.z;
            _canvasmanager.SetScaleSize(playerX,playerZ);
        }
        else
        {
            noMoneyText.SetActive(true);
        }
    }
    public void UpSpeed()
    {
        if (_canvasmanager.moneyCount >= 350)
        {
            speedUpCount++;
            SpeedUpValue = speedUpCount;
            PlayerPrefs.SetInt("SpeedUpControl", SpeedUpValue);
            _canvasmanager.SetTotalMoneyCount(-350);
            _player.speed += 0.75f;
        }
        else
        {
            noMoneyText.SetActive(true);
        }
    }
    public void ChangeSkin()
    {
        if (_canvasmanager.moneyCount >= 500)
        {
            skinChangeCount++;
            SkinChangeValue = skinChangeCount;
            PlayerPrefs.SetInt("SkinChangeControl", SkinChangeValue);
            _canvasmanager.SetTotalMoneyCount(-500);
            //_player.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.red;
            _player.transform.GetChild(1).GetComponent<MeshRenderer>().material.DOColor(Color.red, 1f);
        }
        else
        {
            noMoneyText.SetActive(true);
        }
    }
    public void Update()
    {
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
        if (_canvasmanager.moneyCount >= 250)
        {
            noMoneyText.SetActive(false);
        }
        if (_canvasmanager.moneyCount >= 350)
        {
            noMoneyText.SetActive(false);
        }
        if (_canvasmanager.moneyCount >= 500)
        {
            noMoneyText.SetActive(false);
        }
    }
}
