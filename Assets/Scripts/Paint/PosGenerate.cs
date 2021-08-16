using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosGenerate : MonoBehaviour
{
    public List<Vector3> GetUpdatePointPos = CreateHair.UpdatePointPos;
    public List<Vector3> GetPointPos = CreateHair.PointPos; //拿CreateHair的PointPos來用
    List<Vector3> TempPoint = new List<Vector3>();
    public int HairWidth = CreateHair.HairWidth;
    public Vector3 cross;


    public void GetPosition(Vector3 OldPos, Vector3 NewPos, int range)
    {
        float w = range * 0.005f;
        if (GetPointPos == null)
        {
            Vector3 Vec1 = OldPos - cross * w;
            GetPointPos.Add(Vec1);
            GetPointPos.Add(OldPos);
            Vec1 = OldPos + cross * w;
            GetPointPos.Add(Vec1);
        }
        else 
        {
            Vector3 Vec1 = NewPos - cross * w;
            GetPointPos.Add(Vec1);
            GetPointPos.Add(NewPos);
            Vec1 = NewPos + cross * w;
            GetPointPos.Add(Vec1);
        }
    }
    public void VectorCross(Vector3 up,Vector3 forward,Vector3 right)
    {
        cross = Vector3.Cross(up,forward);
        cross.Normalize();
    }

    public void Straight_HairStyle(List<Vector3> GetPointPos, int range)
    {
        float w1;
        float w = range * 0.005f * 0.2f;
        if (GetPointPos.Count <= 6) w1 = (range * 0.005f) / GetPointPos.Count;
        else w1 = (range * 0.005f) / range;

        TempPoint.Clear();
        for (int i = 0; i < GetPointPos.Count; i++)
        {
            if (i == 0)
            {
                Vector3 Vec1 = GetPointPos[i] - cross * w;
                TempPoint.Add(Vec1);
                TempPoint.Add(GetPointPos[i]);
                Vec1 = GetPointPos[i] + cross * w;
                TempPoint.Add(Vec1);

            }
            else
            {
                Vector3 Vec1 = GetPointPos[i] - cross * w;
                TempPoint.Add(Vec1);
                TempPoint.Add(GetPointPos[i]);
                Vec1 = GetPointPos[i] + cross * w;
                TempPoint.Add(Vec1);
            }
            if (w < range * 0.005f) w += w1;
        }
        GetUpdatePointPos.Clear();
        GetUpdatePointPos.AddRange(TempPoint);
    }

    public void Dimand_HairStyle(List<Vector3> GetPointPos, int range)
    {

        float w1 = range * 0.005f / (GetPointPos.Count / 2); 
        float w = range * 0.005f * 0.2f;

        TempPoint.Clear();
        for (int i = 0; i < GetPointPos.Count; i++)
        {
            if (i == 0)
            {
                Vector3 Vec1 = GetPointPos[i] - cross * w;
                TempPoint.Add(Vec1);
                TempPoint.Add(GetPointPos[i]);
                Vec1 = GetPointPos[i] + cross * w;
                TempPoint.Add(Vec1);
            }
            else if (i == GetPointPos.Count - 1 && GetPointPos.Count > 2)
            {
                for (int j = 0; j < 3; j++) TempPoint.Add(GetPointPos[i]);
            }
            else
            {
                Vector3 Vec1 = GetPointPos[i] - cross * w;
                TempPoint.Add(Vec1);
                TempPoint.Add(GetPointPos[i]);
                Vec1 = GetPointPos[i] + cross * w;
                TempPoint.Add(Vec1);
            }
            if (w < range * 0.005f && i < GetPointPos.Count / 2) w += w1;
            else if (i > GetPointPos.Count / 2) w -= w1;
        }
        GetUpdatePointPos.Clear();
        GetUpdatePointPos.AddRange(TempPoint);

    }
}

/*
 if (GetPointPos == null)
        {
            Vector3 Vec = OldPos - NewPos;
            float n = 1.2f * 0.1f * range;//每段長度
            Vector3 Vec1 = new Vector3((Vec.y) * n, (-Vec.x) * n, (Vec.z) * n);
            Debug.Log(Vec1);
            Vector3 temp = new Vector3(OldPos.x + Vec1.x, OldPos.y + Vec1.y, OldPos.z + Vec1.z);
            GetPointPos.Add(temp);
            GetPointPos.Add(OldPos);
            Vec1 = new Vector3((-Vec.y) * n, (Vec.x) * n, (-Vec.z) * n);
            temp = new Vector3(OldPos.x + Vec1.x, OldPos.y + Vec1.y, OldPos.z + Vec1.z);
            GetPointPos.Add(temp);

        }
        else
        {
            Vector3 Vec = NewPos - OldPos;
            float n = 1.2f * 0.1f * range;//每段長度
            Vector3 Vec1 = new Vector3((Vec.y) * n, (-Vec.x) * n, (Vec.z) * n);
            Vector3 temp = new Vector3(NewPos.x + Vec1.x, NewPos.y + Vec1.y, NewPos.z + Vec1.z);
            GetPointPos.Add(temp);
            GetPointPos.Add(NewPos);
            Vec1 = new Vector3((-Vec.y) * n, (Vec.x) * n, (-Vec.z) * n);
            temp = new Vector3(NewPos.x + Vec1.x, NewPos.y + Vec1.y, NewPos.z + Vec1.z);
            GetPointPos.Add(temp);
        }
 */