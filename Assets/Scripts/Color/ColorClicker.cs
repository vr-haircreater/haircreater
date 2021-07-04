using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class ColorClicker : MonoBehaviour
{
    public Button.ButtonClickedEvent Click; //可被點擊

    public Vector3 ClickPoint { get; set; } //點擊點

    public void OnDrag(PointerEventData eventData) 
    {
        var rect = transform as RectTransform;
        ClickPoint = rect.InverseTransformPoint(eventData.position);
        Click.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var rect = transform as RectTransform;
        ClickPoint = rect.InverseTransformPoint(eventData.position);
        Click.Invoke();
    }
}
