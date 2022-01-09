using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    [SerializeField] private float secondPerRealTimeSecound; // 유니티 안에서의 100초 = 현실 세계의 1

    private bool isNight = false;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, 0.1f * secondPerRealTimeSecound * Time.deltaTime);
    }
}
