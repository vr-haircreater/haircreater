using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class CreateHair : MonoBehaviour
{
    int TriggerDown = 0;  //沒被按下
    int HairCounter = 0; //Hair片數
    public static int HairWidth = 3;//髮片寬度
    public static int HairStyleState = 1;//髮片風格選擇

    float length = 0.005f; //點距離，0.05有點大，0.005可能是最大?
    public static int InputRange = 1;//(寬度Range 1~10)

    Vector3 NewPos, OldPos; //抓新舊點

    public static List<Vector3> PointPos = new List<Vector3>(); //Pos座標存取
    public static List<Vector3> UpdatePointPos = new List<Vector3>();//變形更新點座標
    public List<GameObject> HairModel = new List<GameObject>(); //髮片Gameobj存取

    public MeshGenerate MeshCreater; //呼叫 MeshGenerate.cs 中的東西給 MeshCreater 用
    public PosGenerate PosCreater; //呼叫 PosGenerate.cs 中的東西給 PosCreater 用

    public SteamVR_Action_Boolean TriggerClick;//板機鍵按鈕
    public SteamVR_Action_Boolean LClick;//left按鈕
    public SteamVR_Action_Boolean RClick;//right按鈕
    public static SteamVR_Behaviour_Pose Pose;

    public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

    public Texture HairTexture, HairNormal;

    public Rigidbody attachPoint;//rigidbody

    private void Awake()
    {
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    private void Start()
    {
        PosCreater = gameObject.AddComponent<PosGenerate>(); //加入PosGenerate
    }


    void Update()
    {
        WidthControl();
        if (TriggerDown == 0) //沒被按下
        {
            if (TriggerClick.GetStateDown(Pose.inputSource)) //偵測被按下的瞬間
            {
                GameObject Model = new GameObject(); //創建model gameobj
                HairModel.Add(Model); //加入list
                HairModel[HairCounter].name = "HairModel" + HairCounter; //設定名字
                OldPos = NewPos = attachPoint.transform.position;
                TriggerDown = 1;
            }
        }
        if (TriggerDown == 1) //被按下
        {
            NewPos = attachPoint.transform.position;
            float dist = Vector3.Distance(OldPos, NewPos); //計算舊點到新點，位置的距離

            if (dist > length) //距離大於設定的長度
            {
                //正規化
                Vector3 NormaizelVec = NewPos - OldPos;
                NormaizelVec = Vector3.Normalize(NormaizelVec);
                NormaizelVec = new Vector3(NormaizelVec.x * 0.005f, NormaizelVec.y * 0.005f, NormaizelVec.z * 0.005f);
                NewPos = NormaizelVec + OldPos;

                PosCreater = gameObject.GetComponent<PosGenerate>(); //加入PosGenerate
                PosCreater.GetPosition(OldPos, NewPos, InputRange);
                //PointPos.Add(OldPos);
                //if (HairStyleState == 1) PosCreater.Straight_HairStyle(PointPos, WidthLimit, add);
                //if (HairStyleState == 2) PosCreater.Dimand_HairStyle(PointPos, WidthLimit, add);
                OldPos = NewPos; 
            }

            if (PointPos.Count >= (3 + (HairWidth - 1) * 2) * 2)
            {
                if (HairModel[HairCounter].GetComponent<MeshGenerate>() == null)
                    MeshCreater = HairModel[HairCounter].AddComponent<MeshGenerate>();
                else MeshCreater = HairModel[HairCounter].GetComponent<MeshGenerate>();
                MeshCreater.GenerateMesh(PointPos, HairWidth);
                MeshGenerate.GethairColor.SetTexture("_MainTex", HairTexture);
                MeshGenerate.GethairColor.SetTexture("_BumpMap", HairNormal);
            }

            if (TriggerClick.GetStateUp(Pose.inputSource)) //放開
            {
                if (PointPos.Count>6) Debug.Log(Vector3.Distance(PointPos[0],PointPos[6]));
                if (PointPos.Count >= (3 + (HairWidth - 1) * 2) * 2) HairCounter++;
                else
                {
                    //清除不夠長所以沒加到程式碼的的髮片gameobj
                    int least = HairModel.Count - 1;
                    Destroy(HairModel[least]);
                    HairModel.RemoveAt(least);
                }
                PointPos.Clear();
                TriggerDown = 0;
            }
        }
    }
    void WidthControl()
    {
        if (LClick.GetLastStateDown(Pose.inputSource) && InputRange > 1)
        {
            InputRange--;
        }
        if (RClick.GetLastStateDown(Pose.inputSource) && InputRange < 10)
        {
            InputRange++;
        }
        if (Input.GetKeyDown("1")) HairStyleState = 1;
        if (Input.GetKeyDown("2")) HairStyleState = 2;
    }
}
