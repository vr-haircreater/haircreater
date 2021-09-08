using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;


public class PanelA : MonoBehaviour
{
    public static Image[] colorimgs = new Image[12];
    public static GameObject showimg;
    public static GameObject[] btns = new GameObject[12];
    public static int btn_color = 0;
    public static Color[] Colorbtns = new Color[12];

    
    void Awake()
    {
        btns[0] = GameObject.FindGameObjectWithTag("button0");
        btns[1] = GameObject.FindGameObjectWithTag("button1");
        btns[2] = GameObject.FindGameObjectWithTag("button2");
        btns[3] = GameObject.FindGameObjectWithTag("button3");
        btns[4] = GameObject.FindGameObjectWithTag("button4");
        btns[5] = GameObject.FindGameObjectWithTag("button5");
        btns[6] = GameObject.FindGameObjectWithTag("button6");
        btns[7] = GameObject.FindGameObjectWithTag("button7");
        btns[8] = GameObject.FindGameObjectWithTag("button8");
        btns[9] = GameObject.FindGameObjectWithTag("button9");
        btns[10] = GameObject.FindGameObjectWithTag("button10");
        btns[11] = GameObject.FindGameObjectWithTag("button11");

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

        showimg = GameObject.FindGameObjectWithTag("showimage");

    }


    void Start()
    {
        for (int i = 0; i < 12; i++) 
        {
            //btns[i].AddComponent<Image>();
            colorimgs[i] = btns[i].GetComponent<Image>();
            colorimgs[i].GetComponent<Image>().color = Colorbtns[i];
        }
        showimg.GetComponent<Image>();
    }
    //button
    public static void btn0Clicked()
    {
        btn_color = 0;
        showimg.GetComponent<Image>().color = Colorbtns[0];
    }
    
    public static void btn1Clicked()
    {
        btn_color = 1;
        showimg.GetComponent<Image>().color = Colorbtns[1];
    }
    public static void btn2Clicked()
    {
        btn_color = 2;
        showimg.GetComponent<Image>().color = Colorbtns[2];
    }
    public static void btn3Clicked()
    {
        btn_color = 3;
        showimg.GetComponent<Image>().color = Colorbtns[3];
    }
    public static void btn4Clicked()
    {
        btn_color = 4;
        showimg.GetComponent<Image>().color = Colorbtns[4];
    }
    public static void btn5Clicked()
    {
        btn_color = 5;
        showimg.GetComponent<Image>().color = Colorbtns[5];
    }
    public static void btn6Clicked()
    {
        btn_color = 6;
        showimg.GetComponent<Image>().color = Colorbtns[6];
    }
    public static void btn7Clicked()
    {
        btn_color = 7;
        showimg.GetComponent<Image>().color = Colorbtns[7];
    }
    public static void btn8Clicked()
    {
        btn_color = 8;
        showimg.GetComponent<Image>().color = Colorbtns[8];
    }
    public static void btn9Clicked()
    {
        btn_color = 9;
        showimg.GetComponent<Image>().color = Colorbtns[9];
    }
    public static void btn10Clicked()
    {
        btn_color = 10;
        showimg.GetComponent<Image>().color = Colorbtns[10];
    }
    public static void btn11Clicked()
    {
        btn_color = 11;
        showimg.GetComponent<Image>().color = Colorbtns[11];
    }
    


    void Update()
    {
        
    }
}
