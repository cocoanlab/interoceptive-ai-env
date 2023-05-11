using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WeatherData
{
    public string name;
    public ParticleSystem particleSystem;
    [HideInInspector]
    public ParticleSystem.EmissionModule emission;
    
    public bool useAudio;
    public AudioClip weatherAudio;
    public float audioFadeInTimer;
    public float lightIntensity;
    public float lightDimTimer;
    public float fogChangeSpeed;
    public Color fogColor;
    public Color currentFogColor;

}
