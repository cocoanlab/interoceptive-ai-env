using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentHP : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float viewDistance; // 시야거리 (10미터);

    public string[] objectsToTarget = { "hill", "pond", "rock" }; // Specify the name tags of the objects to target

    Transform currentTarget;

    bool CanSeeObjectWithNameTag(string nameTag)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.forward, out hit, viewDistance))
        {
            if (hit.collider.CompareTag(nameTag)) // Compare against the name tag instead of "Object"
            {
                currentTarget = hit.collider.gameObject.transform;
                Debug.Log(nameTag + " detected!");
                return true;
            }
        }
        return false;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        bool foundTarget = false;

        foreach (string nameTag in objectsToTarget)
        {
            if (CanSeeObjectWithNameTag(nameTag))
            {
                foundTarget = true;
                break; // Exit the loop if any object to target is detected
            }
        }

        if (foundTarget)
        {
            // Move the agent towards the target object
            agent.SetDestination(currentTarget.position);
        }
    }
}

