using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TreeShader : MonoBehaviour
{
    public Material TreeShader_2;
    public float level = 0.0f;
    public float pluslevel = 0.002f;
    public float time = 0.02f;
    public float maxlevel = 1.0f;
    public bool check = true;
    private int i = 0;
    void Update()
    {
        StartCoroutine(WaitForlt());
    }
    IEnumerator WaitForlt()
    {
        yield return new WaitForSeconds(time);
        if(level < maxlevel)
        {
            level += pluslevel;
            TreeShader_2.SetFloat("_UpNode", level / maxlevel);
        }
        check = true;
    }
}