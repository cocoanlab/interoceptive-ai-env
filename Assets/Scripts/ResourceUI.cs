using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// GameObject인 Canvas의 하위 GameObject인 ResourceLevelSetting에 부착됨
public class ResourceUI : MonoBehaviour
{
        public Slider BlueLevel;
        public Slider RedLevel;
        public Slider YellowLevel;

        public Image Bluehandle;
        public Image Redhandle;
        public Image Yellowhandle;

        public GameObject BlueText;
        public GameObject RedText;
        public GameObject YellowText;

        public FoodCollectorAgent agent;

        private float blueLevel;
        private float redLevel;
        private float yellowLevel;

        void Start()
        {
                BlueLevel.value = 0;
                RedLevel.value = 0;
                Bluehandle.color = Color.blue;
                Redhandle.color = Color.red;

                if (agent.useThermalObs)
                {
                        YellowLevel.value = 0;
                        Yellowhandle.color = Color.yellow;
                }
                else
                {
                        YellowLevel.gameObject.SetActive(false);
                        YellowText.GetComponent<TextMeshProUGUI>().enabled = false;
                }

        }

        void Update()
        {
                redLevel = agent.ResourceLevels[0];
                blueLevel = agent.ResourceLevels[1];

                BlueLevel.value = blueLevel;
                RedLevel.value = redLevel;

                if (agent.useThermalObs)
                {
                        yellowLevel = agent.ResourceLevels[2];
                        YellowLevel.value = yellowLevel;
                }

                // if (blueLevel >= 0) { Bluehandle.color = Color.green; } else { Bluehandle.color = Color.red; }
                // if (redLevel >= 0) { Redhandle.color = Color.green; } else { Redhandle.color = Color.red; }
                // if (yellowLevel >= 0) { Yellowhandle.color = Color.green; } else { Yellowhandle.color = Color.red; }
        }
}
