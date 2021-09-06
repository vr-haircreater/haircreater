using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

[RequireComponent(typeof(Interactable))]
public class Removable : MonoBehaviour
{      //以直接修改物体世界坐标的方式移动物体,而不是绑定在手柄上,parent不变
    public bool moving = false;
    public SteamVR_Action_Boolean trigger;
    private SteamVR_Behaviour_Pose trackedObj;
    private Interactable interactable;
    // Use this for initialization
    void Start()
    {
        interactable = this.GetComponent<Interactable>();
        moving = false;
    }

    //-------------------------------------------------
    // Called every Update() while a Hand is hovering over this object
    //-------------------------------------------------
    private void HandHoverUpdate(Hand hand)
    {
        trackedObj = hand.GetComponent<SteamVR_Behaviour_Pose>();

        if (trigger.GetState(trackedObj.inputSource))
        {
            moving = true;
            transform.position = hand.transform.position;
        }
        else
        {
            moving = false;
        }
        if (moving)
        {
            transform.position = hand.transform.position;
        }
    }
}
