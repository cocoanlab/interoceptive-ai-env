using UnityEngine;
using Unity.MLAgents;

[System.Serializable]
public class Food
{
        public FoodProperty prefab;
        public int num;
}

// GameObject인 FoodCollectorArea에 부착함
public class FoodCollectorArea : MonoBehaviour
{
        // MLAgent 내장 클래스
        EnvironmentParameters m_ResetParams;
        public GameObject foodWater;

        // Food 클래스의 리스트 foods
        public Food[] foods;

        // range는 음식이 생성되는 범위의 가로와 세로 (정사각형), height은 음식이 떨어지는 높이
        public float range;
        public float height;

        // 음식의 생성 개수 조절
        void SetFoodSize()
        {
                // 하이퍼파라미터 설정 (아마 Python에 존재)에서 num_resource_red가 있으면 그 값을 가져오고 없으면 50으로 설정
                m_ResetParams = Academy.Instance.EnvironmentParameters;
                float numResourceRed = m_ResetParams.GetWithDefault("num_resource_red", 50.0f);
                float numResourceBlue = m_ResetParams.GetWithDefault("num_resource_blue", 1.0f);

                foods[0].num = (int)numResourceBlue;
                foods[1].num = (int)numResourceRed;
        }

        // 음식 생성 함수
        void CreateFood(int num, FoodProperty type)
        {
                for (int i = 0; i < num; i++)
                {
                        // FoodProperty f = Instantiate(type, new Vector3(Random.Range(-range, range), 1f,
                        //         Random.Range(-range, range)) + transform.position,
                        //         Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 90f)));
                        // f.transform.parent = foodWater.transform;
                        // f.InitializeProperties();
                        
                        // if (f.CompareTag("food_red"))
                        // {
                        //         f.name = "FoodRed" + (i + 1).ToString();
                        // }
                        // else if (f.CompareTag("food_blue"))
                        // {
                        //         f.name = "FoodBlue" + (i + 1).ToString();
                        // }

                        if (string.Equals(type.name, "FoodRed"))
                        {
                                FoodProperty f = Instantiate(type, new Vector3(Random.Range(-range, range), 1f,
                                Random.Range(-range, range)) + transform.position,
                                Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 90f)));
                                f.transform.parent = foodWater.transform;
                                f.InitializeProperties();
                                
                                f.name = "FoodRed" + (i + 1).ToString();

                        }
                        else if (string.Equals(type.name, "FoodBlue"))
                        {
                                // FoodProperty f = Instantiate(type, new Vector3(Random.Range(-range, range), 1f,
                                // Random.Range(-range, range)) + transform.position,
                                // Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 90f)));
                                // f.transform.parent = foodWater.transform;
                                // f.InitializeProperties();
                                
                                // f.name = "FoodBlue" + (i + 1).ToString();
                        }

                }
        }

        // 영역 초기화 함수
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
