using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Canvas - AgentTrack 오브젝트 (검정색 점을 의미함)에 부착하는 스크립트
public class AgentTrack : MonoBehaviour
{
    public Camera cam;
    public GameObject agent;
    public GameObject canvas;
    RectTransform canvasRect;
    Vector2 viewportPosition;
    Vector2 screenPosition;

    // 3차원의 scene에서 우측 하단에 2차원의 HeatMap (그래픽 인터페이스)을 넣고
    // 상호작용 (agent가 움직이면 미니맵 상의 검정색 점이 움직임)을 하기 위해 HeatMap 오브젝트의 RectTransform 컴포넌트를 가져옴
    // https://blog.naver.com/pxkey/221558646854
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

    void Update()
    {
        // agent의 scene 상에서의 좌표 (transform)를 cam (TopViewCamera) 상에서의 좌표로 변환
        // https://fiftiesstudy.tistory.com/254
        viewportPosition = cam.WorldToViewportPoint(agent.transform.position);

        // cam 상에서의 좌표를 screen 상에서의 좌표로 변환
        // 변환 과정을 구체적으로 이해하고 구현한 것이 아니라
        // 조금씩 수정해가면서 하드코딩식으로 구현해서 추후 screen의 해상도가 바뀌면 버그가 생길 수 있음
        // 단순히 TopViewCamera가 보여주는 화면을 그대로 출력하는 것이 아니라 HeatMap 상에서
        // agent (검정색 점)가 움직이는 것을 구현해야 해서 이렇게 구현하였음
        // https://answers.unity.com/questions/799616/unity-46-beta-19-how-to-convert-from-world-space-t.html
        screenPosition = new Vector2(((viewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f) - 30), ((viewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f) + 90));

        // 위에서 구한 screen 상에서의 좌표를 AgentTrack 스크립트가 부착할 게임 오브젝터 (검정색 점)의 좌표에 넣어줌
        GetComponent<RectTransform>().anchoredPosition = screenPosition;
    }
}
