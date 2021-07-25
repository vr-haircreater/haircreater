using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class functions : MonoBehaviour
{
    public List<GameObject> ListCubes = new List<GameObject>();
    Stack<GameObject> StackCubes = new Stack<GameObject>();
    //GameObject haha = new GameObject();
    GameObject re = new GameObject();
    int ur = 0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = new GameObject(); 
            ListCubes.Add(go);
            ListCubes[ListCubes.Count - 1].name = "go" + (ListCubes.Count - 1);
            ur = 0;
        }

        if (Input.GetKeyDown("u"))
        {
            ur = 1;
            re = Instantiate(ListCubes[ListCubes.Count - 1]);
            StackCubes.Push(re);
            re.SetActive(false);
            Destroy(ListCubes[ListCubes.Count - 1]);
            ListCubes.RemoveAt(ListCubes.Count - 1);
        }

        if (Input.GetKeyDown("r") && ur == 1)
        {
            GameObject haha;
            haha = StackCubes.Pop();
            ListCubes.Add(haha);
            haha.SetActive(true);
            if (StackCubes.Count == 0) ur = 0;
        }
    }
}
