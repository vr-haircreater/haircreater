using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Valve.VR;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshGenerate : MonoBehaviour
{
    private Mesh mesh;
    public static Material hairColor;

    //裝mesh基本設定的陣列
    Vector3[] vertice;
    Vector2[] uv;//texture
    Vector4[] tangents;
    int[] triangles;

    //紀錄vertice & triangle的長度值變數
    int oldVertice;
    int oldTriangle;
    int Voldlen; // V old length

    //記第一下
    int down = 0;

    int tempcount = 0;
    int point;

    //紀錄 vertice & triangle長度的矩陣
    public List<int> verticeBox = new List<int>();
    public List<int> triangleBox = new List<int>();
    public List<int> tempVerticeBox = new List<int>();
    public List<int> tempTriangleBox = new List<int>();

    //備份座標
    public List<Vector3> oldVerticePos = new List<Vector3>();
    public List<int> oldTrianglePos = new List<int>();

    //undo暫存值
    public List<Vector3> undoVerticePos = new List<Vector3>();
    public List<int> undoTrianglePos = new List<int>();

    //個別的髮片的 vertice與triangle個數
    public List<int> VerticeTotal = new List<int>();
    public List<int> TriangleTotal = new List<int>();
    public List<int> tempVerticeTotal = new List<int>();
    public List<int> tempTriangleTotal = new List<int>();

    //undo排序
    public List<int> undoSortVertice = new List<int>();
    public List<int> undoSortTriangle = new List<int>();

    

    public void meshGenerate(int count, int Getwidth, List<Vector3> GetPointPos, SteamVR_Action_Boolean TriggerClick1, GameObject Hairmodel)
    {

        if (down == 0)//讓list有值
        {
            verticeBox.Add(0);
            triangleBox.Add(0);
            down = 1;
        }


        hairColor = GetComponent<Renderer>().material;
        hairColor.color = Color.blue; // 預設值
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        GetComponent<MeshRenderer>().material = hairColor;
        mesh.name = "Hair Grid";


        Voldlen = verticeBox[count];//目前的total vertice個數
        vertice = new Vector3[GetPointPos.Count + Voldlen];
        uv = new Vector2[GetPointPos.Count + Voldlen];//texture
        tangents = new Vector4[GetPointPos.Count + Voldlen];
        Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);

        //舊座標備分
        for (int i = 0; i < Voldlen; i++)
        {
            vertice[i] = oldVerticePos[i];
            uv[i].x = oldVerticePos[i].x;
            uv[i].y = oldVerticePos[i].y;
            tangents[i] = tangent;
        }


        //新的座標
        for (int i = Voldlen, j = 0; i < GetPointPos.Count + Voldlen; i++, j++)
        {
            vertice[i] = GetPointPos[j];
            uv[i].x = GetPointPos[j].x;//Vector3轉Vector2
            uv[i].y = GetPointPos[j].y;
            tangents[i] = tangent;
        }

        mesh.vertices = vertice;//mesh網格點生成
        mesh.uv = uv;
        mesh.tangents = tangents;

        if (GetPointPos.Count < 1) point = 0;//計算網格數
        else point = ((GetPointPos.Count / (3 + (Getwidth - 1) * 2) - 1)) * 2 * Getwidth;
        triangles = new int[point * 6 + triangleBox[count]];//計算需要多少三角形點座標

        //備份三角形
        for (int i = 0; i < triangleBox[count]; i++)
        {
            triangles[i] = oldTrianglePos[i];
        }

        int t = triangleBox[count];//初始三角形
        int k = 0;//累加
        for (int vi = verticeBox[count], x = 1; x <= point; x++, vi += k)
        {
            t = SetQuad(triangles, t, vi, vi + 1, vi + 3 + (2 * (Getwidth - 1)), vi + 4 + (2 * (Getwidth - 1)));
            if (x % (Getwidth * 2) != point % (Getwidth * 2)) k = 1;  //在同一行
            else k = 2;  //對vi的累加  (需換行時)
        }

        mesh.triangles = triangles;
        //mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        oldVertice = vertice.Length;
        oldTriangle = triangles.Length;

        //收集長度&舊的位置
        RecordValue(oldVertice, oldTriangle, mesh.vertices, mesh.triangles, TriggerClick1,count);

    }

    private static int SetQuad(int[] triangles, int i, int v0, int v1, int v2, int v3)
    {
        triangles[i] = v0;
        triangles[i + 1] = v1;
        triangles[i + 2] = v2;
        triangles[i + 3] = v2;
        triangles[i + 4] = v1;
        triangles[i + 5] = v3;
        return i + 6;
    }


    public void RecordValue(int verticeLength, int triangleLength, Vector3[] verticePos, int[] trianglePos, SteamVR_Action_Boolean TriggerClick2,int count)
    {

        if (TriggerClick2.GetStateUp(drawer.Pose.inputSource))
        {
            oldVerticePos.Clear();//需先清空原有的座標
            oldTrianglePos.Clear();

            verticeBox.Add(verticeLength);
            triangleBox.Add(triangleLength);

            oldVerticePos.AddRange(verticePos);//重新新增上去
            oldTrianglePos.AddRange(trianglePos);

            if (count == 0) VerticeTotal.Add(verticeBox[count + 1]);
            else VerticeTotal.Add(verticeBox[count + 1] - verticeBox[count]);
            if (count == 0) TriangleTotal.Add(triangleBox[count + 1]);
            else TriangleTotal.Add(triangleBox[count + 1] - triangleBox[count]);

        }


    }

    public void ClearMesh(int count)
    {
        //輩分
        tempcount = count;

        undoSortVertice.AddRange(VerticeTotal);
        undoSortTriangle.AddRange(TriangleTotal);

        undoVerticePos.AddRange(oldVerticePos);
        undoTrianglePos.AddRange(oldTrianglePos);

        tempVerticeBox.AddRange(verticeBox.GetRange(1, verticeBox.Count - 1));
        tempTriangleBox.AddRange(triangleBox.GetRange(1, triangleBox.Count - 1));

        tempVerticeTotal.AddRange(VerticeTotal);
        tempTriangleTotal.AddRange(TriangleTotal);


        //移除
        verticeBox.RemoveRange(1, verticeBox.Count - 1);
        triangleBox.RemoveRange(1, triangleBox.Count - 1);

        VerticeTotal.Clear();
        TriangleTotal.Clear();

        oldVerticePos.Clear();
        oldTrianglePos.Clear();

    }


    public void undoMesh(int count)
    {
        Debug.Log(count);
        if (count == 0)
        {
            //推回去

            int Lastindex = tempVerticeBox.Count - tempcount;

            int totalUndoPosV = 0;
            int totalUndoPosA = 0;

            Debug.Log(undoSortVertice.Count - tempcount);

            for (int i = undoSortVertice.Count - tempcount; i < undoSortVertice.Count; i++)
            {
                totalUndoPosV += undoSortVertice[i];
                totalUndoPosA += undoSortTriangle[i];

            }
            Debug.Log(totalUndoPosV);

            int indexV = undoVerticePos.Count - totalUndoPosV;
            int indexT = undoTrianglePos.Count - totalUndoPosA;

            oldVerticePos.AddRange(undoVerticePos.GetRange(indexV, totalUndoPosV));
            oldTrianglePos.AddRange(undoTrianglePos.GetRange(indexT, totalUndoPosA));

            verticeBox.AddRange(tempVerticeBox.GetRange(Lastindex, tempcount));
            triangleBox.AddRange(tempTriangleBox.GetRange(Lastindex, tempcount));
            VerticeTotal.AddRange(tempVerticeTotal.GetRange(Lastindex, tempcount));
            TriangleTotal.AddRange(tempTriangleTotal.GetRange(Lastindex, tempcount));

            //移除
            int index = undoSortVertice.Count - tempcount;

            undoSortVertice.RemoveRange(index, tempcount);
            undoSortTriangle.RemoveRange(index, tempcount);

            tempVerticeBox.RemoveRange(Lastindex, tempcount);
            tempTriangleBox.RemoveRange(Lastindex, tempcount);


            Debug.Log("totalUndoPosV" + totalUndoPosV);

            undoVerticePos.RemoveRange(indexV, totalUndoPosV);
            undoTrianglePos.RemoveRange(indexT, totalUndoPosA);

            tempVerticeTotal.RemoveRange(Lastindex, tempcount);
            tempTriangleTotal.RemoveRange(Lastindex, tempcount);


        }
        else
        {

            //更新
            int index = VerticeTotal.Count - 1;

            undoSortVertice.Add(VerticeTotal[index]);
            undoSortTriangle.Add(TriangleTotal[index]);

            int Vindex = verticeBox[verticeBox.Count - 2];
            int Tindex = triangleBox[triangleBox.Count - 2];

            undoVerticePos.AddRange(oldVerticePos.GetRange(Vindex, VerticeTotal[index]));
            undoTrianglePos.AddRange(oldTrianglePos.GetRange(Tindex, TriangleTotal[index]));

            int LastIndex = verticeBox.Count - 1;

            tempVerticeBox.Add(verticeBox[LastIndex]);
            tempTriangleBox.Add(triangleBox[LastIndex]);

            tempVerticeTotal.Add(VerticeTotal[VerticeTotal.Count - 1]);
            tempTriangleTotal.Add(TriangleTotal[TriangleTotal.Count - 1]);


            //搬移

            verticeBox.RemoveAt(LastIndex);
            triangleBox.RemoveAt(LastIndex);

            oldVerticePos.RemoveRange(Vindex, VerticeTotal[count - 1]);
            oldTrianglePos.RemoveRange(Tindex, TriangleTotal[count - 1]);

            int lastindex = VerticeTotal.Count - 1;
            VerticeTotal.RemoveAt(lastindex);
            TriangleTotal.RemoveAt(lastindex);


        }

    }
    public void redoMesh()
    {
        //推回去
        int LastUndoVIndex = undoSortVertice.Count - 1;
        int LastUndoTIndex = undoSortTriangle.Count - 1;
        int Vindex = undoVerticePos.Count - undoSortVertice[LastUndoVIndex];
        int Tindex = undoTrianglePos.Count - undoSortTriangle[LastUndoTIndex];

        verticeBox.Add(tempVerticeBox[tempVerticeBox.Count - 1]);
        triangleBox.Add(tempTriangleBox[tempTriangleBox.Count - 1]);

        oldVerticePos.AddRange(undoVerticePos.GetRange(Vindex, undoSortVertice[LastUndoVIndex]));
        oldTrianglePos.AddRange(undoTrianglePos.GetRange(Tindex, undoSortTriangle[LastUndoTIndex]));

        int lastindex = tempVerticeTotal.Count - 1;

        VerticeTotal.Add(tempVerticeTotal[lastindex]);
        TriangleTotal.Add(tempTriangleTotal[lastindex]);

        //移除
        tempVerticeBox.RemoveAt(tempVerticeBox.Count - 1);
        tempTriangleBox.RemoveAt(tempTriangleBox.Count - 1);

        undoVerticePos.RemoveRange(Vindex, undoSortVertice[LastUndoVIndex]);
        undoTrianglePos.RemoveRange(Tindex, undoSortTriangle[LastUndoTIndex]);

        undoSortVertice.RemoveAt(LastUndoVIndex);
        undoSortTriangle.RemoveAt(LastUndoTIndex);

        tempVerticeTotal.RemoveAt(lastindex);
        tempTriangleTotal.RemoveAt(lastindex);

        //RemoveAt Range混用可能會掛掉
    }

}