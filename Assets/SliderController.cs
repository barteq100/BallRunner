using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Text ValueText;
    public Slider Slider;
    public void OnSliderValueChange(float value)
    {
        ValueText.text = ((int)(value * 100)).ToString();
    }
}
