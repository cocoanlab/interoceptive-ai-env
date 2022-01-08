using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    float objInitialHeight = 1.0f;
    float objInitialRange = 60.0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1.0f)
        {
            transform.position = this.GetPos();
            rb.velocity = Vector3.zero;
        }
    }

    public Vector3 GetPos()
    {
        return new Vector3(Random.Range(-this.objInitialRange, this.objInitialRange),
                        this.objInitialHeight,
                        Random.Range(-this.objInitialRange, this.objInitialRange));
    }
}
