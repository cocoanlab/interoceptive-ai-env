using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Agent의 하위 GameObject인 Camera에 부착함
public class CameraFollow : MonoBehaviour
{
    // target에 GameObject인 Agent를 넣어줌
    public GameObject target;
    // 카메라의 위치를 받기 위한 offset
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // GameObject인 Camera의 위치로 설정하고자 하는 값에서 this (CameraFollow) 클래스의 멤버변수 target의 위치를 빼서 offset에 넣어줌
        offset = transform.position - this.target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 위에서 정한 offset을 이용하여 다시 GameObject인 Camera의 위치에 우변의 값을 넣으면 원래 설정하고자 했던 값이 됨
        transform.position = this.target.transform.position + offset;
    }
}
