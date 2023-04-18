// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MaterialChange : MonoBehaviour
// {
//     public Material[] material;
//     public int x;
//     Renderer rend;

//     Vector3 = startcolor;
//     Vector3 = endcolor;

//     float startTime;
//     public float speed = 1.0f;

//     void Start(){
//         x=0;
//         rend = GetComponent<Renderer>();
//         rend.enabled = true;
//         rend.sharedMaterial = material[x];

//         startTime = Time.time;
//         startcolor = new Color(0f,0f,0f);
//         endcolor = new Color(63f, 63f, 63f);

//         var material = GetComponent<Renderer>().sharedMaterial;
//         material.EnableKeyword("_EMISSION");
//     }

//     void Update(){

//     }
// }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MaterialChange : MonoBehaviour
// {
//     Color lerpedColor = Color.white;
//     Renderer renderer;

//     void Start()
//     {
//         renderer = GetComponent<Renderer>();
//     }

//     void Update()
//     {
//         lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
//         renderer.material.color = lerpedColor;
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material[] material;
    public int x;
    Renderer rend;
    public float time = 0.05f;

    // public GameObject Object;

    void Start()
    {   
        x=0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    void Update()
    {
        rend.sharedMaterial = material[x];
        StartCoroutine(WaitForChange());

    }

    IEnumerator WaitForChange()
    {
        yield return new WaitForSeconds(time);
        if(x<1)
        {
            x++;
        }
        
        // else
        // {
        //     x = 0;
        // }
    }
}

