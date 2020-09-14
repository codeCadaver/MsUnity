using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.Profiling;

[RequireComponent (typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour
{
    [SerializeField]
    float bufferDecrease = .005f;
    //public static float[] samples = new float[512];
    public static float[] SAMPLES = new float[512];
    public static float[] FREQ_BAND = new float[8];
    public static float[] BAND_BUFFER = new float[8];
    public int channel = 0;

    private float[] _freqBandMaxHeight = new float[8];      // Change Colour
    public static float[] audioBand = new float[8];         // Change Colour
    public static float[] audioBandBuffer = new float[8];   // Change Colour

    private AudioSource _audioSource;
    //private AudioClip _audioClip;
    private float[] _bufferDecrease = new float[8];

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        //_audioClip = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();                                 // Change Colour
        PlayClip();
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(SAMPLES, channel, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for(int i = 0; i < 8; ++i)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if(i == 7)
            {
                sampleCount += 2;
            }
            for(int j = 0; j < sampleCount; ++j)
            {
                average += SAMPLES[count] * (count + 1);
                ++count;
            }

            average /= count;

            FREQ_BAND[i] = average * 10;
        }
    }

    void BandBuffer()
    {
        for (int i = 0; i < BAND_BUFFER.Length; ++i)
        {
            if(FREQ_BAND[i] > BAND_BUFFER[i])
            {
                BAND_BUFFER[i] = FREQ_BAND[i];
                _bufferDecrease[i] = bufferDecrease;
            }
            else
            {
                BAND_BUFFER[i] -= _bufferDecrease[i];
                _bufferDecrease[i] *= 1.2f;
            }
        }
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < audioBand.Length; ++i)
        {
            if(FREQ_BAND[i] > _freqBandMaxHeight[i])
            {
                _freqBandMaxHeight[i] = FREQ_BAND[i];
            }
            audioBand[i] = (FREQ_BAND[i] / _freqBandMaxHeight[i]);
            audioBandBuffer[i] = (BAND_BUFFER[i] / _freqBandMaxHeight[i]);
        }
    }

    void PlayClip()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _audioSource.Play();
        }
    }
}
