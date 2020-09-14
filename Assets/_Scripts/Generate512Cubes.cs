using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Generate512Cubes : MonoBehaviour
{
    public GameObject soundCube;
    public float heightMultiplier = 100000f;
    public int distanceFromCenter = 100;

    private GameObject[] _sampleCubes = new GameObject[512];
    private float _cubeSpacing = -0.703125f;

    // Start is called before the first frame update
    void Start()
    {
        //_cubeSpacing = 360 / _sampleCubes.Length;
        for(int cube = 0; cube < _sampleCubes.Length; ++cube)
        {
            GameObject sampleCube = Instantiate(soundCube, this.transform.position, Quaternion.identity);
            sampleCube.transform.parent = this.transform;
            sampleCube.name = $"SampleCube_{cube}";
            this.transform.eulerAngles = new Vector3(0, _cubeSpacing * cube, 0);
            sampleCube.transform.position = Vector3.forward * distanceFromCenter;
            _sampleCubes[cube] = sampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _sampleCubes.Length; ++i)
        {
            if(_sampleCubes != null)
            {
                _sampleCubes[i].transform.localScale = new Vector3(10, AudioVisualizer.SAMPLES[i] * heightMultiplier, 10);
            }
        }
    }
}
