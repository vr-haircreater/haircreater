using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class MPointer : MonoBehaviour
{
    public SteamVR_LaserPointer LaserPointer;
    //public SteamVR_Input_Source ;
    Hand hand;
    void Awake()
    {
      
        LaserPointer.PointerClick += PointerClick;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //hand.TriggerHapticPulse(500);
        //SteamVR_Actions._default.Haptic.active = false;
        //SteamVR_Actions.default_Haptic.AddOnExecuteListener(null, LaserPointer.fromInputSource);
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.tag == "button0") PanelA.btn0Clicked();
        else if (e.target.tag == "button1") PanelA.btn1Clicked();
        else if (e.target.tag == "button2") PanelA.btn2Clicked();
        else if (e.target.tag == "button3") PanelA.btn3Clicked();
        else if (e.target.tag == "button4") PanelA.btn4Clicked();
        else if (e.target.tag == "button4") PanelA.btn4Clicked();
        else if (e.target.tag == "button5") PanelA.btn5Clicked();
        else if (e.target.tag == "button6") PanelA.btn6Clicked();
        else if (e.target.tag == "button7") PanelA.btn7Clicked();
        else if (e.target.tag == "button8") PanelA.btn8Clicked();
        else if (e.target.tag == "button9") PanelA.btn9Clicked(); 
        else if (e.target.tag == "button10") PanelA.btn10Clicked();
        else if (e.target.tag == "button11") PanelA.btn11Clicked();
        Debug.Log(e.target.tag);
    }

}
