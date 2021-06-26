using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelA : MonoBehaviour
{
    public void OnBtnCloseClick()
    {
        UIManager.Instance.ClosePanel("PanelA");
    }
}
