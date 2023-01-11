using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// GameObject인 Canvas의 하위 GameObject인 ResourceLevelSetting에 부착됨
public class ResourceUI : MonoBehaviour
{
        public Slider FoodLevel;
        public Slider WaterLevel;
        public Slider ThermoLevel;

        public Image Foodhandle;
        public Image Waterhandle;
        public Image Thermohandle;

        public GameObject FoodText;
        public GameObject WaterText;
        public GameObject ThermoText;

        public InteroceptiveAgent agent;

        protected float foodLevel;
        protected float waterLevel;
        protected float thermoLevel;

        protected void Start()
        {
                WaterLevel.value = 0;
                FoodLevel.value = 0;
                Waterhandle.color = Color.blue;
                Foodhandle.color = Color.red;

                if (agent.useThermalObs)
                {
                        ThermoLevel.value = 0;
                        Thermohandle.color = Color.yellow;
                }
                else
                {
                        ThermoLevel.gameObject.SetActive(false);
                        ThermoText.GetComponent<TextMeshProUGUI>().enabled = false;
                }

        }

        protected void Update()
        {
                foodLevel = agent.resourceLevels[0];
                waterLevel = agent.resourceLevels[1];

                WaterLevel.value = waterLevel;
                FoodLevel.value = foodLevel;

                if (agent.useThermalObs)
                {
                        thermoLevel = agent.resourceLevels[2];
                        ThermoLevel.value = thermoLevel;
                }

                // if (blueLevel >= 0) { Bluehandle.color = Color.green; } else { Bluehandle.color = Color.red; }
                // if (redLevel >= 0) { Redhandle.color = Color.green; } else { Redhandle.color = Color.red; }
                // if (yellowLevel >= 0) { Yellowhandle.color = Color.green; } else { Yellowhandle.color = Color.red; }
        }
}
