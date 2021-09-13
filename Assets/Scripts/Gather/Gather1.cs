using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Gather1 : MonoBehaviour
{
    public static int icon;
    public int state;
    int call = 0;
    public static bool GridState;
    GameObject RightHand;
    public static bool RightDown = false; 

    //Rigidbody ri;
    
    public static SteamVR_Behaviour_Pose Pose = null;
    private FixedJoint m_Joint = null;
    private GameObject m_object = null;

    public SteamVR_Action_Boolean TriggerClick = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");//板機鍵按鈕
    public SteamVR_Action_Boolean m_Grip = null;

    

    void Awake()
    {
        RightHand = GameObject.Find("Player/SteamVRObjects/RightHand");
        //cpicker_material = Resources.Load<Material>("Materials/forCanvas");
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();

    }

    void Start()
    {
        icon = 0;
        state = 0;
        GridState = false;
        RightHand.AddComponent<CreateHair>();
        GetComponent<CreateHair>().enabled = true;

    }

    void Update()
    {
        //Debug.Log("右:"+ Pose.transform.position);
        //cpicker_material.color = cpicker.color;
        if (icon == 1) //Paint
        {
            if (m_Grip.GetStateDown(Pose.inputSource)) Drop();
        }
        if (icon == 2) //Eraser
        {
            GetComponent<CreateHair>().enabled = true;
            if (m_Grip.GetStateDown(Pose.inputSource)) Drop();
        }
        if (icon == 3) //Clear
        {
            GetComponent<CreateHair>().enabled = true;
            if (m_Grip.GetStateDown(Pose.inputSource)) Drop();
        }
        if (icon == 0)
        {
            if (TriggerClick.GetStateDown(Pose.inputSource)) Pickup();
            //GetComponent<CreateHair>().enabled = false;
        }
        if (TriggerClick.GetStateDown(Pose.inputSource))
        {
            //Debug.Log(Pose.transform.position);
            RightDown = true;
        }
        if (TriggerClick.GetStateUp(Pose.inputSource)) RightDown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Paint"))
        {
            m_object = other.gameObject;
            state = 1;

        }
        if (other.gameObject.CompareTag("Eraser"))
        {
            m_object = other.gameObject;
            state = 2;
        }
        if (other.gameObject.CompareTag("Clear"))
        {
            m_object = other.gameObject;
            state = 3;
        }
        if (other.gameObject.CompareTag("Grid")) 
        {
            GridState = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Paint"))
        {
            m_object = null;
        }
        if (other.gameObject.CompareTag("Eraser"))
        {
            m_object = null;
        }
        if (other.gameObject.CompareTag("Clear"))
        {
            m_object = null;
        }
        if (other.gameObject.CompareTag("Grid"))
        {
            GridState = false;
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
        icon = state;
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
        state = 0;

    }

}
