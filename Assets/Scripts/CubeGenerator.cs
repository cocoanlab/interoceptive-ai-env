using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameObject인 FoodCollectorArea에 부착함
// 별도로 Inspector 창에서 tag로 "cube" 추가해야 함
public class CubeGenerator : MonoBehaviour
{
    private Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 count = new Vector3(50.0f, 0.0f, 50.0f);

    private void Awake()
    {
        generateCube(count, position);
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
                newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newCube.transform.position = new Vector3(x, 0.0f, z);
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
        // parent.gameObject.layer = layer;
    }

}
