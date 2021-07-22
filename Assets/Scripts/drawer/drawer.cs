using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Valve.VR;

public class drawer : MonoBehaviour
{
    public static List<Vector3> PointPos = new List<Vector3>(); //儲存路徑座標
    public static List<Vector3> UpdatePoint = new List<Vector3>();
    public static List<Vector3> LenPoint = new List<Vector3>();

    private Vector3 NewPos, OldPos;//零時座標變數 New & Old
    public int width = 1;//調整寬度
    public int Select = 1;//選擇頭髮style

    public MeshGenerate CreateHair;
    public PositionGenerate CreatePosition;

    public SteamVR_Action_Boolean TriggerClick;//板機鍵按鈕
    public static SteamVR_Behaviour_Pose Pose;

    public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

    int down = 0;//滑鼠判定
    public int count = 0; //紀錄有幾片髮片
    int CopyCount = 0; //備份count
    int clearMesh = 0; //
    int clickUndo = 0; //確定是否有做undo，幾次

    public Texture HairTexture,hairnormal;
    GameObject Hairmodel;
    
    public Rigidbody attachPoint;//rigidbody

    private void Awake()
    {
        Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }
    void Start()
    {
        Hairmodel = new GameObject();
        Hairmodel.name = "HairModel";
        CreateHair = Hairmodel.AddComponent<MeshGenerate>();
        CreatePosition = Hairmodel.AddComponent<PositionGenerate>();
        Debug.Log("按Space 設定寬度");
        
    }

    // Update is called once per frame
    void Update()
    {
        controlWidth();
        controlMesh();
        
        if (down == 0) //沒按下
        {
            if (TriggerClick.GetStateDown(Pose.inputSource) && PanelMain.icon ==1)
            {
                OldPos = NewPos = attachPoint.transform.position;
                down = 1;
            }
        }
        if (down == 1) //按下
        {
            NewPos = attachPoint.transform.position;
            float dist = Vector3.Distance(NewPos, OldPos);
            if (dist > 0.02f)
            {
                CreatePosition = Hairmodel.GetComponent<PositionGenerate>();
                CreatePosition.PosGenerate(NewPos, OldPos, width, PointPos, Select);
                OldPos = NewPos = attachPoint.transform.position;

            }
            if(PointPos.Count >= (3 + (width - 1) * 2) * 3)
                {
                //if(Hairmodel.GetComponent<MeshGenerate>() == null) CreatHair = Hairmodel.AddComponent<MeshGenerate>();//判斷是否已經存在組件(MeshGenerate.cs)
                CreateHair = Hairmodel.GetComponent<MeshGenerate>();
                CreateHair.meshGenerate(count, width, UpdatePoint,TriggerClick, Hairmodel);//呼叫MeshGenerate.cs中的meshGenerate函式
                MeshGenerate.hairColor.SetTexture("_MainTex", HairTexture);
                MeshGenerate.hairColor.SetTexture("_BumpMap", hairnormal);
            }
            if (TriggerClick.GetStateUp(Pose.inputSource))
            {
                if (PointPos.Count >= (3 + (width - 1) * 2) * 3) count++;
                PointPos.Clear();
                LenPoint.Clear();
                UpdatePoint.Clear();
                CopyCount = count;
                down = 0;
                
            }
            
        }

    }

    public void controlWidth()//寬度&髮片風格設定 
    {
        if (Input.GetKeyDown("down") && width > 1 && down == 0)//設定mesh寬度
        {
            width--;
            Debug.Log("Range" + width);
        }
        if (Input.GetKeyDown("up") && down == 0)
        {
            width++;
            Debug.Log("Range" + width);
        }
        if (Input.GetKeyDown("1")) Select = 0;
        if (Input.GetKeyDown("2")) Select = 1;

    }

    public void controlMesh()//髮片控制 clear undo redo color 
    {
        CreateHair = Hairmodel.GetComponent<MeshGenerate>();
        if(PanelMain.icon == 1)
        {
            
        }
        if (PanelMain.icon == 3) // Clear button 被按下了
        {
            CreateHair.ClearMesh(count);
            CopyCount = count;
            count = 0;
            CreateHair.meshGenerate(count, width, UpdatePoint, TriggerClick, Hairmodel);
            PanelMain.icon = 0;
        }

        if (PanelMain.icon == 5) // Undo 被按下
        {
            
            CreateHair.undoMesh(count);
            if (count == 0) count = CopyCount;
            else count--;
            CreateHair.meshGenerate(count, width, UpdatePoint, TriggerClick, Hairmodel);
            PanelMain.icon = 0;
        }
        

        if (CopyCount > count) clickUndo = 1;
        else clickUndo = 0;

        if (PanelMain.icon ==6 && clickUndo==1) //Redo 被按下
        {
            CreateHair.redoMesh();
            count++;
            CreateHair.meshGenerate(count, width, UpdatePoint, TriggerClick, Hairmodel);
            PanelMain.icon = 0;

        }

    }

}