using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MoneyArea : MonoBehaviour
{
    FallObjects _fallObjects;
    public Transform moneyObjects;
    Controller _player;
    bool GetObject;
    private void Awake()
    {
        _player = FindObjectOfType<Controller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        GetObject = true;
        _fallObjects = FindObjectOfType<FallObjects>();
        if (other.gameObject.CompareTag("Player"))
        {
            _player.transform.GetChild(1).GetComponent<BoxCollider>().isTrigger = true;
            _player.transform.GetChild(2).gameObject.SetActive(false);
            StartCoroutine(GetObj());
        }
    }
    public IEnumerator GetObj()
    {
        while (_fallObjects.FallenObjectValue > 0)
        {
            _fallObjects.FallenObjectValue--;
            _fallObjects.FallenObjects.FirstOrDefault().transform.position = moneyObjects.position;
            yield return new WaitForSeconds(0.85f);
        }
    }
}
