using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

//[RequireComponent(typeof(Light2D))]
public class LightBeat2D : MonoBehaviour
{
    //public Light2D light2DTop, light2DRight, light2DLeft;
    public Light2D[] lights;

    public bool bCanChangeLightIntensity = true;
    public int[] band;
    public float minIntensity, maxIntensity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bCanChangeLightIntensity)
            //_light.intensity = (AudioVisualizer.audioBandBuffer[band] * (maxIntensity - minIntensity)) + minIntensity;
            //foreach(var light in lights)
            //{
            //    light.intensity = (AudioVisualizer.audioBandBuffer[band] * (maxIntensity - minIntensity)) + minIntensity;
            //}

        for (int light = 0; light < lights.Length; ++light)
        {
            lights[light].intensity = (AudioVisualizer.audioBandBuffer[band[light]] * (maxIntensity - minIntensity)) + minIntensity;
        }
    }
}
