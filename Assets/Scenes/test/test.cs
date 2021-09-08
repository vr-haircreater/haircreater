using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Image colorimg;
    public Button btns;
    Color Colorbtn0 = new Color(222f / 255, 184f / 255, 135f / 255);

    private void Start()
    {
        Color Colorbtn0 = new Color(222f / 255, 184f / 255, 135f / 255);
    }

    public void btn0Clicked()
    {
        

        colorimg.GetComponent<Image>().color = Colorbtn0;
    }

}
