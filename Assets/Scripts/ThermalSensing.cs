using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.MLAgents;

public class ThermalSensing : MonoBehaviour
{
        public GameObject sun;
        public GameObject area;
        public GameObject agent;
        public InteroceptiveAgent Agent;
        public bool isSensor;
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

                                // isSensor True (8 sensor)
                                if (isSensor)
                                {
                                        if (sun.GetComponent<DayAndNight>().GetIsNight())
                                        {
                                                // nightAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + area.GetComponent<FoodCollectorArea>().nightVariance;
                                                nightAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + sun.GetComponent<DayAndNight>().nightTemperatureVariance;

                                                if (thermalSense > nightAreaTemp)
                                                {
                                                        if (Mathf.Abs(nightAreaTemp) > 50.0f)
                                                        {
                                                                // thermalSense -= Mathf.Abs(nightAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime * 10;
                                                                thermalSense -= Mathf.Abs(nightAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * 10 * agent.GetComponent<InteroceptiveAgent>().thermoSensorChangeRate;
                                                        }
                                                        else
                                                        {
                                                                // thermalSense -= Mathf.Abs(nightAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime;
                                                                thermalSense -= Mathf.Abs(nightAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * agent.GetComponent<InteroceptiveAgent>().thermoSensorChangeRate;
                                                        }

                                                        // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                                                }
                                                else if (thermalSense < nightAreaTemp)
                                                {
                                                        if (Mathf.Abs(nightAreaTemp) > 50.0f)
                                                        {
                                                                // thermalSense += Mathf.Abs(nightAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime * 10;
                                                                thermalSense += Mathf.Abs(nightAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * 10 * agent.GetComponent<InteroceptiveAgent>().thermoSensorChangeRate;
                                                        }
                                                        else
                                                        {
                                                                // thermalSense += Mathf.Abs(nightAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime;
                                                                thermalSense += Mathf.Abs(nightAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * agent.GetComponent<InteroceptiveAgent>().thermoSensorChangeRate;
                                                        }

                                                        // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                                                }
                                                else
                                                {
                                                        thermalSense = nightAreaTemp;

                                                        // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                                                }
                                        }

                                        else
                                        {
                                                // dayAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + area.GetComponent<FoodCollectorArea>().dayVariance;
                                                dayAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + sun.GetComponent<DayAndNight>().dayTemperatureVariance;

                                                if (thermalSense < dayAreaTemp)
                                                {
                                                        if (Mathf.Abs(dayAreaTemp) > 50)
                                                        {
                                                                // thermalSense += Mathf.Abs(dayAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime * 10;
                                                                thermalSense += Mathf.Abs(dayAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * 10 * agent.GetComponent<InteroceptiveAgent>().thermoSensorChangeRate;
                                                        }
                                                        else
                                                        {
                                                                // thermalSense += Mathf.Abs(dayAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime;
                                                                thermalSense += Mathf.Abs(dayAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * agent.GetComponent<InteroceptiveAgent>().thermoSensorChangeRate;
                                                        }

                                                        // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                                                }
                                                else if (thermalSense > dayAreaTemp)
                                                {
                                                        if (Mathf.Abs(dayAreaTemp) > 50)
                                                        {
                                                                // thermalSense -= Mathf.Abs(dayAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime * 10;
                                                                thermalSense -= Mathf.Abs(dayAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * 10 * agent.GetComponent<InteroceptiveAgent>().thermoSensorChangeRate;
                                                        }
                                                        else
                                                        {
                                                                // thermalSense -= Mathf.Abs(dayAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime;
                                                                thermalSense -= Mathf.Abs(dayAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * agent.GetComponent<InteroceptiveAgent>().thermoSensorChangeRate;
                                                        }

                                                        // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                                                }
                                                else
                                                {
                                                        thermalSense = dayAreaTemp;

                                                        // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                                                }
                                        }
                                }

                                // isSensor False (center)
                                else
                                {
                                        if (sun.GetComponent<DayAndNight>().GetIsNight())
                                        {
                                                // nightAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + area.GetComponent<FoodCollectorArea>().nightVariance;
                                                nightAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + sun.GetComponent<DayAndNight>().nightTemperatureVariance;

                                                if (thermalSense > nightAreaTemp)
                                                {
                                                        if (Mathf.Abs(nightAreaTemp) > 50.0f)
                                                        {
                                                                // thermalSense -= Mathf.Abs(nightAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime * 10;
                                                                thermalSense -= Mathf.Abs(nightAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * 10;
                                                        }
                                                        else
                                                        {
                                                                // thermalSense -= Mathf.Abs(nightAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime;
                                                                thermalSense -= Mathf.Abs(nightAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime;
                                                        }

                                                        // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                                                }
                                                else if (thermalSense < nightAreaTemp)
                                                {
                                                        if (Mathf.Abs(nightAreaTemp) > 50.0f)
                                                        {
                                                                // thermalSense += Mathf.Abs(nightAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime * 10;
                                                                thermalSense += Mathf.Abs(nightAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * 10;
                                                        }
                                                        else
                                                        {
                                                                // thermalSense += Mathf.Abs(nightAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime;
                                                                thermalSense += Mathf.Abs(nightAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime;
                                                        }

                                                        // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                                                }
                                                else
                                                {
                                                        thermalSense = nightAreaTemp;

                                                        // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                                                }
                                        }

                                        else
                                        {
                                                // dayAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + area.GetComponent<FoodCollectorArea>().dayVariance;
                                                dayAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + sun.GetComponent<DayAndNight>().dayTemperatureVariance;

                                                if (thermalSense < dayAreaTemp)
                                                {
                                                        if (Mathf.Abs(dayAreaTemp) > 50)
                                                        {
                                                                // thermalSense += Mathf.Abs(dayAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime * 10;
                                                                thermalSense += Mathf.Abs(dayAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * 10;
                                                        }
                                                        else
                                                        {
                                                                // thermalSense += Mathf.Abs(dayAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime;
                                                                thermalSense += Mathf.Abs(dayAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime;
                                                        }

                                                        // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                                                }
                                                else if (thermalSense > dayAreaTemp)
                                                {
                                                        if (Mathf.Abs(dayAreaTemp) > 50)
                                                        {
                                                                // thermalSense -= Mathf.Abs(dayAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime * 10;
                                                                thermalSense -= Mathf.Abs(dayAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime * 10;
                                                        }
                                                        else
                                                        {
                                                                // thermalSense -= Mathf.Abs(dayAreaTemp) * area.GetComponent<FoodCollectorArea>().changeThermoLevelRaate * Time.fixedDeltaTime;
                                                                thermalSense -= Mathf.Abs(dayAreaTemp) * agent.GetComponent<InteroceptiveAgent>().changeThermoLevelRate * Time.fixedDeltaTime;
                                                        }

                                                        // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                                                }
                                                else
                                                {
                                                        thermalSense = dayAreaTemp;

                                                        // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                                                }
                                        }
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
}
