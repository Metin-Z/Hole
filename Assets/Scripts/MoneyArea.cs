using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoneyArea : MonoBehaviour
{
    FallObjects _fallObjects;
    public Transform moneyObjects;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _fallObjects = FindObjectOfType<FallObjects>();
            Debug.Log("player geldi");
            _fallObjects.FallenObjects.FirstOrDefault().transform.position = moneyObjects.position;
            //_fallObjects.FallenObjects.FirstOrDefault().GetComponent<Rigidbody>();
            _fallObjects.FallenObjects.Remove(_fallObjects.FallenObjects.FirstOrDefault());
            gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(GetFallObject());

        }
    }
    public IEnumerator GetFallObject()
    {
        yield return new WaitForSeconds(0.65f);
        gameObject.GetComponent<BoxCollider>().enabled = true;

    }
}
