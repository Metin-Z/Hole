using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FallObjects : MonoBehaviour
{
    CanvasManager _canvasmanager;
    Controller _player;
    public int FallingObjects;
    public List<GameObject> FallenObjects;
    public int FallenObjectValue;
    private void Awake()
    {
        _player = FindObjectOfType<Controller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Obje Düþtü");
        _canvasmanager = FindObjectOfType<CanvasManager>();
        _player = FindObjectOfType<Controller>();
        if (other.gameObject.CompareTag("Money"))
        {
            _canvasmanager.SetTotalMoneyCount(20);
            Destroy(other.gameObject);           
        }
        if (other.gameObject.CompareTag("Moneybag"))
        {
            _canvasmanager.SetTotalMoneyCount(50);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Stone") || other.gameObject.CompareTag("Gold") || other.gameObject.CompareTag("BonusGem") || other.gameObject.CompareTag("Emerald") || other.gameObject.CompareTag("Diamond"))
        {
            FallenObjects.Add(other.gameObject);
        }

    }
    public void Update()
    {
        FallenObjectValue = FallenObjects.Count;
        if (FallenObjectValue >= 20)
        {
            _player.transform.GetChild(1).GetComponent<BoxCollider>().isTrigger = false;
            _player.transform.GetChild(2).gameObject.SetActive(true);
            
        }
    }
}
