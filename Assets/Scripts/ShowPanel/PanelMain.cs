using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMain : MonoBehaviour
{
    public static int icon=0;
    public void PaintIconClick() {
        icon = 1;
        UIManager.Instance.ShowPanel("RPanel_Paint");
        UIManager.Instance.ClosePanel("RPanel_Color");
    }
    public void ColorIconClick()
    {
        icon = 2;
        UIManager.Instance.ClosePanel("RPanel_Paint");
        UIManager.Instance.ShowPanel("RPanel_Color");
    }
    public void SlideClick()
    {

    }

    public void ClearIconClick()
    {
        icon = 3;
        UIManager.Instance.ClosePanel("RPanel_Paint");
        UIManager.Instance.ClosePanel("RPanel_Color");
    }
    public void EraserIconClick()
    {
        icon = 4;
        UIManager.Instance.ClosePanel("RPanel_Paint");
        UIManager.Instance.ClosePanel("RPanel_Color");
    }
    public void UndoIconClick()
    {
        icon = 5;
        UIManager.Instance.ClosePanel("RPanel_Paint");
        UIManager.Instance.ClosePanel("RPanel_Color");
        
    }
    public void RedoIconClick()
    {
        icon = 6;
        UIManager.Instance.ClosePanel("RPanel_Paint");
        UIManager.Instance.ClosePanel("RPanel_Color");
        
    }
}
