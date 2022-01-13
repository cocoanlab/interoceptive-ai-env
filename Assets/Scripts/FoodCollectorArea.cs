using UnityEngine;
using Unity.MLAgents;

[System.Serializable]
public class Food
{
    public FoodProperty prefab;
    public int num;
}

public class FoodCollectorArea : MonoBehaviour
{
    EnvironmentParameters m_ResetParams;
    public Food[] foods;
    public float range;
    public float height;

    public void Awake()
    {
        m_ResetParams = Academy.Instance.EnvironmentParameters;
    }

    void SetFoodSize()
    {
        float numResourceRed = m_ResetParams.GetWithDefault("num_resource_red", 50.0f);
        float numResourceBlue = m_ResetParams.GetWithDefault("num_resource_red", 50.0f);
        foods[0].num = (int)numResourceBlue;
        foods[1].num = (int)numResourceRed;
    }

    void CreateFood(int num, FoodProperty type)
    {
        for (int i = 0; i < num; i++)
        {
            FoodProperty f = Instantiate(type, new Vector3(Random.Range(-range, range), 1f,
                Random.Range(-range, range)) + transform.position,
                Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 90f)));
            f.InitializeProperties();
            if (f.CompareTag("food_blue"))
            {
                f.name = "FoodBlue" + (i + 1).ToString();
            }
            else if (f.CompareTag("food_red"))
            {
                f.name = "FoodRed" + (i + 1).ToString();
            }
        }
    }

    public void ResetFoodArea(GameObject[] agents)
    {
        foreach (GameObject agent in agents)
        {
            if (agent.transform.parent == gameObject.transform)
            {
                agent.transform.position = new Vector3(Random.Range(-range, range), 2f,
                    Random.Range(-range, range))
                    + transform.position;
                agent.transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360)));
            }
        }
        SetFoodSize();
        foreach (Food food in foods)
        {
            CreateFood(food.num, food.prefab);
        }
    }
}
