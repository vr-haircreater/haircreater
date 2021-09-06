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
        cross2 = Vector3.Cross(up, right);//z
        cross2.Normalize();
    }

    public void Straight_HairStyle(List<Vector3> GetPointPos, int range, int thickness)
    {
        float w1;
        float w = range * 0.005f * 0.2f;
        float t = thickness * 0.001f;
        if (GetPointPos.Count <= 6) w1 = (range * 0.005f) / GetPointPos.Count;
        else w1 = (range * 0.005f) / range;

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
        float t1;
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
    public void WaveHairStyle(List<Vector3> GetPointPos, int range, int thickness)
    {
        TempPoint.Clear();
        float w1 = range * 0.005f / (GetPointPos.Count / 2);
        float w = range * 0.005f * 0.2f;
        float t = thickness * 0.002f;
        float waveSize = 0.001f;

        float angle = -Mathf.PI;

        for (int i = 0; i < GetPointPos.Count; i++)
        {
            float y = Mathf.Sin(angle);
            if (i == 0)
            {
                Vector3 temp = new Vector3(GetPointPos[i].x, GetPointPos[i].y, GetPointPos[i].z + waveSize * y);
                for (int j = 0; j < 4; j++) TempPoint.Add(temp);
            }
            else
            {
                Vector3 temp = new Vector3(GetPointPos[i].x, GetPointPos[i].y, GetPointPos[i].z + waveSize * y);
                TempPoint.Add(temp - cross1 * w);
                TempPoint.Add(temp + cross2 * t);
                TempPoint.Add(temp + cross1 * w);
                TempPoint.Add(temp - cross2 * t);

            }
            //if (w < range * 0.005f) w += w1;
            if (w < range * 0.005f && i < GetPointPos.Count / 2) w += w1;
            else if (i > GetPointPos.Count / 2) w -= w1;
            if (waveSize < 0.03f && i % 7 == 0) waveSize += 0.01f;
            //if (i > GetPointPos.Count - 5) waveSize = 0.01f;
            angle += 0.9f;
        }

        GetUpdatePointPos.Clear();
        GetUpdatePointPos.AddRange(TempPoint);
    }

}

