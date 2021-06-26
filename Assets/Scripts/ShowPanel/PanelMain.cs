using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMain : MonoBehaviour
{
    public static int icon=0;
    public void PaintIconClick() {
        icon = 1;
        UIManager.Instance.ShowPanel("RPanel_Paint");
    }
    public void ColorIconClick()
    {
        icon = 2;
    }
    public void ClearIconClick()
    {
        icon = 3;
    }
    public void EraserIconClick()
    {
        icon = 4;
    }
    public void UndoIconClick()
    {
        icon = 5;
    }
    public void RedoIconClick()
    {
        icon = 6;
    }
}
