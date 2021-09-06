using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelA : MonoBehaviour
{
    public Button[] btns = new Button[12];
    //public static GameObject[] btns = new GameObject[12];
    public ColorBlock theColor;
    
    void Awake()
    {
        /*btns[0] = GameObject.Find("Canvas/PanelA/upper_button/Button0");*/
        theColor = GetComponent<Button>().colors;
    }
    
    void Start()
    {

    }

    public void btn0Clicked()
    {
        /*var Colorbtn0 = btns[0].GetComponent<Button>().colors;
        Colorbtn0.normalColor = new Color(222, 184, 135);
        btns[0].GetComponent<Button>().colors = Colorbtn0;*/

        /*btns[0] = GetComponent<Button>();
        theColor.normalColor = new Color(222, 184, 135);
        btns[0].colors = theColor;*/

        theColor.normalColor = new Color(222, 184, 135);
        btns[0].colors = theColor;

        Debug.Log("btn0 - clicked");
    }
    

    
    void Update()
    {
        
    }
}
