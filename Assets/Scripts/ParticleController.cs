using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ps.Play();
        ps.Emit(150); //즉각적으로 100개의 파티클 방출 , burst같은 것.
        ps.Pause();
    }

}