using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHair : MonoBehaviour
{
    public Texture HairTexture;
    
    // Start is called before the first frame update
    Renderer cube;
    //Color colorStart = Color.red;
    //Color colorEnd = Color.green;
    //float duration = 1.0f;
    void Start()
    {
        cube = GetComponent<Renderer>();
        cube.material.color = new Color(1, 0, 0);//0~1, 255會太多
        //cube.material.SetTexture("F00_000_Hair__00_HAIR", HairTexture);
        cube.material.SetTexture("_MainTex", HairTexture);
    }

    // Update is called once per frame
    void Update()
    {
        //float lerp = Mathf.PingPong(Time.time, duration) / duration;
        //cube.material.color = Color.Lerp(colorStart, colorEnd, lerp);
    }
}