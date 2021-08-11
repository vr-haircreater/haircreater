using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Gather1 : MonoBehaviour
{
    public int icon;
    GameObject Paint,RightHand,rigid;
    Rigidbody ri;
    private FixedJoint fixedJoint;
    public static SteamVR_Behaviour_Pose Pose;
    public SteamVR_Action_Boolean TriggerClick = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");//板機鍵按鈕
    public FlexibleColorPicker cpicker;
    public static Material cpicker_material;

    void Awake()
    {
        Paint = GameObject.Find("Salon_tool/paint1");
        RightHand = GameObject.Find("Player/SteamVRObjects/RightHand");
        rigid = GameObject.Find("Player/SteamVRObjects/RightHand/tips/rigid");
        cpicker_material = Resources.Load<Material>("Materials/forCanvas");
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    void Start()
    {
        icon = 1;
        RightHand.AddComponent<CreateHair>();
        ri = rigid.AddComponent<Rigidbody>();
        ri.isKinematic = true;
    }

    private void OnTriggerStay(Collider collid)
    {
        if (collid.gameObject.CompareTag("Paint")) //collider 碰到 paint tag
        {
            icon = 1;
        }
        /*if (TriggerClick.GetStateDown(Pose.inputSource))
        {
            ri.isKinematic = false;
            fixedJoint.connectedBody = ri;
        }*/
    }
    void Update()
    {
        cpicker_material.color = cpicker.color;
        if (icon == 1) 
        {
            /*if (RightHand.GetComponent<CreateHair>() == null)
            {
                RightHand.AddComponent<CreateHair>();
            }*/
            GetComponent<CreateHair>().enabled = true;
            //MeshGenerate.GethairColor.color = cpicker.color;
        }
        if (icon == 0)
        {
            if (RightHand.GetComponent<CreateHair>())
            {
                //Destroy(RightHand.GetComponent<CreateHair>()); //直接砍掉了
                //Destroy(this); //清掉Gather1.cs
                GetComponent<CreateHair>().enabled = false;
            }
        }
    }

}
