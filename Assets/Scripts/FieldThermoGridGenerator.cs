using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameObject인 FoodCollectorArea에 부착함
// 그리드 역할을 할 cube를 100 x 100
// 총 10000개 생성하고 각각에 좌표를 이용하여 명명함
// 별도로 Inspector 창에서 tag로 "cube" 추가해야 함
public class FieldThermoGridGenerator : MonoBehaviour
{
    private Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 count = new Vector3(50.0f, 0.0f, 50.0f);
    // public bool useThermalObs = false;
    public InteroceptiveAgent agent;


    private void Awake()
    {
        if (agent.useThermalObs)
        {
            generateCube(count, position);
        }

    }

    private void generateCube(Vector3 count, Vector3 position)
    {
        // var layer = LayerMask.NameToLayer("cube");
        Transform parent = new GameObject().transform;
        GameObject newCube = null;

        for (int x = -50; x < count.x; ++x)
        {
            for (int z = -50; z < count.z; ++z)
            {
                // 게임 오브젝트 클래스에 내장되어 있는 CreatePrimitive 스태틱 함수를 이용하여 큐브 생성
                newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newCube.transform.position = new Vector3(x, 0.0f, z);

                // 큐브의 높이 (unity 상에서 y축)를 5배로 늘림
                // 추후 지형에 높이 개념이 도입되었을 때 대응하기 위함
                newCube.transform.localScale = new Vector3(1, 5, 1);

                newCube.GetComponent<Renderer>().enabled = false;

                newCube.name = string.Format("{0},0,{1}", x, z);
                newCube.transform.SetParent(parent);
                // newCube.layer = layer;
                newCube.tag = "cube";

                Collider collider = newCube.GetComponent<Collider>();
                collider.isTrigger = true;
            }
        }

        parent.name = string.Format("Cube groups : {0}x0x{1}", count.x, count.z);
        parent.position = position;
        parent.transform.parent = transform;
        // parent.gameObject.layer = layer;
    }

}
