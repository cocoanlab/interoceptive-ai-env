using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ThermalSensing : MonoBehaviour
{
    public GameObject sun;
    public GameObject area;

    float thermalSense;
    float nightAreaTemp;
    float dayAreaTemp;
    string cubeName;
    string[] index;
    int x, y, z;

    private void OnTriggerStay(Collider other)
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
                nightAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) - 15.0f;
                if (thermalSense > nightAreaTemp)
                {
                    thermalSense -= Mathf.Abs(nightAreaTemp) * 0.01f * Time.deltaTime;

                    // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                }
                else if (thermalSense < nightAreaTemp)
                {
                    thermalSense += Mathf.Abs(nightAreaTemp) * 0.01f * Time.deltaTime;

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
                dayAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + 15.0f;

                if (thermalSense < dayAreaTemp)
                {
                    thermalSense += Mathf.Abs(dayAreaTemp) * 0.01f * Time.deltaTime;

                    // Debug.Log(cubeName + " : " + area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50).ToString());
                }
                else if (thermalSense > dayAreaTemp)
                {
                    thermalSense -= Mathf.Abs(dayAreaTemp) * 0.01f * Time.deltaTime;

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

    public float GetThermalSense()
    {
        return thermalSense;
    }

    public void SetThermalSense(float value)
    {
        thermalSense = value;
    }
}
