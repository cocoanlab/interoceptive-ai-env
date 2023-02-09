using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.MLAgents;

// Field - Agent - ThermalSensor - ThermalSensor_{location}에 부착함
// 주변 온도 감지와 체온과 관련된 스크립트
public class ThermalSensing : MonoBehaviour
{
    public GameObject sun;
    public GameObject area;
    public GameObject agent;
    public InteroceptiveAgent Agent;
    public bool isSensor;
    private float changeRate;
    // public int sensorRate;

    // EnvironmentParameters m_ResetParams;

    float thermalSense;
    float nightAreaTemp;
    float dayAreaTemp;
    string cubeName;
    string[] index;
    int x, y, z;

    // float changeThermoLevelRaate;

    // public void Awake()
    // {
    //     m_ResetParams = Academy.Instance.EnvironmentParameters;
    //     changeThermoLevelRaate = m_ResetParams.GetWithDefault("changeThermoLevelRaate", 0.01f);
    // }

    private void OnTriggerStay(Collider other)
    {
        if (Agent.useThermalObs)
        {
            if (other.tag == "cube")
            {
                cubeName = other.gameObject.name;
                index = cubeName.Split(',');
                if (!int.TryParse(index[0], out x)) x = 0;
                if (!int.TryParse(index[1], out y)) y = 0;
                if (!int.TryParse(index[2], out z)) z = 0;


                if (sun.GetComponent<DayAndNight>().GetIsNight())
                {
                    // nightAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + area.GetComponent<FoodCollectorArea>().nightVariance;
                    nightAreaTemp = CalculateNightAreaTemp(x, z);
                }

                else
                {
                    // dayAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + area.GetComponent<FoodCollectorArea>().dayVariance;
                    dayAreaTemp = CalculateDayAreaTemp(x, z);
                }

            }
        }
    }

    public float GetThermalSense()
    {
        return thermalSense;
    }

    public void SetThermalSense(float value)
    {
        thermalSense = value;
    }

    // 밤에서의 지형 온도 계산
    public float CalculateNightAreaTemp(int x, int z)
    {
        nightAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + sun.GetComponent<DayAndNight>().nightTemperatureVariance;
        return nightAreaTemp;
    }

    // 낮에서의 지형 온도 계산
    public float CalculateDayAreaTemp(int x, int z)
    {
        dayAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + sun.GetComponent<DayAndNight>().dayTemperatureVariance;
        return dayAreaTemp;
    }

    // 체온과 직접적으로 관련된 center 센서는 둔감하게 변하게
    // 환경에 대한 observation 역할을 하는 나머지 센서는 민감하게 변하게 설정
    public float CalculateChangeRate()
    {
        // isSensor True (8 sensor)
        if (isSensor)
        {
            changeRate = agent.GetComponent<InteroceptiveAgent>().thermoSensorChangeRate;
        }
        // isSensor False (center)
        else
        {
            changeRate = 1.0f;
        }
        return changeRate;
    }

    // sensor 값이 점점 밤에서의 지형 온도에 수렴하도록 함
    // 지형 온도가 극단적 (-50 미만이거나 50 초과)이면 10배 더 빠르게 변하도록 함
    // 엄청 뜨거운 물건을 만지면 척수 반사 반응이 나오는 것과 비슷한 맥락
    public float CalculateThermalSenseNight()
    {
        if (thermalSense > nightAreaTemp)
        {
            if (Mathf.Abs(nightAreaTemp) > 50.0f)
            {
                // thermalSense -= Mathf.Abs(nightAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime * 10;
                thermalSense -= Mathf.Abs(nightAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * 10 * changeRate;
            }
            else
            {
                // thermalSense -= Mathf.Abs(nightAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime;
                thermalSense -= Mathf.Abs(nightAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * changeRate;
            }

            // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
        }
        else if (thermalSense < nightAreaTemp)
        {
            if (Mathf.Abs(nightAreaTemp) > 50.0f)
            {
                // thermalSense += Mathf.Abs(nightAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime * 10;
                thermalSense += Mathf.Abs(nightAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * 10 * changeRate;
            }
            else
            {
                // thermalSense += Mathf.Abs(nightAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime;
                thermalSense += Mathf.Abs(nightAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * changeRate;
            }

            // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
        }
        else
        {
            thermalSense = nightAreaTemp;

            // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
        }
        return thermalSense;
    }

    // sensor 값이 점점 낮의 지형 온도에 수렴하도록 함
    public float CalculateThermalSenseDay()
    {
        if (thermalSense < dayAreaTemp)
        {
            if (Mathf.Abs(dayAreaTemp) > 50)
            {
                // thermalSense += Mathf.Abs(dayAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime * 10;
                thermalSense += Mathf.Abs(dayAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * 10 * changeRate;
            }
            else
            {
                // thermalSense += Mathf.Abs(dayAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime;
                thermalSense += Mathf.Abs(dayAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * changeRate;
            }

            // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
        }
        else if (thermalSense > dayAreaTemp)
        {
            if (Mathf.Abs(dayAreaTemp) > 50)
            {
                // thermalSense -= Mathf.Abs(dayAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime * 10;
                thermalSense -= Mathf.Abs(dayAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * 10 * changeRate;
            }
            else
            {
                // thermalSense -= Mathf.Abs(dayAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime;
                thermalSense -= Mathf.Abs(dayAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * changeRate;
            }

            // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
        }
        else
        {
            thermalSense = dayAreaTemp;

            // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
        }
        return thermalSense;
    }

    public void CalculateThermalSense()
    {
        changeRate = CalculateChangeRate();

        if (sun.GetComponent<DayAndNight>().GetIsNight())
        {
            thermalSense = CalculateThermalSenseNight();
        }
        else
        {
            thermalSense = CalculateThermalSenseDay();
        }
        SetThermalSense(thermalSense);
    }
}
