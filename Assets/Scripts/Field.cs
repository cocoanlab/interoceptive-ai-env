using UnityEngine;
using Unity.MLAgents;

[System.Serializable]
public class Resource
{
        public ResourceProperty prefab;
        public int num;
}

// GameObject인 FoodCollectorArea에 부착함
public class Field : MonoBehaviour
{
        // MLAgent 내장 클래스
        EnvironmentParameters m_ResetParams;
        public GameObject foodWater;

        // Food 클래스의 리스트 foods
        public Resource[] resources;

        // range는 음식이 생성되는 범위의 가로와 세로 (정사각형), height은 음식이 떨어지는 높이
        public float range = 40;
        public float height = 1;

        // 음식의 생성 개수 조절
        void SetResourceSize()
        {
                // 하이퍼파라미터 설정 (아마 Python에 존재)에서 num_resource_red가 있으면 그 값을 가져오고 없으면 50으로 설정
                m_ResetParams = Academy.Instance.EnvironmentParameters;
                // float numResourceFood = m_ResetParams.GetWithDefault("numResourceFood", 50.0f);
                // float numResourceWater = m_ResetParams.GetWithDefault("numResourceWater", 50.0f);

                resources[0].num = (int)m_ResetParams.GetWithDefault("numResourceFood", resources[0].num); ;
                resources[1].num = (int)m_ResetParams.GetWithDefault("numResourceWater", resources[1].num);
        }

        // 음식 생성 함수
        void CreateResource(int num, ResourceProperty type)
        {
                for (int i = 0; i < num; i++)
                {

                        if (string.Equals(type.name, "Food"))
                        {
                                ResourceProperty f = Instantiate(type, new Vector3(Random.Range(-range, range), 1f,
                                Random.Range(-range, range)) + transform.position,
                                Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 90f)));
                                f.transform.parent = foodWater.transform;
                                f.InitializeProperties();

                                f.name = "Food" + (i + 1).ToString();

                        }
                        else if (string.Equals(type.name, "Water"))
                        {
                                ResourceProperty f = Instantiate(type, new Vector3(Random.Range(-range, range), 1f,
                                Random.Range(-range, range)) + transform.position,
                                Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 90f)));
                                f.transform.parent = foodWater.transform;
                                f.InitializeProperties();

                                f.name = "Water" + (i + 1).ToString();
                        }

                }
        }

        // 영역 초기화 함수
        public void ResetResourceArea(GameObject[] agents)
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
                SetResourceSize();
                foreach (Resource resource in resources)
                {
                        CreateResource(resource.num, resource.prefab);
                }
        }
}
