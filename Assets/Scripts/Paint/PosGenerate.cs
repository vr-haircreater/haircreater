using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosGenerate : MonoBehaviour
{
    public List<Vector3> GetPointPos = CreateHair.PointPos; //拿CreateHair的PointPos來用
    public int HairWidth = CreateHair.HairWidth;

    public void GetPosition(Vector3 OldPos, Vector3 NewPos, int range)
    {
        if (GetPointPos == null)
        {
            Vector3 Vec = OldPos - NewPos;
            for (int i = 0, j = HairWidth; i < HairWidth; i++, j--)
            {
                float n = (j / 3.0f) * 0.7f * 0.1f * range;
                Vector3 Vec1 = new Vector3((Vec.y) * n, (-Vec.x) * n, (Vec.z) * n);
                Vector3 temp = new Vector3(OldPos.x + Vec1.x, OldPos.y + Vec1.y, OldPos.z + Vec1.z);
                GetPointPos.Add(temp);
            }
            GetPointPos.Add(OldPos);
            for (int i = 0, j = 1; i < HairWidth; i++, j++)
            {
                float n = (j / 3.0f) * 0.7f * 0.1f * range;
                Vector3 Vec1 = new Vector3((-Vec.y) * n, (Vec.x) * n, (-Vec.z) * n);
                Vector3 temp = new Vector3(OldPos.x + Vec1.x, OldPos.y + Vec1.y, OldPos.z + Vec1.z);
                GetPointPos.Add(temp);
            }

        }
        else
        {
            Vector3 Vec = NewPos - OldPos;
            for (int i = 0, j = HairWidth; i < HairWidth; i++, j--)
            {
                float n = (j / 3.0f) * 0.7f * 0.1f * range;
                Vector3 Vec1 = new Vector3((Vec.y) * n, (-Vec.x) * n, (Vec.z) * n);
                Vector3 temp = new Vector3(NewPos.x + Vec1.x, NewPos.y + Vec1.y, NewPos.z + Vec1.z);
                GetPointPos.Add(temp);
            }
            GetPointPos.Add(NewPos);
            for (int i = 0, j = 1; i < HairWidth; i++, j++)
            {
                float n = (j / 3.0f) * 0.7f * 0.1f * range;
                Vector3 Vec1 = new Vector3((-Vec.y) * n, (Vec.x) * n, (-Vec.z) * n);
                Vector3 temp = new Vector3(NewPos.x + Vec1.x, NewPos.y + Vec1.y, NewPos.z + Vec1.z);
                GetPointPos.Add(temp);
            }
        }

    }
}
