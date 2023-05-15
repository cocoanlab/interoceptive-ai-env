using UnityEngine;
using Unity.MLAgents;

[System.Serializable]
public class Resource
{
        public ResourceProperty prefab;
        public int num;
}

// [System.Serializable]
// public class ResourcePosition
// {
//         public Vector3 resourcePosition;
// }

// GameObject인 FoodCollectorArea에 부착함
public class Field : MonoBehaviour
{
        // MLAgent 내장 클래스
        EnvironmentParameters m_ResetParams;
        public int randomSeed = 1234;
        public GameObject foodWater;

        // Food 클래스의 리스트 foods
        public Resource[] resources;

        public bool IsRandomFoodPosition;
        public float minDistanceToPond = 50;
        public int randomPositionMaxTry = 100;
        public Vector3[] foodResourcePositions;

        public bool IsRandomWaterPosition;
        public Vector3[] waterResourcePositions;

        public bool IsRandomPondPosition;
        public Vector3[] pondResourcePositions;

        // range는 음식이 생성되는 범위의 가로와 세로 (정사각형), height은 음식이 떨어지는 높이
        public float range = 40;
        public float height = 1;

        public void Awake()
        {
                Random.InitState(randomSeed);
        }


        // 음식의 생성 개수 조절
        void SetResourceSize()
        {
                // 하이퍼파라미터 설정 (Python에 존재)에서 num_resource_red가 있으면 그 값을 가져오고 없으면 50으로 설정
                m_ResetParams = Academy.Instance.EnvironmentParameters;
                // float numResourceFood = m_ResetParams.GetWithDefault("numResourceFood", 50.0f);
                // float numResourceWater = m_ResetParams.GetWithDefault("numResourceWater", 50.0f);
                randomSeed = (int)m_ResetParams.GetWithDefault("randomSeed", randomSeed);
                resources[0].num = (int)m_ResetParams.GetWithDefault("numResourceFood", resources[0].num);
                resources[1].num = (int)m_ResetParams.GetWithDefault("numResourceWater", resources[1].num);
                resources[2].num = (int)m_ResetParams.GetWithDefault("numResourcePond", resources[2].num);

                IsRandomFoodPosition = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("IsRandomFoodPosition", System.Convert.ToSingle(IsRandomFoodPosition)));
                IsRandomWaterPosition = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("IsRandomWaterPosition", System.Convert.ToSingle(IsRandomWaterPosition)));
                IsRandomPondPosition = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("IsRandomPondPosition", System.Convert.ToSingle(IsRandomPondPosition)));

                pondResourcePositions[0].x = m_ResetParams.GetWithDefault("pondResourcePositionsX", pondResourcePositions[0].x);
                pondResourcePositions[0].y = m_ResetParams.GetWithDefault("pondResourcePositionsY", pondResourcePositions[0].y);
                pondResourcePositions[0].z = m_ResetParams.GetWithDefault("pondResourcePositionsZ", pondResourcePositions[0].z);

                minDistanceToPond = m_ResetParams.GetWithDefault("minDistanceToPond", minDistanceToPond);
                randomPositionMaxTry = (int)m_ResetParams.GetWithDefault("randomPositionMaxTry", randomPositionMaxTry);

                // Debug.Log(resources[0].num);
                // Debug.Log(IsRandomResourcePosition);
        }

        // 음식 생성 함수
        void CreateResource(int num, ResourceProperty type)
        {

                for (int i = 0; i < num; i++)
                {
                        // if (string.Equals(type.name, "Pond"))
                        if (type.gameObject.CompareTag("pond"))
                        {
                                if (IsRandomPondPosition)
                                {
                                        ResourceProperty f = Instantiate(type, new Vector3(Random.Range(-range, range), 0f, Random.Range(-range, range)) + transform.position,
                                        Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                                        f.transform.parent = foodWater.transform;
                                        // f.InitializeProperties();
                                        ResourceProperty pondWater = f.gameObject.transform.GetChild(0).GetComponent<ResourceProperty>();
                                        pondWater.InitializeProperties();

                                        f.name = "Pond" + (i + 1).ToString();
                                        pondResourcePositions[i] = f.transform.position;
                                }
                                else
                                {
                                        ResourceProperty f = Instantiate(type, pondResourcePositions[i] + transform.position,
                                                                        Quaternion.Euler(new Vector3(0f, 0f, 0f)));

                                        f.transform.parent = foodWater.transform;
                                        // f.InitializeProperties();
                                        // f.gameObject.transform.GetChild(0).GetComponent<ResourceProperty>().InitializeProperties();

                                        // Pond prefab does not contain collider, so olfactory sensor and eating area cannot detact it.
                                        // Instead, PondWater, the child object of Pond, contains collider.
                                        // So initializing resource properties of PondWater
                                        ResourceProperty pondWater = f.gameObject.transform.GetChild(0).GetComponent<ResourceProperty>();
                                        pondWater.InitializeProperties();
                                        // pondWater.GetComponent<ResourceProperty>().InitializeProperties();
                                        f.name = "Pond" + (i + 1).ToString();

                                }
                        }

                        // else if (string.Equals(type.name, "Food"))
                        else if (type.gameObject.CompareTag("food"))
                        {

                                if (IsRandomFoodPosition)
                                {
                                        bool tooCloseToPond = true;
                                        int tryCount = 0;
                                        ResourceProperty f = Instantiate(type, new Vector3(Random.Range(-range, range), 1f, Random.Range(-range, range)) + transform.position,
                                                                        Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 90f)));

                                        if (resources[2].num > 0)
                                        {
                                                while (tooCloseToPond)
                                                {
                                                        float distanceToPond = Vector3.Distance(pondResourcePositions[0], f.transform.position);

                                                        if (distanceToPond > minDistanceToPond)
                                                        {
                                                                tooCloseToPond = false;
                                                        }
                                                        else
                                                        {
                                                                f.transform.position = new Vector3(Random.Range(-range, range), 1f, Random.Range(-range, range)) + transform.position;
                                                        }

                                                        tryCount += 1;

                                                        if (tryCount > randomPositionMaxTry)
                                                        {
                                                                break;
                                                        }
                                                }
                                        }

                                        f.transform.parent = foodWater.transform;
                                        f.InitializeProperties();

                                        f.name = "Food" + (i + 1).ToString();

                                }
                                else
                                {
                                        ResourceProperty f = Instantiate(type, foodResourcePositions[i] + transform.position,
                                                                        Quaternion.Euler(new Vector3(0f, 0f, 90f)));

                                        f.transform.parent = foodWater.transform;
                                        f.InitializeProperties();

                                        f.name = "Food" + (i + 1).ToString();
                                }

                        }
                        // else if (string.Equals(type.name, "Water"))
                        else if (type.gameObject.CompareTag("water"))
                        {
                                if (IsRandomWaterPosition)
                                {
                                        // ResourceProperty f = Instantiate(type, new Vector3(Random.Range(-range, range), 1f, Random.Range(-range, range)) + transform.position,
                                        // Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 90f)));

                                        bool tooCloseToPond = true;
                                        int tryCount = 0;
                                        ResourceProperty f = Instantiate(type, new Vector3(Random.Range(-range, range), 1f, Random.Range(-range, range)) + transform.position,
                                                                        Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 90f)));

                                        if (resources[2].num > 0)
                                        {
                                                while (tooCloseToPond)
                                                {
                                                        float distanceToPond = Vector3.Distance(pondResourcePositions[0], f.transform.position);

                                                        if (distanceToPond > minDistanceToPond)
                                                        {
                                                                tooCloseToPond = false;
                                                        }
                                                        else
                                                        {
                                                                f.transform.position = new Vector3(Random.Range(-range, range), 1f, Random.Range(-range, range)) + transform.position;
                                                        }

                                                        tryCount += 1;

                                                        if (tryCount > randomPositionMaxTry)
                                                        {
                                                                break;
                                                        }
                                                }
                                        }
                                        f.transform.parent = foodWater.transform;
                                        f.InitializeProperties();

                                        f.name = "Water" + (i + 1).ToString();
                                }
                                else
                                {
                                        ResourceProperty f = Instantiate(type, waterResourcePositions[i] + transform.position,
                                                                        Quaternion.Euler(new Vector3(0f, 0f, 90f)));

                                        f.transform.parent = foodWater.transform;
                                        f.InitializeProperties();
                                        f.name = "Water" + (i + 1).ToString();

                                }
                        }



                }
        }
        public void ResetResourcePosition(Collider resource)
        {
                if (resource.CompareTag("food") || resource.CompareTag("water"))
                {
                        resource.transform.position = new Vector3(Random.Range(-range, range), 1f, Random.Range(-range, range)) + transform.position;

                        bool tooCloseToPond = true;
                        int tryCount = 0;

                        if (resources[2].num > 0)
                        {
                                while (tooCloseToPond)
                                {
                                        float distanceToPond = Vector3.Distance(pondResourcePositions[0], resource.transform.position);

                                        if (distanceToPond > minDistanceToPond)
                                        {
                                                tooCloseToPond = false;
                                        }
                                        else
                                        {
                                                resource.transform.position = new Vector3(Random.Range(-range, range), 1f, Random.Range(-range, range)) + transform.position;
                                        }

                                        tryCount += 1;

                                        if (tryCount > randomPositionMaxTry)
                                        {
                                                break;
                                        }
                                }
                        }
                        ResourceProperty f = resource.gameObject.GetComponent<ResourceProperty>();
                        f.InitializeProperties();
                }

                // else if (resource.CompareTag("water"))
                // {
                //         resource.transform.position = new Vector3(Random.Range(-range, range), 1f, Random.Range(-range, range)) + transform.position;
                //         ResourceProperty f = resource.gameObject.GetComponent<ResourceProperty>();
                //         f.InitializeProperties();
                // }
        }

        // 영역 초기화 함수
        public void ResetResourceArea(GameObject agent)
        {
                ClearObjects(GameObject.FindGameObjectsWithTag("food"));
                ClearObjects(GameObject.FindGameObjectsWithTag("water"));
                ClearObjects(GameObject.FindGameObjectsWithTag("pond"));

                // foreach (GameObject agent in agents)
                // {
                if (agent.transform.parent == gameObject.transform)
                {
                        if (agent.GetComponent<InteroceptiveAgent>().initRandomAgentPosition)
                        {
                                bool tooCloseToPond = true;
                                int tryCount = 0;

                                agent.transform.position = new Vector3(Random.Range(-range, range), 1f, Random.Range(-range, range)) + transform.position;
                                agent.transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360)));

                                if (resources[2].num > 0)
                                {
                                        while (tooCloseToPond)
                                        {
                                                float distanceToPond = Vector3.Distance(pondResourcePositions[0], agent.transform.position);

                                                if (distanceToPond > minDistanceToPond)
                                                {
                                                        tooCloseToPond = false;
                                                }
                                                else
                                                {
                                                        agent.transform.position = new Vector3(Random.Range(-range, range), 1f, Random.Range(-range, range)) + transform.position;
                                                }

                                                tryCount += 1;

                                                if (tryCount > randomPositionMaxTry)
                                                {
                                                        break;
                                                }
                                        }
                                }
                        }
                        else
                        {
                                agent.transform.position = agent.GetComponent<InteroceptiveAgent>().initAgentPosition + transform.position;
                                agent.transform.rotation = Quaternion.Euler(agent.GetComponent<InteroceptiveAgent>().initAgentAngle);
                        }

                        // agent.transform.position = new Vector3(Random.Range(-range, range), 2f, Random.Range(-range, range)) + transform.position;
                        // agent.transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360)));
                }
                // }
                SetResourceSize();

                // Debug.Log(resources.Length);
                foreach (Resource resource in resources)
                {
                        CreateResource(resource.num, resource.prefab);
                }
        }

        void ClearObjects(GameObject[] objects)
        {
                foreach (var obj in objects)
                {
                        Destroy(obj);
                }
        }
}
