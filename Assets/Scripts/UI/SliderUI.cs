using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderUI : MonoBehaviour
{
    LevelController _levelControl;
    public Slider slider;
    GameObject Slid;
    public int slideMaxValue;
    public int slideValue;

    void Start()
    {
        _levelControl = FindObjectOfType<LevelController>();
        StartCoroutine(SliderMaxValue());
    }
    void Update()
    {
        
        slider.value = slideValue;
        slider.maxValue = slideMaxValue;
    }
    public IEnumerator SliderMaxValue()
    {
        yield return new WaitForSeconds(2);
        Slid = GameObject.FindGameObjectWithTag("Level");
        slideMaxValue = Slid.transform.childCount;
    }
}