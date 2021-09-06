using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class InteractableContrallor : MonoBehaviour
{
    [HideInInspector]
    public Gather1 m_ActiveHand = null;

}
