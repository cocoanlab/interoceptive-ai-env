using UnityEngine;
using UnityEngine.UI;
using Unity.MLAgents;

// GameObject인 FoodCollectorSettings에 부착됨
public class SceneInitialization : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] agents;
    [HideInInspector]
    public FoodCollectorArea[] listArea;

    public void Awake()
    {
        Academy.Instance.OnEnvironmentReset += EnvironmentReset;
    }

    void EnvironmentReset()
    {
        ClearObjects(GameObject.FindGameObjectsWithTag("food_blue"));
        ClearObjects(GameObject.FindGameObjectsWithTag("food_red"));

        agents = GameObject.FindGameObjectsWithTag("agent");
        listArea = FindObjectsOfType<FoodCollectorArea>();
        foreach (var fa in listArea)
        {
            fa.ResetFoodArea(agents);
        }
    }

    void ClearObjects(GameObject[] objects)
    {
        foreach (var food in objects)
        {
            Destroy(food);
        }
    }
}
