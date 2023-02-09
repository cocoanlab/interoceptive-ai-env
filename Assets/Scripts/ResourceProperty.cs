using System;
using UnityEngine;
using MathNet.Numerics;

// Food 클래스의 멤버 변수 prefab을 선언할 때 사용됨
public class ResourceProperty : MonoBehaviour
{
    int VectorSize = 10;

    //easy
    private float[] FoodProperty = { 1f, 1f, 1f, 1f, 1f, 0f, 0f, 0f, 0f, 0f };
    private float[] WaterProperty = { 0f, 0f, 0f, 0f, 0f, 1f, 1f, 1f, 1f, 1f };

    //mid
    //private float[] BlueProperty = { 9f, 8f, 7f, 6f, 5f, 0f, 0f, 0f, 0f, 0f };
    //private float[] RedProperty = { 0f, 0f, 0f, 0f, 0f, 9f, 8f, 7f, 6f, 5f };

    //hard
    //private float[] BlueProperty = { 0f, 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f };
    //private float[] RedProperty = { 9f, 8f, 7f, 6f, 5f, 4f, 3f, 2f, 1f, 0f };

    public float[] ResourceP { get; private set; }

    // 음식이 가진 property 초기화 함수 (벡터 성분 초기화)
    public void InitializeProperties()
    {
        if (gameObject.CompareTag("food"))
        {
            ResourceP = AddNoise(FoodProperty);
        }
        else if (gameObject.CompareTag("water"))
        {
            ResourceP = AddNoise(WaterProperty);
        }

    }

    // Sniffing을 할 때 음식에 대한 noise 설정 함수
    private float[] AddNoise(float[] property)
    {
        for (int i = 0; i < VectorSize; i++)
        {
            //easy
            property[i] += 0f;

            // Gaussian
            float noise = (float)Generate.Normal(1, 0, 0.1)[0];
            property[i] += noise;

            // Uniform(0~1)
            //System.Random r = new System.Random();
            //double noise = r.NextDouble();
            //property[i] += (float)noise;
        }
        return property;
    }
}
