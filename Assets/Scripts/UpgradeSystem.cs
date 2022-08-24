using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    CanvasManager _canvasmanager;
    Controller _player;
    int scaleUpCount;
    public GameObject ScaleBuy;
    public GameObject ScaleBuyMax;
    public GameObject noMoneyText;
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
            _canvasmanager.moneyCount -= 250;
            _player.transform.localScale += new Vector3(+0.35f, 0, +0.35f);            
        }
        else
        {
            noMoneyText.SetActive(true);
        }
    }
    public void Update()
    {
        if (scaleUpCount == 5)
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
