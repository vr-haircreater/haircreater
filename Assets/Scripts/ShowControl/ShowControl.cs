using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class ShowControl : MonoBehaviour
{
    // Start is called before the first frame update
    public bool showController = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var hand in Player.instance.hands)
        {
            if (showController)
            {
                hand.ShowController();
            }
            else
            {
                hand.HideController();
            }
        }
    }
}
