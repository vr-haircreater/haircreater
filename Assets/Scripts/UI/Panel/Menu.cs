using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //public static int icon = 0;
    public GameObject[] btns = new GameObject[12]; // 12 buttons


    private void Awake()
    {
        for(int i =0;i < 12; i++)
        {
            btns[i] = GameObject.Find("button" + i);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
