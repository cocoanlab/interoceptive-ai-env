using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentTrack : MonoBehaviour
{
    public Camera cam;
    public GameObject agent;
    public GameObject canvas;
    RectTransform canvasRect;
    Vector2 viewportPosition;
    Vector2 screenPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        canvasRect = canvas.GetComponent<RectTransform>();
    }

    // void Start()
    // {
    //     viewportPosition = cam.WorldToViewportPoint(agent.transform.position);
    //     screenPosition = new Vector2(((viewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f) - 30), ((viewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f) + 30));
    //     GetComponent<RectTransform>().anchoredPosition = screenPosition;
    // }

    // Update is called once per frame
    void Update()
    {
        viewportPosition = cam.WorldToViewportPoint(agent.transform.position);
        screenPosition = new Vector2(((viewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f) - 30), ((viewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f) + 90));
        GetComponent<RectTransform>().anchoredPosition = screenPosition;
    }
}
