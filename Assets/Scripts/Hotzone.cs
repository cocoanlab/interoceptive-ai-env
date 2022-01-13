using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotzone : MonoBehaviour
{
    public bool OnHotzone { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "agent")
        {
            OnHotzone = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "agent")
        {
            OnHotzone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "agent")
        {
            OnHotzone = false;
        }
    }

    public bool IsAgentOnHotzone() { return OnHotzone; }
}
