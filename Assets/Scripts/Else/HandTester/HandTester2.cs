using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Valve.VR;

public class HandTester2 : MonoBehaviour
{
    public GameObject prefab;//use template
    public Rigidbody attachPoint;//rigidbody
    public SteamVR_Input_Sources LeftInputSource = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources RightInputSource = SteamVR_Input_Sources.RightHand;
    private SteamVR_Input_Sources inputSource;
    public SteamVR_Action_Boolean TriggerClick;//板機鍵按鈕

    public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

    SteamVR_Behaviour_Pose Pose;
    FixedJoint joint;

    private void Awake()
    {
        //Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }
    private void Start()
    {
        
    }
    private void OnEnable()//listener是自動監聽，可以不用放入update中，否則影響效能。
    {
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }
    /*private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, inputSource);
    }*/
    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.position = attachPoint.transform.position;
        Debug.Log(attachPoint.transform.position);
    }
    private void FixedUpdate()
    {
        
    }
}
