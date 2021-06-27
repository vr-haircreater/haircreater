using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    //HSV: Hue色相 + Saturation飽和度 +　Value明度
    //RGB: Red紅色 + Green綠色 + Blue藍色
    //Slider可以做從 0~1 , Color 也是吃 0~1 的數值

    [SerializeField]
    Image colorImg;
    [SerializeField]
    Slider HueSlider;
    [SerializeField]
    Slider SatSlider;
    [SerializeField]
    Slider ValSlider;

    float hue; //Hue色相
    float sat; //Saturation飽和度
    float val; //Value明度

    private void Awake()
    {
        HueSlider.onValueChanged.AddListener(HueChanged);
        SatSlider.onValueChanged.AddListener(SatChanged);
        ValSlider.onValueChanged.AddListener(ValChanged);
    }

    private void HueChanged(float value)
    {
        hue = value;
        ToColor();
    }

    private void SatChanged(float value)
    {
        sat = value;
        ToColor();
    }

    private void ValChanged(float value)
    {
        val = value;
        ToColor();
    }
    public void SlideClick()
    {
        ToColor();
    }

    void ToColor()
    {
        Color rgb = Color.HSVToRGB(hue, sat, val);
        colorImg.color = rgb;
    }

}
