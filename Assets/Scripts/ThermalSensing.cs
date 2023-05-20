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
        public GameObject field;
        public GameObject agent;
        public InteroceptiveAgent Agent;
        public bool isSensor;
        private float changeRate;
        // public int sensorRate;

        // EnvironmentParameters m_ResetParams;

        float thermalSense;
        float nightAreaTemp;
        float dayAreaTemp;
        float fieldTemp;
        string cubeName;
        string[] index;
        int x, y, z;

        private void OnTriggerStay(Collider other)
        {
                if (Agent.useThermalObs)
                {
                        if (other.tag == "thermalGridCube")
                        {
                                cubeName = other.gameObject.name;
                                index = cubeName.Split(',');
                                if (!int.TryParse(index[0], out x)) x = 0;
                                if (!int.TryParse(index[1], out y)) y = 0;
                                if (!int.TryParse(index[2], out z)) z = 0;

                                fieldTemp = agent.GetComponent<InteroceptiveAgent>().field.GetComponent<FieldThermoGrid>().GetAreaTemp(x, z);
                                SetThermalSense(fieldTemp);
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
