using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    CanvasManager _canvasmanager;
    Controller _player;
    int scaleUpCount, ScaleUpValue;
    public GameObject ScaleBuy;
    public GameObject ScaleBuyMax;
    public GameObject noMoneyText;
    float playerX=1, playerZ=1;

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
            _player.transform.localScale += new Vector3(+0.35f, 0, +0.35f);
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
    public void Update()
    {
        if (PlayerPrefs.GetInt("ScaleUpControl") == 5)
        {
            ScaleBuy.SetActive(false);
            ScaleBuyMax.SetActive(true);
        }
        if (_canvasmanager.moneyCount >= 250)
        {
            noMoneyText.SetActive(false);
        }
    }
}
