using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshGenerate : MonoBehaviour
{
    private Mesh mesh;
    public static Material GethairColor;
    Shader HairShader;

    Vector3[] vertice;
    Vector2[] uv;
    Vector4[] tangents;
    int[] triangle;
    

    public void GenerateMesh(List<Vector3> GetPointPos, int Getwidth)
    {
        GethairColor = GetComponent<Renderer>().material;
        HairShader = Shader.Find("Diffuse Fast");
        GethairColor.shader = HairShader;
        GethairColor.color = Gather1.cpicker_material.color;
        //GethairColor.color = CreateHair.cpicker;
        //GethairColor.color = Gather1.cpicker.color;
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        GetComponent<MeshRenderer>().material = GethairColor;
        mesh.name = "HairModel";

        vertice = new Vector3[GetPointPos.Count];
        uv = new Vector2[GetPointPos.Count];
        tangents = new Vector4[GetPointPos.Count];

        for (int i = 0, j = 0; i < GetPointPos.Count; i++, j++)
        {
            vertice[i] = GetPointPos[j];
            tangents[i] = new Vector4(1f, 0f, 0f, -1f);
        }

        int len = GetPointPos.Count / (3 + (Getwidth - 1) * 2);
        float TexWidth = 0.5f; //+ 0.1f * (CreateHair.InputRange-1); //0.03
        //float TexWidth = 0.5f + 0.022f * (CreateHair.InputRange - 1); //0.03

        for (int i = 0, x = 0; i < len; i++)
        {
            for (int j = 1; j <= (3 + (Getwidth - 1) * 2); j++)
            {
                /*if (i == 0) uv[x] = new Vector2(TexWidth / (3 + (Getwidth - 1) / 2) * j, 0f);
                else if (i > len - 6) uv[x] = new Vector2(TexWidth / (3 + (Getwidth - 1) / 2) * j, 0.2f + 0.8f / len * i);
                else if (i == 1 || i % 2 == 1) uv[x] = new Vector2(TexWidth / (3 + (Getwidth - 1) / 2) * j, 0.4f);
                else if (i % 2 == 0 || i == len - 2) uv[x] = new Vector2(TexWidth / (3 + (Getwidth - 1) / 2) * j, 0.6f);
                */
                uv[x] = new Vector2(TexWidth / (3 + (Getwidth - 1) / 2) * j, 1.0f / len * i);//Vector3轉Vector2
                x++;
            }
        }

        mesh.vertices = vertice;//mesh網格點生成
        mesh.uv = uv;
        mesh.tangents = tangents;

        int point;
        if (GetPointPos.Count < 1) point = 0;//計算網格數
        else point = ((GetPointPos.Count / (3 + (Getwidth - 1) * 2) - 1)) * 2 * Getwidth;

        triangle = new int[point * 6 ];//計算需要多少三角形點座標

        int t = 0;
        int k = 0;

        for (int vi = 0, x = 1; x <= point; x++, vi += k)
        {
            t = SetQuad(triangle, t, vi, vi + 1, vi + 3 + (2 * (Getwidth - 1)), vi + 4 + (2 * (Getwidth - 1)));
            if (x % (Getwidth * 2) != point % (Getwidth * 2)) k = 1;  //在同一行
            else k = 2;  //對vi的累加  (需換行時)
        }

        mesh.triangles = triangle;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
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
}
