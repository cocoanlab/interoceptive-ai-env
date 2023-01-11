using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameObject인 FoodEatRange에 부착함
public class ResourceEating : MonoBehaviour
{
        public InteroceptiveAgent agent;
        public Field myArea;

        public bool isEaten;

        // Agent의 앞쪽에 sphere collider가 있는데 그것의 isTrigger가 켜져있고 다른 collider가 들어왔는지 감지함
        public void OnTriggerStay(Collider other)
        {
                isEaten = false;
                if (agent.autoEat || agent.IsAgentActionEat)
                {
                        if (other.CompareTag("food"))
                        {
                                // agent.IncreaseLevel("food");
                                isEaten = true;
                                agent.EatenResource = true;
                                agent.EatenResourceTag = "food";
                        }
                        else if (other.CompareTag("water"))
                        {
                                // agent.IncreaseLevel("water");
                                isEaten = true;
                                agent.EatenResource = true;
                                agent.EatenResourceTag = "water";
                        }
                }

                // 음식을 먹으면 그 음식의 위치가 옮겨짐 (사실상 먹으면 다른 곳에 새로 생기는 것과 비슷한 효과)
                if (isEaten)
                {

                        myArea.ResetResourcePosition(other);
                        // if (other.CompareTag("food"))
                        // {
                        //         other.transform.position = new Vector3(Random.Range(-myArea.range, myArea.range),
                        //         3f, Random.Range(-myArea.range, myArea.range)) + myArea.transform.position;
                        //         ResourceProperty f = other.gameObject.GetComponent<ResourceProperty>();
                        //         f.InitializeProperties();
                        // }

                        // else if (other.CompareTag("water"))
                        // {
                        //         other.transform.position = new Vector3(Random.Range(-myArea.range, myArea.range),
                        //         3f, Random.Range(-myArea.range, myArea.range)) + myArea.transform.position;
                        //         ResourceProperty f = other.gameObject.GetComponent<ResourceProperty>();
                        //         f.InitializeProperties();
                        // }
                }
        }
}
