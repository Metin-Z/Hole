using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MoneyArea : MonoBehaviour
{
    FallObjects _fallObjects;
    public Transform moneyObjects;
    bool GetObject;
    private void OnTriggerEnter(Collider other)
    {
        GetObject = true;
        _fallObjects = FindObjectOfType<FallObjects>();
        if (other.gameObject.CompareTag("Player"))
        {           
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
