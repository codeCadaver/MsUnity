using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametricCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    public bool bUseBuffer;
    public bool bChangeColor;

    Material _material;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (bUseBuffer)
        {
            //transform.localScale = new Vector3(transform.localScale.x, (AudioVisualizer.BAND_BUFFER[band] * scaleMultiplier) + startScale, transform.localScale.z);
            transform.localScale = new Vector3(transform.localScale.x, (Mathf.Round((AudioVisualizer.BAND_BUFFER[band] * scaleMultiplier) *10) / 10) + startScale, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioVisualizer.FREQ_BAND[band] * scaleMultiplier) + startScale, transform.localScale.z);
        }

        if (bChangeColor)
        {
            Color color = new Color(AudioVisualizer.audioBandBuffer[band], AudioVisualizer.audioBandBuffer[band], AudioVisualizer.audioBandBuffer[band]);
            _material.SetColor("_EmissionColor", color);
        }
    }
}
