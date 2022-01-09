using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLevel : MonoBehaviour
{
    public Slider BlueLevel;
    public Slider RedLevel;
    public Image Bluehandle;
    public Image Redhandle;
    public FoodCollectorAgent agent;

    private float blueLevel;
    private float redLevel;

    void Start()
    {
        BlueLevel.value = 0;
        RedLevel.value = 0;
    }

    void Update()
    {
        redLevel = agent.ResourceLevels[0];
        blueLevel = agent.ResourceLevels[1];

        BlueLevel.value = blueLevel;
        RedLevel.value = redLevel;

        if (blueLevel >= 0)
        {
            Bluehandle.color = Color.green;
        }
        else
        {
            Bluehandle.color = Color.red;
        }

        if (redLevel >= 0)
        {
            Redhandle.color = Color.green;
        }
        else
        {
            Redhandle.color = Color.red;
        }
    }
}
