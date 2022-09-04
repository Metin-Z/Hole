using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
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
        _moneyPos = FindObjectOfType<MoneyPosList>();
        _fallObjects = FindObjectOfType<FallObjects>();
    }
    private void OnTriggerEnter(Collider other)
    {            
        _fallObjects.FallenObjects.Remove(_fallObjects.FallenObjects.LastOrDefault());
        _slider.slideValue++;
        if (other.gameObject.CompareTag("Stone"))
        {
            GameObject obj =Instantiate(MoneyPrefab, _moneyPos.MoneyPoses[PosValue]);
            obj.transform.parent = null;
            obj.transform.localScale = new Vector3(0.5f, 0.5f,0.5f);
            Vector3 scale = new Vector3(obj.transform.localScale.x * 2f, obj.transform.localScale.y * 2f, obj.transform.localScale.z * 2f);
            obj.transform.DOScale(scale, 0.75f).SetEase(Ease.InBounce);
            obj.transform.DORotate(new Vector3(0, 360, 0), 1, RotateMode.FastBeyond360);
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
                obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Vector3 scale = new Vector3(obj.transform.localScale.x * 2f, obj.transform.localScale.y * 2f, obj.transform.localScale.z * 2f);
                obj.transform.DOScale(scale, 0.75f).SetEase(Ease.InBounce);
                obj.transform.DORotate(new Vector3(0, 360, 0), 1, RotateMode.FastBeyond360);
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
                obj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                Vector3 scale = new Vector3(obj.transform.localScale.x * 2f, obj.transform.localScale.y * 2f, obj.transform.localScale.z * 2f);
                obj.transform.DOScale(scale, 0.75f).SetEase(Ease.InBounce);
                obj.transform.DORotate(new Vector3(0, 450, 0), 1, RotateMode.FastBeyond360);
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
                obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Vector3 scale = new Vector3(obj.transform.localScale.x * 2f, obj.transform.localScale.y * 2f, obj.transform.localScale.z * 2f);
                obj.transform.DOScale(scale, 0.75f).SetEase(Ease.InBounce);
                obj.transform.DORotate(new Vector3(0, 360, 0), 1, RotateMode.FastBeyond360);
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
                obj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                Vector3 scale = new Vector3(obj.transform.localScale.x * 2f, obj.transform.localScale.y * 2f, obj.transform.localScale.z * 2f);
                obj.transform.DOScale(scale, 0.75f).SetEase(Ease.InBounce);
                obj.transform.DORotate(new Vector3(0, 450, 0), 1, RotateMode.FastBeyond360);
                PosValue++;
                if (PosValue % 15 == 0)
                {
                    PosValue = 0;
                }
            }
        }
        Destroy(other.gameObject);
    }
}