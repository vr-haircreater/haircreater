using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class CreateHair : MonoBehaviour
{
    int TriggerDown = 0;  //沒被按下
    int HairCounter = 0; //Hair片數
    public static int HairWidth = 1;//髮片寬度
    public static int HairStyleState = 2;//髮片風格選擇

    float length = 0.025f; //點距離，原本0.05
    public int InputRange = 1;//(寬度Range 1~10)
    public int InputRangeThickness = 5; //(厚度Range 1~10)

    Vector3 NewPos, OldPos; //抓新舊點

    public static List<Vector3> PointPos = new List<Vector3>(); //Pos座標存取
    public static List<Vector3> UpdatePointPos = new List<Vector3>();//變形更新點座標
    public List<GameObject> HairModel = new List<GameObject>(); //髮片Gameobj存取

    public MeshGenerate MeshCreater; //呼叫 MeshGenerate.cs 中的東西給 MeshCreater 用
    public PosGenerate PosCreater; //呼叫 PosGenerate.cs 中的東西給 PosCreater 用

    public SteamVR_Action_Boolean TriggerClick = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");//板機鍵按鈕
    public SteamVR_Action_Boolean LClick = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("SnapTurnRight");//left按鈕
    public SteamVR_Action_Boolean RClick = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("SnapTurnLeft");//right按鈕
    public static SteamVR_Behaviour_Pose Pose;//手把偵測與座標

    public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

    public Texture HairTexture, HairNormal;


    //undo & redo
    Stack<GameObject> StackHairModel = new Stack<GameObject>();
    GameObject redoObject;
    int undo = 0;

    private void Awake()
    {
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
        redoObject = new GameObject();
    }

    private void Start()
    {
        PosCreater = gameObject.AddComponent<PosGenerate>(); //加入PosGenerate
        HairTexture = Resources.Load<Texture2D>("Textures/F00_000_Hair_00");
        HairNormal = Resources.Load<Texture2D>("Textures/F00_000_Hair_00_nml");

    }

    void Update()
    {
        Control();
        if (TriggerDown == 0 && Gather1.icon == 1) //沒被按下
        {
            if (TriggerClick.GetStateDown(Pose.inputSource)) //偵測被按下的瞬間
            {
                GameObject Model = new GameObject(); //創建model gameobj
                HairModel.Add(Model); //加入list
                HairModel[HairCounter].name = "HairModel" + HairCounter; //設定名字
                OldPos = NewPos = Pose.transform.position;
                PointPos.Add(OldPos);
                undo = 0;
                TriggerDown = 1;
            }
        }
        if (TriggerDown == 1) //被按下
        {
            NewPos = Pose.transform.position;
            float dist = Vector3.Distance(OldPos, NewPos); //計算舊點到新點，位置的距離
            if (dist > length) //距離大於設定的長度
            {
                //正規化
                Vector3 NormaizelVec = NewPos - OldPos;
                NormaizelVec = Vector3.Normalize(NormaizelVec);
                NormaizelVec = new Vector3(NormaizelVec.x * length, NormaizelVec.y * length, NormaizelVec.z * length);
                NewPos = NormaizelVec + OldPos;
                PointPos.Add(NewPos);
                PosCreater = gameObject.GetComponent<PosGenerate>(); //加入PosGenerate
                PosCreater.VectorCross(Pose.transform.up, Pose.transform.forward, Pose.transform.right);
                //PosCreater.GetPosition(OldPos, NewPos, InputRange);
                if (HairStyleState == 1) PosCreater.Straight_HairStyle(PointPos, InputRange, InputRangeThickness);
                if (HairStyleState == 2) PosCreater.Dimand_HairStyle(PointPos, InputRange, InputRangeThickness);
                OldPos = NewPos;
            }

            if (PointPos.Count >= 2)
            {
                if (HairModel[HairCounter].GetComponent<MeshGenerate>() == null)
                    MeshCreater = HairModel[HairCounter].AddComponent<MeshGenerate>();
                else MeshCreater = HairModel[HairCounter].GetComponent<MeshGenerate>();
                MeshCreater.GenerateMesh(UpdatePointPos, HairWidth);
                MeshGenerate.GethairColor.SetTexture("_MainTex", HairTexture);
                MeshGenerate.GethairColor.SetTexture("_BumpMap", HairNormal);
            }

            if (TriggerClick.GetStateUp(Pose.inputSource)) //放開
            {
                if (PointPos.Count >= 2) HairCounter++;
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
    void Control()
    {
        //寬度
        if (LClick.GetLastStateDown(Pose.inputSource) && InputRange > 1) InputRange--;
        if (RClick.GetLastStateDown(Pose.inputSource) && InputRange < 10) InputRange++;
        //厚度
        if (Input.GetKeyDown("right") && InputRangeThickness > 1) InputRangeThickness--;
        if (Input.GetKeyDown("left") && InputRangeThickness < 10) InputRangeThickness++;

        if (Input.GetKeyDown("1")) HairStyleState = 1;
        if (Input.GetKeyDown("2")) HairStyleState = 2;

        if (Input.GetKeyDown("u"))
        {
            undo = 1;
            redoObject = Instantiate(HairModel[HairModel.Count - 1]);
            StackHairModel.Push(redoObject);
            redoObject.SetActive(false);
            Destroy(HairModel[HairModel.Count - 1]);
            HairModel.RemoveAt(HairModel.Count - 1);
        }
        if (Input.GetKeyDown("r") && undo == 1)
        {
            GameObject tempobject;
            tempobject = StackHairModel.Pop();
            HairModel.Add(tempobject);
            tempobject.SetActive(true);
            if (StackHairModel.Count == 0) undo = 0;
        }
        if (Gather1.icon == 2) 
        { 
        
        }
        if (Gather1.icon == 3) 
        {
        
        }

    }
}
