using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybox : MonoBehaviour
{
    public Material sky1;
    public Material sky2;

    void Start(){
        RenderSettings.skybox = sky1;
    }

}
//     [SerializeField] private Material skybox;
//     public Material skybox;
//     private float _elapsedTime = 0f;
//     private float _timeScale = 2.5f;
//     private static readonly int Rotation = Shader.PropertyToID("_Rotation");
//     private static readonly int Exposure = Shader.PropertyToID("_Exposure");

//     void Update()
//     {
//         _elapsedTime += Time.deltaTime;
//         skybox.SetFloat(Rotation, _elapsedTime * _timeScale);
//         skybox.SetFloat(Exposure, Mathf.Clamp(Mathf.Sin(_elapsedTime), 0.15f, 1f));
//     }

