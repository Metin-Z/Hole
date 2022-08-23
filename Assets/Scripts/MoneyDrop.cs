using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDrop : MonoBehaviour
{
    public Transform MoneySpawnPos;
    public GameObject MoneyPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Stone"))
        {
            GameObject obj =Instantiate(MoneyPrefab, MoneySpawnPos);
            obj.transform.parent = null;
            obj.transform.localScale = new Vector3(1, 1, 1);
        }
        if (other.gameObject.CompareTag("Gold"))
        {
            GameObject obj = Instantiate(MoneyPrefab, MoneySpawnPos);
            GameObject obj2 = Instantiate(MoneyPrefab, MoneySpawnPos);
            obj.transform.parent = null;
            obj.transform.localScale = new Vector3(1, 1, 1);
            obj2.transform.parent = null;
            obj2.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
