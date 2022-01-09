using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEating : MonoBehaviour
{
    public FoodCollectorAgent agent;
    public FoodCollectorArea myArea;

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

        if (isEaten)
        {
            other.transform.position = new Vector3(Random.Range(-myArea.range, myArea.range),
            3f, Random.Range(-myArea.range, myArea.range)) + myArea.transform.position;
        }
    }
}
