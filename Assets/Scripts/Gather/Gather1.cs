using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Gather1 : MonoBehaviour
{
    public int icon;
    GameObject RightHand,rigid;
    //Rigidbody ri;
    
    public static SteamVR_Behaviour_Pose Pose = null;
    private FixedJoint m_Joint = null;
    private GameObject m_object = null;

    public SteamVR_Action_Boolean TriggerClick = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");//板機鍵按鈕
    public SteamVR_Action_Boolean m_Grip = null;

    public FlexibleColorPicker cpicker;
    public static Material cpicker_material;

 

    void Awake()
    {
        //Paint = GameObject.Find("Salon_tool/paint1");
        RightHand = GameObject.Find("Player/SteamVRObjects/RightHand");
        //rigid = GameObject.Find("Player/SteamVRObjects/RightHand/tips/rigid");
        cpicker_material = Resources.Load<Material>("Materials/forCanvas");
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();

    }

    void Start()
    {
        icon = 0;
        RightHand.AddComponent<CreateHair>();
        //ri = rigid.AddComponent<Rigidbody>();
        //ri.isKinematic = true;
    }

    void Update()
    {
        cpicker_material.color = cpicker.color;
        if (icon == 1) 
        {
            GetComponent<CreateHair>().enabled = true;
            if (m_Grip.GetStateDown(Pose.inputSource))
            {
                Drop();
            }
        }
        if (icon == 0)
        {
            if (TriggerClick.GetStateDown(Pose.inputSource))
            {
                Pickup();

            }
            GetComponent<CreateHair>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paint"))
        {
            m_object = other.gameObject;

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Paint"))
        {
            m_object = null;
        }

    }

    public void Pickup()
    {
        if (m_object == null) return;
        if (m_object.GetComponent<InteractableContrallor>().m_ActiveHand != null)
        {
            m_object.GetComponent<InteractableContrallor>().m_ActiveHand.Drop();
        }
        Rigidbody target = m_object.GetComponent<Rigidbody>();
        m_Joint.connectedBody = target;
        m_object.GetComponent<InteractableContrallor>().m_ActiveHand = this;
        icon = 1;
    }
    public void Drop()
    {
        if (m_object == null) return;

        Rigidbody target = m_object.GetComponent<Rigidbody>();
        target.velocity = Pose.GetVelocity();
        target.angularVelocity = Pose.GetAngularVelocity();
        m_Joint.connectedBody = null;
        m_object.GetComponent<InteractableContrallor>().m_ActiveHand = null;
        m_object = null;
        icon = 0;

    }

}
