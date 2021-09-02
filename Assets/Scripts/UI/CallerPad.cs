using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CallerPad : MonoBehaviour
{
    public SteamVR_Action_Boolean CallClick;
    public static SteamVR_Behaviour_Pose Pose;

    public GameObject PadA, PadB;
    int state = 1;

    private void Awake()
    {
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }
        // Start is called before the first frame update
        void Start()
    {
        PadA = GameObject.Find("Player/SteamVRObjects/LeftHand/PadA");
        PadB = GameObject.Find("Player/SteamVRObjects/LeftHand/PadB");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CallClick.GetStateDown(Pose.inputSource)) 
        {
            
            if (state == 1) 
            {
                PadA.SetActive(true);
                state = 2;
            }
            if (state == 2) 
            {
                PadA.SetActive(false);
                state = 1;
            }

        }
    }
}
