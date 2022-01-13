using System;
using UnityEngine;
using MathNet.Numerics;

public class FoodProperty : MonoBehaviour
{
    int VectorSize = 10;

    //easy
    private float[] BlueProperty = { 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f, 0f, 0f };
    private float[] RedProperty = { 0f, 0f, 0f, 0f, 0f, 1f, 1f, 1f, 1f, 1f };

    //mid
    //private float[] BlueProperty = { 9f, 8f, 7f, 6f, 5f, 0f, 0f, 0f, 0f, 0f };
    //private float[] RedProperty = { 0f, 0f, 0f, 0f, 0f, 9f, 8f, 7f, 6f, 5f };

    //hard
    //private float[] BlueProperty = { 0f, 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f };
    //private float[] RedProperty = { 9f, 8f, 7f, 6f, 5f, 4f, 3f, 2f, 1f, 0f };

    public float[] FoodP { get; private set; }

    public void InitializeProperties()
    {
        if (gameObject.CompareTag("food_blue"))
        {
            FoodP = AddNoise(BlueProperty);
        }
        else if (gameObject.CompareTag("food_red"))
        {
            FoodP = AddNoise(RedProperty);
        }
    }

    private float[] AddNoise(float[] property)
    {
        for (int i = 0; i < VectorSize; i++)
        {
            //easy
            property[i] += 0f;

            // Gaussian
            // float noise = (float)Generate.Normal(1, 0, 1)[0];

            // Uniform(0~1)
            //System.Random r = new System.Random();
            //double noise = r.NextDouble();
            //property[i] += (float)noise;
        }
        return property;
    }
}
