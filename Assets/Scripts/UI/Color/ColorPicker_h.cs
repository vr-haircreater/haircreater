using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ColorPicker_h : MonoBehaviour
{
    Texture2D tex2d;
    public RawImage Rawimage_h;
    int TexPixelWdith = 16;
    int TexPixelHeight = 360;
    Color[,] arrayColor;
    void Start()
    {
        arrayColor = new Color[TexPixelWdith, TexPixelHeight];
        tex2d = new Texture2D(TexPixelWdith, TexPixelHeight, TextureFormat.RGB24 , true);
        Color[] calcArray = CalcArrayColor();
        tex2d.SetPixels(calcArray);
        tex2d.Apply();
        Rawimage_h.texture = tex2d;
    }


    Color[] CalcArrayColor()
    {
        for (int j = 0; j < TexPixelHeight; j++)
        {
            for (int i = 0; i < TexPixelWdith; i++)
            {
                arrayColor[i, j] = Color.HSVToRGB(1/360f*j, 1, 1);
            }
        }

        List<Color> listColor = new List<Color>();
        for (int i = 0; i < TexPixelHeight; i++)
        {
            for (int j = 0; j < TexPixelWdith; j++)
            {
                listColor.Add(arrayColor[j, i]);
            }
        }
        return listColor.ToArray();
    }
}