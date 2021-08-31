using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityVolumeRendering
{
    public class SliderControl : MonoBehaviour
    {
        private Slider slider;
        private Transform sphere;
        private Removable removable;

        //public void SetValue(float value)
        //{
        //    slider = GetComponent<Slider>();
        //    slider.value = value;
        //    sphere = transform.GetChild(0);
        //    sphere.localPosition = new Vector3(value * 140 - 70, 0, 0);
        //}
        // Use this for initialization
        void Start()
        {
            slider = GetComponent<Slider>();
            Debug.Log(slider.value);
            sphere = transform.GetChild(0);
            Debug.Log(sphere.name);
            removable = sphere.GetComponent<Removable>();
            //sphere.localPosition = Vector3.zero;

            //slider.value = (float)0.5;
        }

        // Update is called once per frame
        void Update()
        {
            if (sphere.localPosition.x >= 70)
            {
                slider.value = (float)1;
            }
            else if (sphere.localPosition.x <= -70)
            {
                slider.value = 0;
            }
            else
            {
                slider.value = (sphere.localPosition.x + 70) / 140;
            }

            /*if (!removable.moving)
            {

                if (sphere.localPosition.x >= 70)
                {
                    sphere.localPosition = new Vector3(70, 0, 0);
                }
                else if (sphere.localPosition.x <= -150)
                {
                    sphere.localPosition = new Vector3(-70, 0, 0);
                }
                else
                {
                    sphere.localPosition = new Vector3(sphere.localPosition.x, 0, 0);
                }
            }*/
        }
    }
}
