using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEating : MonoBehaviour
{
        public FoodCollectorAgent agent;
        public FoodCollectorArea myArea;

        public Collider collide;
        public bool IsEatTriggerOn = false;

        public void OnTriggerStay(Collider other)
        {

                IsEatTriggerOn = true;
                collide = other;

                bool isEaten = false;
                // Debug.Log(agent.IsEat);
                // if (agent.IsAutoEat || agent.IsEat)

                // Debug.Log(agent.IsAutoEat);
                // if (agent.IsAutoEat)
                if (agent.IsAutoEat)
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

                        // IsEatTriggerOn = false;
                        // Debug.Log("Eating done!");
                }

                if (isEaten)
                {
                        other.transform.position = new Vector3(Random.Range(-myArea.range, myArea.range),
                        3f, Random.Range(-myArea.range, myArea.range)) + myArea.transform.position;
                        FoodProperty f = other.gameObject.GetComponent<FoodProperty>();
                        f.InitializeProperties();
                }
        }
}
