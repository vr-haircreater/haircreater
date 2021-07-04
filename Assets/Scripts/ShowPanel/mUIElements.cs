using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;




public class mUIElements : UIElement
{
    public Hand currentHand;

    protected override void Awake()
    {
        base.Awake();
        //paint= GameObject.Find("PaintIcon").GetComponents<Button>();
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
