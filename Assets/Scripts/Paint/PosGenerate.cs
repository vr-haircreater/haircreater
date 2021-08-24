using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosGenerate : MonoBehaviour
{
    public List<Vector3> GetUpdatePointPos = CreateHair.UpdatePointPos;
    public List<Vector3> GetPointPos = CreateHair.PointPos; //拿CreateHair的PointPos來用
    List<Vector3> TempPoint = new List<Vector3>();
    public int HairWidth = CreateHair.HairWidth;
    public Vector3 cross1, cross2;

    public void GetPosition(Vector3 OldPos, Vector3 NewPos, int range)
    {
        float w = range * 0.005f;
        if (GetPointPos == null)
        {
            GetPointPos.Add(OldPos - cross1 * w);
            GetPointPos.Add(OldPos + cross2 * w);
            GetPointPos.Add(OldPos + cross1 * w);
            GetPointPos.Add(OldPos - cross2 * w);

            GetPointPos.Add(NewPos - cross1 * w);
            GetPointPos.Add(NewPos + cross2 * w);
            GetPointPos.Add(NewPos + cross1 * w);
            GetPointPos.Add(NewPos - cross2 * w);
        }
        else
        {
            GetPointPos.Add(NewPos - cross1 * w);
            GetPointPos.Add(NewPos + cross2 * w);
            GetPointPos.Add(NewPos + cross1 * w);
            GetPointPos.Add(NewPos - cross2 * w);
        }
    }
    public void VectorCross(Vector3 up, Vector3 forward, Vector3 right)
    {
        cross1 = Vector3.Cross(up, forward);//x
        cross1.Normalize();
        cross2 = Vector3.Cross(up, right);
        cross2.Normalize();
    }

    public void Straight_HairStyle(List<Vector3> GetPointPos, int range, int thickness)
    {
        float w1;
        float w = range * 0.005f * 0.2f;
        if (GetPointPos.Count <= 6) w1 = (range * 0.005f) / GetPointPos.Count;
        else w1 = (range * 0.005f) / range;

        float t = thickness * 0.001f;

        TempPoint.Clear();
        for (int i = 0; i < GetPointPos.Count; i++)
        {
            if (i == 0)
            {
                TempPoint.Add(GetPointPos[i] - cross1 * w);
                TempPoint.Add(GetPointPos[i] + cross2 * t);
                TempPoint.Add(GetPointPos[i] + cross1 * w);
                TempPoint.Add(GetPointPos[i] - cross2 * t);
            }
            else
            {
                TempPoint.Add(GetPointPos[i] - cross1 * w);
                TempPoint.Add(GetPointPos[i] + cross2 * t);
                TempPoint.Add(GetPointPos[i] + cross1 * w);
                TempPoint.Add(GetPointPos[i] - cross2 * t);
            }
            if (w < range * 0.005f) w += w1;
        }
        GetUpdatePointPos.Clear();
        GetUpdatePointPos.AddRange(TempPoint);
    }

    public void Dimand_HairStyle(List<Vector3> GetPointPos, int range, int thickness)
    {

        float w1 = range * 0.005f / (GetPointPos.Count / 2);
        float w = range * 0.005f * 0.2f;
        float t = thickness * 0.001f;

        TempPoint.Clear();
        for (int i = 0; i < GetPointPos.Count; i++)
        {
            if (i == GetPointPos.Count - 1 && GetPointPos.Count > 2)
            {
                for (int j = 0; j < 4; j++) TempPoint.Add(GetPointPos[i]);
            }
            else
            {
                TempPoint.Add(GetPointPos[i] - cross1 * w);
                TempPoint.Add(GetPointPos[i] + cross2 * t);
                TempPoint.Add(GetPointPos[i] + cross1 * w);
                TempPoint.Add(GetPointPos[i] - cross2 * t);
            }
            if (w < range * 0.005f && i < GetPointPos.Count / 2) w += w1;
            else if (i > GetPointPos.Count / 2) w -= w1;
        }
        GetUpdatePointPos.Clear();
        GetUpdatePointPos.AddRange(TempPoint);

    }
}

