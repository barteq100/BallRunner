using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Text ValueText;
    public Slider Slider;

    public void Start()
    {
        ValueText.text = GetValueText(Slider.value);
        Slider.onValueChanged.AddListener(OnSliderValueChange);
    }
    public void OnSliderValueChange(float value)
    {
        ValueText.text = GetValueText(value);
    }

    private string GetValueText(float value)
    {
        return ((int)(value * 100)).ToString();
    }
}
