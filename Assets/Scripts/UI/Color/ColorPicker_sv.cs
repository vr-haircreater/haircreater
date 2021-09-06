using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker_sv : MonoBehaviour
{
    Texture2D tex2d;
    public RawImage Rawimage_sv;

    int TexPixelLength = 360;
    Color[,] arrayColor;

    void Start()
    {
        arrayColor = new Color[TexPixelLength, TexPixelLength];
        tex2d = new Texture2D(TexPixelLength, TexPixelLength, TextureFormat.RGB24, true);
        Rawimage_sv.texture = tex2d;
    }
    void Update()
    {
        SetColorPanel(ColorPicker_control.color_H);
    }

    Color[] CalcArryColor(float color_H)
    {
        for(int i = 0; i < TexPixelLength; i++)
        {
            for (int j = 0; j < TexPixelLength; j++)
            {
                arrayColor[i, j] = Color.HSVToRGB(color_H, i * (1/360.0f), (1/360.0f)*j);
            }
        }
        List<Color> listColor = new List<Color>();
        for(int i = 0; i < TexPixelLength; i++)
        {
            for(int j = 0; j < TexPixelLength; j++)
            {
                listColor.Add(arrayColor[j, i]);
            }
        }
        return listColor.ToArray();
    }

    public void SetColorPanel(float color_H)
    {
        Color[] CalcArray = CalcArryColor(color_H);
        tex2d.SetPixels(CalcArray);
        tex2d.Apply();
    }
}
