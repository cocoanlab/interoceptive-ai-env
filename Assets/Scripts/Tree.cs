using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    float objects_initial_range = 60.0f;
    float objects_initial_height = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 GetPos()
    {
        return new Vector3(Random.Range(-this.objects_initial_range, this.objects_initial_range),
                        this.objects_initial_height,
                        Random.Range(-this.objects_initial_range, this.objects_initial_range));
    }
}
