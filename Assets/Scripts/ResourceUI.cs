using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
    public Slider PurpleLevel;
    public Slider GreenLevel;
    public Slider YellowLevel;
    public Slider OrangeLevel;
    public Slider RedLevel;
    public Slider BlueLevel;

    public Image Purplehandle;
    public Image Greenhandle;
    public Image Yellowhandle;
    public Image Orangehandle;
    public Image Redhandle;
    public Image Bluehandle;

    public FoodCollectorAgent agent;

    private float purpleLevel;
    private float greenLevel;
    private float yellowLevel;
    private float orangeLevel;
    private float redLevel;
    private float blueLevel;

    void Start()
    {
        PurpleLevel.value = 0;
        GreenLevel.value = 0;
        YellowLevel.value = 0;
        OrangeLevel.value = 0;
        RedLevel.value = 0;
        BlueLevel.value = 0;
    }

    void Update()
    {
        blueLevel = agent.ResourceLevels[0];
        redLevel = agent.ResourceLevels[1];
        orangeLevel = agent.ResourceLevels[2];
        yellowLevel = agent.ResourceLevels[3];
        greenLevel = agent.ResourceLevels[4];
        purpleLevel = agent.ResourceLevels[5];

        PurpleLevel.value = purpleLevel;
        GreenLevel.value = greenLevel;
        YellowLevel.value = yellowLevel;
        OrangeLevel.value = orangeLevel;
        RedLevel.value = redLevel;
        BlueLevel.value = blueLevel;

        ChangeHandleColor(PurpleLevel.value, Purplehandle);
        ChangeHandleColor(GreenLevel.value, Greenhandle);
        ChangeHandleColor(YellowLevel.value, Yellowhandle);
        ChangeHandleColor(OrangeLevel.value, Orangehandle);
        ChangeHandleColor(RedLevel.value, Redhandle);
        ChangeHandleColor(BlueLevel.value, Bluehandle);
    }

    void ChangeHandleColor(float level, Image handle)
    {
        if (level >= 0) { handle.color = Color.green; } else { handle.color = Color.red; }
    }
}