using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderUI : MonoBehaviour
{
    LevelController _levelControl;
    public Slider slider;
    public GameObject levelcontroller;
    void Start()
    {
        _levelControl = FindObjectOfType<LevelController>();
    }
    void Update()
    {
        slider.maxValue = _levelControl.levelChildCount;
        slider.value = 4;
    }
}
