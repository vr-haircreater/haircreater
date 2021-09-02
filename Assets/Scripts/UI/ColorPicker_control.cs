using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Valve.VR;

public class ColorPicker_control : MonoBehaviour
{    
    public static float color_H, color_S, color_V;
    public GameObject sv_img, h_img, sv_slider, h_slider;
    public GameObject dot;
    Vector3 svPos,hPos,mousePos, SVsliderPos, HsliderPos;
    public float svWidth=200, svHeight=200, hWidth=16, hHeight=200, color_Htemp, color_Stemp, color_Vtemp;
    public Material colorshow;


    void Start()
    {
        svPos = sv_img.transform.position;
        hPos = h_img.transform.position;
        HsliderPos = h_slider.transform.position;
        color_Htemp = 0f;
        color_Stemp = 1f;
        color_Vtemp = 1f;
    }
    
    void Update()
    {
        svPos = sv_img.transform.position;
        hPos = h_img.transform.position;
 
        SVsliderPos = sv_slider.transform.position;
        HsliderPos = h_slider.transform.position;

        if (Gather1.RightDown==true)
        {
            mousePos = dot.transform.position;
            HsliderPos = h_slider.transform.position;
            //print("mouse:"+mousePos);
            if (mousePos.x >= svPos.x && mousePos.x <= (svPos.x + 0.15f) && mousePos.y <= svPos.y && mousePos.y >= (svPos.y - 0.158f))
            {
                //print("SV:"+mousePos);
                //SVsliderPos = sv_slider.transform.position;
                sv_slider.transform.position = new Vector3(mousePos.x, mousePos.y, mousePos.z);
                color_Stemp = (mousePos.x - svPos.x) / 0.15f;
                color_Vtemp = (mousePos.y - svPos.y + 0.158f) / 0.158f;
                Debug.Log("Y");
            }
            if (mousePos.x >= hPos.x && mousePos.x <= (hPos.x + 0.15f) && mousePos.y <= hPos.y && mousePos.y >= hPos.y - 0.012f)
            {
                //print("H:"+mousePos);
                
                h_slider.transform.position = new Vector3(mousePos.x, mousePos.y, mousePos.z);
                color_Htemp = (mousePos.x - hPos.x) / 0.15f;
            }
            Debug.Log("Pos:" + mousePos);
            Debug.Log("SVPos" + svPos);
        }


        color_H = color_Htemp;
        color_S = color_Stemp;
        color_V = color_Vtemp;
        colorshow.color = Color.HSVToRGB(color_H,color_S, color_V);
        //print(/*color_H + "," + color_S + "," + */color_V);
    }
}