using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameObject인 FoodEatRange에 부착함
public class FoodEating : MonoBehaviour
{
        public FoodCollectorAgent agent;
        public FoodCollectorArea myArea;

        // Agent의 앞쪽에 sphere collider가 있는데 그것의 isTrigger가 켜져있고 다른 collider가 들어왔는지 감지함
        public void OnTriggerStay(Collider other)
        {
                bool isEaten = false;
                if (agent.IsAutoEat || agent.IsEat)
                {
                        if (other.CompareTag("food_red"))
                        {
                                agent.IncreaseLevel("food_red");
                                isEaten = true;
                        }
                        else if (other.CompareTag("food_blue"))
                        {
                                agent.IncreaseLevel("food_blue");
                                isEaten = true;
                        }
                }

                // 음식을 먹으면 그 음식의 위치가 옮겨짐 (사실상 먹으면 다른 곳에 새로 생기는 것과 비슷한 효과)
                if (isEaten)
                {
                        if (other.CompareTag("food_red"))
                        {
                                other.transform.position = new Vector3(Random.Range(-myArea.range, myArea.range),
                                3f, Random.Range(-myArea.range, myArea.range)) + myArea.transform.position;
                                FoodProperty f = other.gameObject.GetComponent<FoodProperty>();
                                f.InitializeProperties();
                        }

                        else if (other.CompareTag("food_blue"))
                        {
                                other.transform.position = new Vector3(Random.Range(-myArea.range, myArea.range),
                                3f, Random.Range(-myArea.range, myArea.range)) + myArea.transform.position;
                                FoodProperty f = other.gameObject.GetComponent<FoodProperty>();
                                f.InitializeProperties();
                        }
                }
        }
}
