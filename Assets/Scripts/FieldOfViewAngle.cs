using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfViewAngle : MonoBehaviour
{
    [SerializeField] private float viewAngle; // 시야각 (120도);
    [SerializeField] private float viewDistance; // 시야거리 (10미터);
    [SerializeField] private LayerMask targetMask; // 타겟 마스크 (플레이어)

    public FoodCollectorAgent Agent;
    private NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    public Vector3 GetTargetPos()
    {
        return Agent.transform.position;
    }

    public bool View()
    {
        Collider[] _target = Physics.OverlapSphere(transform.position, viewDistance, targetMask);
        for (int i = 0; i < _target.Length; i++)
        {
            Transform _targetTf = _target[i].transform;
            Debug.Log(_targetTf.tag);

            if (_targetTf.tag == "player")
            {

                // Vector3 _direction = (_targetTf.position - transform.position).normalized;
                // float _angle = Vector3.Angle(_direction, transform.forward);

                // if (_angle < viewAngle * 0.5f)
                // {
                //     RaycastHit _hit;

                //     if (Physics.Raycast(transform.position + transform.up, _direction, out _hit, viewDistance))
                //     {                       
                //         Debug.Log(_hit.transform.tag);

                //         if (_hit.transform.tag == "player")
                //         {
                //             Debug.Log("Player is in FOV of lion");
                //             Debug.DrawRay(transform.position + transform.up, _direction, Color.blue);
                //             return true;
                //         }
                //     }
                // }
                return true;
            }
        }
        return false;
    }


    private float CalcPathLength(Vector3 _targetPos)
    {
        NavMeshPath _path = new NavMeshPath();
        nav.CalculatePath(_targetPos, _path);

        Vector3[] _wayPoint = new Vector3[_path.corners.Length + 2];

        _wayPoint[0] = transform.position;
        _wayPoint[_path.corners.Length + 1] = _targetPos;

        float _pathLength = 0;
        for (int i = 0; i < _path.corners.Length; i++)
        {
            _wayPoint[i + 1] = _path.corners[i]; // 웨이포인트에 경로를 넣음.
            _pathLength += Vector3.Distance(_wayPoint[i], _wayPoint[i + 1]); // 경로 길이 계산.
        }

        return _pathLength;
    }
}
