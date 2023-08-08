using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRaycast : MonoBehaviour
{

    public GameObject agent;
    [SerializeField]
    
    public RaycastHit hit;
    public float Maxdistance = 10;
    public LayerMask layermask;

    void Update()
    {
        Vector3 direction = transform.forward;

        Debug.DrawRay(transform.position, direction * Maxdistance, Color.green);

        if(Physics.Raycast(transform.position, direction, out hit, Maxdistance, layermask))
        {
            print(hit.transform.name);
            agent.GetComponent<InteroceptiveAgent>().Collision();

        }
    }
}
    

