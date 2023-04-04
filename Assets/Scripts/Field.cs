using UnityEngine;
using Unity.MLAgents;
using System.Collections.Generic;

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
        public float randomResourceRange = 40;
        public float randomResourceHeight = 3f;
        public float minDistFromPond;
        public float maxDistFromTree;
        public int maxTryNumSample;

        public bool IsRandomFoodPosition;
        public List<Vector3> foodResourcePositions;

        public bool IsRandomWaterPosition;
        public List<Vector3> waterResourcePositions;

        public bool IsRandomPondPosition;
        public List<Vector3> pondResourcePositions;

        public bool IsRandomTreePosition;
        public List<Vector3> treeResourcePositions;



        // 음식의 생성 개수 조절
        void SetResourceSize()
        {
                // 하이퍼파라미터 설정 (Python에 존재)에서 num_resource_red가 있으면 그 값을 가져오고 없으면 50으로 설정
                m_ResetParams = Academy.Instance.EnvironmentParameters;
                resources[0].num = (int)m_ResetParams.GetWithDefault("numResourcePond", resources[0].num);
                resources[1].num = (int)m_ResetParams.GetWithDefault("numResourceTree", resources[1].num);
                resources[2].num = (int)m_ResetParams.GetWithDefault("numResourceFood", resources[2].num);
                resources[3].num = (int)m_ResetParams.GetWithDefault("numResourceWater", resources[3].num);

                if (IsRandomPondPosition && pondResourcePositions.Count > 0)
                {
                        pondResourcePositions = new List<Vector3>();
                }
                if (IsRandomTreePosition && treeResourcePositions.Count > 0)
                {
                        treeResourcePositions = new List<Vector3>();
                }
                if (IsRandomFoodPosition && foodResourcePositions.Count > 0)
                {
                        foodResourcePositions = new List<Vector3>();
                }
                if (IsRandomWaterPosition && waterResourcePositions.Count > 0)
                {
                        waterResourcePositions = new List<Vector3>();
                }
        }

        // 음식 생성 함수
        void CreateResource(int num, ResourceProperty type)
        {
                for (int i = 0; i < num; i++)
                {
                        ResourceProperty f = Instantiate(type, new Vector3(0f, 0f, 0f), Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                        f.transform.parent = foodWater.transform;
                        f.name = type.name + (i + 1).ToString();

                        if (string.Equals(type.name, "Pond"))
                        {
                                if (IsRandomPondPosition)
                                {
                                        f.transform.position = new Vector3(Random.Range(-randomResourceRange, randomResourceRange), -6f, Random.Range(-randomResourceRange, randomResourceRange)) + transform.position;
                                        // pondResourcePositions[i] = f.transform.position;
                                        pondResourcePositions.Add(f.transform.position);
                                }
                                else
                                {
                                        f.transform.position = pondResourcePositions[i] + transform.position;
                                }

                                // Pond prefab does not contain collider, so olfactory sensor and eating area cannot detact it.
                                // Instead, PondWater, the child object of Pond, contains collider.
                                // So initializing resource properties of PondWater
                                ResourceProperty pondWater = f.gameObject.transform.GetChild(0).GetComponent<ResourceProperty>();
                                pondWater.InitializeProperties();

                        }

                        else if (string.Equals(type.name, "Tree"))
                        {
                                if (IsRandomTreePosition)
                                {
                                        f.transform.position = new Vector3(Random.Range(-randomResourceRange, randomResourceRange), 0f, Random.Range(-randomResourceRange, randomResourceRange)) + transform.position;

                                        if (pondResourcePositions.Count > 0)
                                        {
                                                f.transform.position = CheckTooCloseToTarget(f.transform.position, pondResourcePositions[0], 0f, minDistFromPond, maxTryNumSample);
                                        }
                                        treeResourcePositions.Add(f.transform.position);
                                }
                                else
                                {
                                        f.transform.position = treeResourcePositions[i] + transform.position;
                                }
                                f.InitializeProperties();
                                // Debug.Log("Tree build");
                        }

                        else if (string.Equals(type.name, "Food"))
                        {

                                if (IsRandomFoodPosition)
                                {
                                        f.transform.position = new Vector3(Random.Range(-randomResourceRange, randomResourceRange), randomResourceHeight, Random.Range(-randomResourceRange, randomResourceRange)) + transform.position;
                                        if (treeResourcePositions.Count > 0)
                                        {
                                                f.transform.position = CheckTooFarToTarget(f.transform.position, treeResourcePositions[Random.Range(0, (treeResourcePositions.Count - 1))], randomResourceHeight, maxDistFromTree, 100);
                                        }
                                        else if (pondResourcePositions.Count > 0)
                                        {
                                                f.transform.position = CheckTooCloseToTarget(f.transform.position, pondResourcePositions[0], randomResourceHeight, minDistFromPond, maxTryNumSample);
                                        }
                                }
                                else
                                {
                                        f.transform.position = foodResourcePositions[i] + transform.position;
                                }
                                f.InitializeProperties();

                        }
                        else if (string.Equals(type.name, "Water"))
                        {

                                if (IsRandomFoodPosition)
                                {
                                        f.transform.position = new Vector3(Random.Range(-randomResourceRange, randomResourceRange), randomResourceHeight, Random.Range(-randomResourceRange, randomResourceRange)) + transform.position;

                                        if (pondResourcePositions.Count > 0)
                                        {
                                                f.transform.position = CheckTooCloseToTarget(f.transform.position, pondResourcePositions[0], randomResourceHeight, minDistFromPond, maxTryNumSample);
                                        }
                                }
                                else
                                {
                                        f.transform.position = waterResourcePositions[i] + transform.position;
                                }
                                f.InitializeProperties();
                        }

                }
        }
        public void ResetResourcePosition(Collider resource)
        {
                resource.transform.position = new Vector3(Random.Range(-randomResourceRange, randomResourceRange), randomResourceHeight, Random.Range(-randomResourceRange, randomResourceRange)) + transform.position;
                ResourceProperty f = resource.gameObject.GetComponent<ResourceProperty>();
                f.InitializeProperties();

                if (resource.CompareTag("food"))
                {
                        if (IsRandomFoodPosition)
                        {
                                if (treeResourcePositions.Count > 0)
                                {
                                        f.transform.position = CheckTooFarToTarget(f.transform.position, treeResourcePositions[Random.Range(0, (treeResourcePositions.Count - 1))], randomResourceHeight, maxDistFromTree, 100);
                                }
                                else if (pondResourcePositions.Count > 0)
                                {
                                        f.transform.position = CheckTooCloseToTarget(f.transform.position, pondResourcePositions[0], randomResourceHeight, minDistFromPond, maxTryNumSample);
                                }
                        }

                }
                else if (resource.CompareTag("water"))
                {
                        if (IsRandomFoodPosition)
                        {
                                f.transform.position = new Vector3(Random.Range(-randomResourceRange, randomResourceRange), randomResourceHeight, Random.Range(-randomResourceRange, randomResourceRange)) + transform.position;

                                if (pondResourcePositions.Count > 0)
                                {
                                        f.transform.position = CheckTooCloseToTarget(f.transform.position, pondResourcePositions[0], randomResourceHeight, minDistFromPond, maxTryNumSample);
                                }
                        }
                }
        }

        // 영역 초기화 함수
        public void ResetResourceArea(GameObject agent)
        {
                ClearObjects(GameObject.FindGameObjectsWithTag("pond"));
                ClearObjects(GameObject.FindGameObjectsWithTag("tree"));
                ClearObjects(GameObject.FindGameObjectsWithTag("food"));
                ClearObjects(GameObject.FindGameObjectsWithTag("water"));

                if (agent.transform.parent == gameObject.transform)
                {
                        if (agent.GetComponent<InteroceptiveAgent>().initRandomAgentPosition)
                        {
                                agent.transform.position = new Vector3(Random.Range(-randomResourceRange, randomResourceRange), 1f, Random.Range(-randomResourceRange, randomResourceRange)) + transform.position;
                                agent.transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360)));
                        }
                        else
                        {
                                agent.transform.position = agent.GetComponent<InteroceptiveAgent>().initAgentPosition + transform.position;
                                agent.transform.rotation = Quaternion.Euler(agent.GetComponent<InteroceptiveAgent>().initAgentAngle);
                        }
                }

                SetResourceSize();

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

        Vector3 CheckTooCloseToTarget(Vector3 source, Vector3 target, float hight, float minDistance, int maxNumTry)
        {
                float distanceToTarget = Vector3.Distance(source, target);

                if (distanceToTarget > minDistance)
                {
                        // Debug.Log("Hit at first Try!");
                        return source;
                }

                else
                {
                        bool tooCloseToTarget = true;
                        Vector3 newPosition = new Vector3(0f, 0f, 0f);
                        int tryCount = 0;

                        while (tooCloseToTarget)
                        {
                                newPosition = new Vector3(Random.Range(-randomResourceRange, randomResourceRange), hight, Random.Range(-randomResourceRange, randomResourceRange)) + transform.position;
                                distanceToTarget = Vector3.Distance(newPosition, target);

                                if (distanceToTarget > minDistance)
                                {
                                        break;
                                }

                                tryCount += 1;
                                if (tryCount > maxNumTry)
                                {
                                        Debug.Log("CheckTooCloseToTarget: Cannot make position with this condition");
                                        break;
                                }
                        }

                        return newPosition;
                }
        }

        Vector3 CheckTooFarToTarget(Vector3 source, Vector3 target, float hight, float maxDistance, int maxNumTry)
        {
                float distanceToTarget = Vector3.Distance(source, target);

                if (distanceToTarget < maxDistance)
                {
                        // Debug.Log("Hit at first Try!");
                        return source;
                }

                else
                {
                        bool tooCloseToTarget = true;
                        Vector3 newPosition = new Vector3(0f, 0f, 0f);
                        int tryCount = 0;

                        while (tooCloseToTarget)
                        {
                                newPosition = new Vector3(Random.Range(-randomResourceRange / 10, randomResourceRange / 10), hight, Random.Range(-randomResourceRange / 10, randomResourceRange / 10)) + transform.position + target;
                                distanceToTarget = Vector3.Distance(newPosition, target);

                                if (distanceToTarget < maxDistance)
                                {
                                        break;
                                }

                                tryCount += 1;
                                if (tryCount > maxNumTry)
                                {
                                        Debug.Log("CheckTooFarToTarget: Cannot make position with this condition");
                                        break;
                                }
                        }

                        return newPosition;
                }
        }
}
