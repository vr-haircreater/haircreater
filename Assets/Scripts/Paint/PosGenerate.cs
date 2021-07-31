using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosGenerate : MonoBehaviour
{
    public List<Vector3> GetPointPos = CreateHair.PointPos; //拿CreateHair的PointPos來用

    public void GetPosition(Vector3 OldPos, Vector3 NewPos, int Hairwidth)
    {
        // 計算Pos抓點
        Vector3 Vec = NewPos - OldPos;
        for (int i = 0, j = Hairwidth; i < Hairwidth; i++, j--)
        {
            Vector3 Vec1 = new Vector3((Vec.y) * j, (-Vec.x) * j, Vec.z * j);
            Vector3 temp = new Vector3(OldPos.x + Vec1.x, OldPos.y + Vec1.y, OldPos.z + Vec1.z);
            GetPointPos.Add(temp);
        }
        GetPointPos.Add(OldPos);
        for (int i = 0, j = 1; i < Hairwidth; i++, j++)
        {
            Vector3 Vec1 = new Vector3((-Vec.y) * j, (Vec.x) * j, Vec.z * j);
            Vector3 temp = new Vector3(OldPos.x + Vec1.x, OldPos.y + Vec1.y, OldPos.z + Vec1.z);
            GetPointPos.Add(temp);
        }
    }
}
