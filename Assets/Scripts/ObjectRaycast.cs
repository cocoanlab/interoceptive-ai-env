using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents.Sensors;

public class ObjectRaycast : MonoBehaviour
{
    public GameObject agent;
    public LayerMask layermask;
    public int raysPerDirection = 20;
    public float maxDistance = 5;
    public float radialRange = 100f;
    public RaycastHit hit;

    void Update()
    {
        for (int i = 0; i < raysPerDirection; i++)
        {
            float angle = i * radialRange / (raysPerDirection - 1); // Distribute angles evenly within the range
            Quaternion rotation = Quaternion.Euler(0f, angle - radialRange / 2, 0f); // Adjust angle offset
            Vector3 direction = rotation * transform.forward;

        
            if (Physics.Raycast(transform.position, direction, out hit, maxDistance, layermask))
            {
                Debug.DrawRay(transform.position, direction * maxDistance, Color.red);
                Debug.Log(hit.transform.name);
                agent.GetComponent<InteroceptiveAgent>().Collision();
            }
            else
            {
                Debug.DrawRay(transform.position, direction * maxDistance, Color.green);
            }
        }
    }
}