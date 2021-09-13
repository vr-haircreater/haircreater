using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTransioner : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler,IPointerUpHandler,IPointerClickHandler
{
    public Color32 m_NormalColor = Color.white;
    public Color32 m_HoverColor = Color.gray;
    public Color32 m_DownColor = Color.white;

    public static Image[] colorimgs = new Image[12];
    public static GameObject showimg, slider1img;
    public static GameObject[] btns = new GameObject[12];
    public static int btn_color = 0;
    public static Color[] Colorbtns = new Color[12];
    public static Slider Sslider1;
    public static GameObject Gslider1;
    public static float[] ScolorValue = new float[12];

    private Image m_Image = null;
    private void Awake()
    {
        m_Image = GetComponent<Image>();

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

        Colorbtns[0] = Color.HSVToRGB(34 / 360.0f, 39 / 100.0f, 87 / 100.0f);
        Colorbtns[1] = Color.HSVToRGB(60 / 360.0f, 21 / 100.0f, 1);
        Colorbtns[2] = Color.HSVToRGB(319 / 360.0f, 13 / 100.0f, 99 / 100.0f);
        Colorbtns[3] = Color.HSVToRGB(0, 0, 0);
        Colorbtns[4] = Color.HSVToRGB(0, 0f, 68 / 100.0f);
        Colorbtns[5] = Color.HSVToRGB(25 / 360.0f, 43 / 100.0f, 99 / 100.0f);
        Colorbtns[6] = Color.HSVToRGB(194 / 360.0f, 29 / 100.0f, 1);
        Colorbtns[7] = Color.HSVToRGB(296 / 360.0f, 27 / 100.0f, 1);
        Colorbtns[8] = Color.HSVToRGB(0, 0, 1);
        Colorbtns[9] = Color.HSVToRGB(78 / 360.0f, 1, 84 / 100.0f);
        Colorbtns[10] = Color.HSVToRGB(0, 49 / 100.0f, 77 / 100.0f);

        ScolorValue[0] = 39;
        ScolorValue[1] = 21;
        ScolorValue[2] = 13;
        ScolorValue[3] = 0;
        ScolorValue[4] = 0;
        ScolorValue[5] = 43;
        ScolorValue[6] = 29;
        ScolorValue[7] = 27;
        ScolorValue[8] = 0;
        ScolorValue[9] = 100;
        ScolorValue[10] = 49;

        showimg = GameObject.FindGameObjectWithTag("showimage");
        slider1img = GameObject.FindGameObjectWithTag("slider1img");
        Gslider1 = GameObject.FindGameObjectWithTag("Gslider1");
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
        slider1img.GetComponent<Image>();
        Sslider1 = Gslider1.GetComponent<Slider>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        


    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        FindTag();
        Slider1();
        ValueChangeCheck0();
    }
    public void Slider1()
    {
        //抓顏色在區塊的位置指給handler用
        if (btn_color == 0)
        {
            Sslider1.value = ScolorValue[0];
            //showimg.GetComponent<Image>().color = Color.HSVToRGB(34 / 360.0f, Sslider1.value / 100.0f, 87 / 100.0f);
        }
        //抓S值0-100去給Colorbtns[]用
        Sslider1.onValueChanged.AddListener(delegate { ValueChangeCheck0(); });
    }
    public void ValueChangeCheck0()
    {
        //float temp = Sslider1.value;
        //if (Sslider1.value > temp)
        showimg.GetComponent<Image>().color = Color.HSVToRGB(34 / 360.0f, Sslider1.value, 87 / 100.0f);

    }
    public void FindTag()
    {
        if (gameObject.tag == "button0")
        {
            btn_color = 0;
            showimg.GetComponent<Image>().color = Colorbtns[0];
            
        }
        else if (gameObject.tag == "button1")
        {
            btn_color = 1;
            showimg.GetComponent<Image>().color = Colorbtns[1];
        }
        else if (gameObject.tag == "button2")
        {
            btn_color = 2;
            showimg.GetComponent<Image>().color = Colorbtns[2];
        }
        else if (gameObject.tag == "button3")
        {
            btn_color = 3;
            showimg.GetComponent<Image>().color = Colorbtns[3];
        }
        else if (gameObject.tag == "button4")
        {
            btn_color = 4;
            showimg.GetComponent<Image>().color = Colorbtns[4];
        }
        else if (gameObject.tag == "button5")
        {
            btn_color = 5;
            showimg.GetComponent<Image>().color = Colorbtns[5];
        }
        else if (gameObject.tag == "button6")
        {
            btn_color = 6;
            showimg.GetComponent<Image>().color = Colorbtns[6];
        }
        else if (gameObject.tag == "button7")
        {
            btn_color = 7;
            showimg.GetComponent<Image>().color = Colorbtns[7];
        }
        else if (gameObject.tag == "button8")
        {
            btn_color = 8;
            showimg.GetComponent<Image>().color = Colorbtns[8];
        }
        else if (gameObject.tag == "button9")
        {
            btn_color = 9;
            showimg.GetComponent<Image>().color = Colorbtns[9];
        }
        else if (gameObject.tag == "button10")
        {
            btn_color = 10;
            showimg.GetComponent<Image>().color = Colorbtns[10];
        }
        else if (gameObject.tag == "button11")
        {
            btn_color = 11;
            showimg.GetComponent<Image>().color = Colorbtns[11];
        }
    }

}
