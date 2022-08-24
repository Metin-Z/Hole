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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Obje Düþtü");
        _canvasmanager = FindObjectOfType<CanvasManager>();
        _player = FindObjectOfType<Controller>();
        if (other.gameObject.CompareTag("Money"))
        {
            _canvasmanager.SetTotalMoneyCount(10);
            Destroy(other.gameObject);           
        }
        if (!other.gameObject.CompareTag("Money"))
        {
            FallenObjects.Add(other.gameObject);
        }                         
    }
    public void Update()
    {
        FallenObjectValue = FallenObjects.Count;
    }
}
