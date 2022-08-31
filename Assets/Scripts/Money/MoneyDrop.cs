using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MoneyDrop : MonoBehaviour
{
    public GameObject MoneyPrefab;
    public GameObject MoneyBagPrefab;
    FallObjects _fallObjects;
    MoneyPosList _moneyPos;
    public int PosValue = 0;

    SliderUI _slider;
    private void Start()
    {
        _slider = FindObjectOfType<SliderUI>();   
    }
    private void OnTriggerEnter(Collider other)
    {
        _slider.slideValue++;
        Destroy(other.gameObject);
        _moneyPos = FindObjectOfType<MoneyPosList>();    
        _fallObjects = FindObjectOfType<FallObjects>();
        _fallObjects.FallenObjects.Remove(_fallObjects.FallenObjects.LastOrDefault());
        if (other.gameObject.CompareTag("Stone"))
        {
            GameObject obj =Instantiate(MoneyPrefab, _moneyPos.MoneyPoses[PosValue]);
            obj.transform.parent = null;
            obj.transform.localScale = new Vector3(1, 1, 1);
            PosValue++;
            if (PosValue % 15 == 0)
            {
                PosValue = 0;
            }
        }
        if (other.gameObject.CompareTag("Gold"))
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject obj = Instantiate(MoneyPrefab, _moneyPos.MoneyPoses[PosValue]);
                obj.transform.parent = null;
                obj.transform.localScale = new Vector3(1, 1, 1);
                PosValue++;
                if (PosValue % 15 == 0)
                {
                    PosValue = 0;
                }
            }
        }
        if (other.gameObject.CompareTag("BonusGem"))
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject obj = Instantiate(MoneyBagPrefab, _moneyPos.MoneyPoses[PosValue]);
                obj.transform.parent = null;
                obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                PosValue++;
                if (PosValue % 15 == 0)
                {
                    PosValue = 0;
                }
            }
        }
        if (other.gameObject.CompareTag("Emerald"))
        {
            for (int i = 0; i < 7; i++)
            {
                GameObject obj = Instantiate(MoneyPrefab, _moneyPos.MoneyPoses[PosValue]);
                obj.transform.parent = null;
                obj.transform.localScale = new Vector3(1, 1, 1);
                PosValue++;
                if (PosValue % 15 == 0)
                {
                    PosValue = 0;
                }
            }
        }
        if (other.gameObject.CompareTag("Diamond"))
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject obj = Instantiate(MoneyBagPrefab, _moneyPos.MoneyPoses[PosValue]);
                obj.transform.parent = null;
                obj.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
                PosValue++;
                if (PosValue % 15 == 0)
                {
                    PosValue = 0;
                }
            }
        }
    }
}