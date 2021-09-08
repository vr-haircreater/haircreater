using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PanelA : MonoBehaviour
{
    public Image[] colorimgs = new Image[12];
    public Image showimg;
    public Button[] btns = new Button[12];
    int btn_color = 0;
    public Color[] Colorbtns = new Color[12];

    void Awake()
    {
        Colorbtns[0] = new Color(222f / 255, 184f / 255, 135f / 255);
        Colorbtns[1] = new Color(255f / 255, 255f / 255, 202f / 255);
        Colorbtns[2] = new Color(253f / 255, 219f / 255, 242f / 255);
        Colorbtns[3] = new Color(000f / 255, 000f / 255, 000f / 255);
        Colorbtns[4] = new Color(173f / 255, 173f / 255, 173f / 255);
        Colorbtns[5] = new Color(253f / 255, 190f / 255, 145f / 255);
        Colorbtns[6] = new Color(180f / 255, 237f / 255, 254f / 255);
        Colorbtns[7] = new Color(250f / 255, 187f / 255, 255f / 255);
        Colorbtns[8] = new Color(255f / 255, 255f / 255, 255f / 255);
        Colorbtns[9] = new Color(149f / 255, 213f / 255, 000f / 255);
        Colorbtns[10] = new Color(196f / 255, 100f / 255, 100f / 255);
        Colorbtns[11] = new Color(0f / 255, 0f / 255, 0f / 255);
        
    }
    
    void Start()
    {
        for (int i = 0; i < 12; i++) 
        {
            colorimgs[i].GetComponent<Image>().color = Colorbtns[i];
        }
    }
    //button
    public void btn0Clicked()
    {
        btn_color = 0;
        showimg.color = Colorbtns[0];
    }
    
    public void btn1Clicked()
    {
        btn_color = 1;
        showimg.color = Colorbtns[1];
    }
    public void btn2Clicked()
    {
        btn_color = 2;
        showimg.color = Colorbtns[2];
    }
    public void btn3Clicked()
    {
        btn_color = 3; 
        showimg.color = Colorbtns[3];
    }
    public void btn4Clicked()
    {
        btn_color = 4;
        showimg.color = Colorbtns[4];
    }
    public void btn5Clicked()
    {
        btn_color = 5;
        showimg.color = Colorbtns[5];
    }
    public void btn6Clicked()
    {
        btn_color = 6;
        showimg.color = Colorbtns[6];
    }
    public void btn7Clicked()
    {
        btn_color = 7;
        showimg.color = Colorbtns[7];
    }
    public void btn8Clicked()
    {
        btn_color = 8;
        showimg.color = Colorbtns[8];
    }
    public void btn9Clicked()
    {
        btn_color = 9;
        showimg.color = Colorbtns[9];
    }
    public void btn10Clicked()
    {
        btn_color = 10;
        showimg.color = Colorbtns[10];
    }
    public void btn11Clicked()
    {
        btn_color = 11;
        showimg.color = Colorbtns[11];
    }
//bar
    


    void Update()
    {
        
    }
}
