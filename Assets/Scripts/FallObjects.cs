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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Obje Düþtü");
        _canvasmanager = FindObjectOfType<CanvasManager>();
        _player = FindObjectOfType<Controller>();
        if (other.gameObject.CompareTag("Gold"))
        {
            _canvasmanager.SetTotalMoneyCount(25);
        }
        if (other.gameObject.CompareTag("Stick"))
        {
            _canvasmanager.SetTotalMoneyCount(10);
        }

        FallingObjects++;
        if (FallingObjects % 5 == 0)
        {
            _player.transform.localScale += new Vector3(+0.35f, 0, +0.35f);
            FallingObjects = 0;
        }
        FallenObjects.Add(other.gameObject);
    }
}
