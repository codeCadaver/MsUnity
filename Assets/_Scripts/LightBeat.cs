using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightBeat : MonoBehaviour
{
    public bool bCanChangeLightIntensity = true;
    public int band;
    public float minIntensity, maxIntensity;

    private Light _light;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bCanChangeLightIntensity)
            _light.intensity = (AudioVisualizer.audioBandBuffer[band] * (maxIntensity - minIntensity)) + minIntensity;
    }
}
