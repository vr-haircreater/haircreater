using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public Image Sat, Hue, Paint; // Saturation飽和 Hue色彩 Paint畫出來的
    public RectTransform SatPointer, HuePointer; // Pointer指標
    private Sprite SatSprite, HueSprite; //sprite畫布
    private Color32 currentHue = Color.red; //指定default color

    float sWidth = 200, sHeight = 200; //sat width and height
    float hWidth = 50, hHeight = 50; //hue width and height

    private Vector2 clickPoint = Vector2.zero; //pointer

    //只可讀的數值
    private readonly static int[] hues = new int[] { 2, 0, 1, 2, 0, 1 }; 
    private readonly static Color[] colors = new Color[] { Color.red, Color.blue, Color.blue, Color.green, Color.green, Color.red };
    private readonly static float co = 1.0f / hues.Length;

    private void Start()
    {
        UpdateSat();
        UpdateHue();
    }

    private void UpdateSat() 
    {
        SatSprite = Sprite.Create(new Texture2D((int)sWidth, (int)sHeight), new Rect(0, 0, sWidth, sHeight), new Vector2(0, 0));
        for (int y = 0; y <= sHeight; y++)
        {
            for (int x = 0; x < sWidth; x++)
            {
                var pixColor = GetSat(currentHue, x / sWidth, y / sHeight);
                SatSprite.texture.SetPixel(x, ((int)sHeight - y), pixColor);
            }
        }
        SatSprite.texture.Apply();
        Sat.sprite = SatSprite;
    }
    private static Color GetSat(Color color, float x, float y)
    {
        Color newColor = Color.white;
        for (int i = 0; i < 3; i++)
        {
            if (color[i] != 1)
            {
                newColor[i] = (1 - color[i]) * (1 - x) + color[i];
            }
        }

        newColor *= (1 - y);
        newColor.a = 1;
        return newColor;
    }

    private void UpdateHue()
    { 
        HueSprite = Sprite.Create(new Texture2D((int)hWidth, (int)hHeight), new Rect(0, 0, hWidth, hHeight), new Vector2(0, 0));

        for (int y = 0; y <= hHeight; y++)
        {
            for (int x = 0; x < hWidth; x++)
            {
                var pixColor = GetHue(y / hHeight);
                HueSprite.texture.SetPixel(x, ((int)hHeight - y), pixColor);
            }
        }
        HueSprite.texture.Apply();
        Hue.sprite = HueSprite;
    }

    public void OnSatClick(ColorClicker sender)
    {
        var size2 = Sat.rectTransform.sizeDelta / 2;
        var pos = Vector2.zero;
        pos.x = Mathf.Clamp(sender.ClickPoint.x, -size2.x, size2.x);
        pos.y = Mathf.Clamp(sender.ClickPoint.y, -size2.y, size2.y);
        SatPointer.anchoredPosition = clickPoint = pos;
        
        UpdateColor();
    }

    public void UpdateColor()
    {
        var size2 = Sat.rectTransform.sizeDelta / 2;
        var pos = clickPoint;
        pos += size2;

        var color = GetSat(currentHue, pos.x / Sat.rectTransform.sizeDelta.x, 1 - pos.y / Sat.rectTransform.sizeDelta.y);
        Paint.color = color;
    }

    public void OnHueClick(ColorClicker sender)
    {
        var h = Hue.rectTransform.sizeDelta.y / 2.0f;
        var y = Mathf.Clamp(sender.ClickPoint.y, -h, h);
        HuePointer.anchoredPosition = new Vector2(0, y);

        y += h;
        currentHue = GetHue(1 - y / Hue.rectTransform.sizeDelta.y);
        UpdateSat();
        UpdateColor();
    }

    private static Color GetHue(float y)
    {
        y = Mathf.Clamp01(y);

        var index = (int)(y / co);
        var h = hues[index];
        var newColor = colors[index];
        float less = (y - index * co) / co;
        newColor[h] = index % 2 == 0 ? less : 1 - less;

        return newColor;
    }



}