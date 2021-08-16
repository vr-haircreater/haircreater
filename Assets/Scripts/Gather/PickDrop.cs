using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class PickDrop : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null;
    public SteamVR_Action_Boolean m_Grip = null;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;
    private GameObject m_object = null;
    

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
    }
    private void Update()
    {
        if (m_GrabAction.GetStateDown(m_Pose.inputSource))
        {
            Pickup();

        }
        if (m_Grip.GetStateDown(m_Pose.inputSource))
        {
            
            Drop();
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
        //m_object.GetComponent<InteractableContrallor>().m_ActiveHand = this;
    }
    public void Drop()
    {
        if (m_object == null) return;
    
        Rigidbody target = m_object.GetComponent<Rigidbody>();
        target.velocity = m_Pose.GetVelocity();
        target.angularVelocity = m_Pose.GetAngularVelocity();
        m_Joint.connectedBody = null;
        m_object.GetComponent<InteractableContrallor>().m_ActiveHand = null;
        m_object = null;

    }
   
}
