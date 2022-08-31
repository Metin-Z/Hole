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
        StartCoroutine(SliderMaxValue());
    }
    void Update()
    {
        _levelControl = FindObjectOfType<LevelController>();
        slider.maxValue = slideMaxValue;
        slider.value = slideValue;      
    }
    public IEnumerator SliderMaxValue()
    {
        yield return new WaitForSeconds(2);
        Slid = GameObject.FindGameObjectWithTag("Level");
        slideMaxValue = _levelControl.levelChildCount;      
    }
}