using UnityEngine;
using UnityEngine.UI;
using Unity.MLAgents;

// GameObject인 FoodCollectorSettings에 부착됨
public class SceneInitialization : MonoBehaviour
{
        // [HideInInspector]
        // public GameObject[] agents;
        public GameObject agent;
        public GameObject field;
        [HideInInspector]
        public Field[] listArea;

        public void Awake()
        {
                Academy.Instance.OnEnvironmentReset += EnvironmentReset;
        }

        void EnvironmentReset()
        {
                field.GetComponent<Field>().ResetResourceArea(agent);
                // ClearObjects(GameObject.FindGameObjectsWithTag("water"));
                // ClearObjects(GameObject.FindGameObjectsWithTag("food"));

                // agents = GameObject.FindGameObjectsWithTag("agent");
                // listArea = FindObjectsOfType<Field>();

                // foreach (var fa in listArea)
                // {
                //         foreach (GameObject agent in agents)
                //         {
                //                 fa.ResetResourceArea(agent);
                //         }
                // }
        }

        // void ClearObjects(GameObject[] objects)
        // {
        //         foreach (var food in objects)
        //         {
        //                 Destroy(food);
        //         }
        // }
}
