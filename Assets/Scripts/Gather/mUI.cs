using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class mUI : UIElement
{
    public Hand RightHand;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnHandHoverBegin(Hand currentHand)
    {
        base.OnHandHoverBegin(currentHand);
    }

    protected override void OnHandHoverEnd(Hand currentHand)
    {
        base.OnHandHoverEnd(currentHand);
    }

    protected override void HandHoverUpdate(Hand currentHand)
    {
        base.HandHoverUpdate(currentHand);
    }

    public event System.Action buttonClick;
    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        buttonClick.Invoke();
    }
    private void Start()
    {
        buttonClick += OnButtonCilckAdd;
    }


    public void OnButtonCilckAdd()
    {
        
    }
}
