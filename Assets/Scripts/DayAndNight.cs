using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

// GameObject인 Sun에 부착함
public class DayAndNight : MonoBehaviour
{
        EnvironmentParameters m_ResetParams;

        // 현실 세계에서 1초가 지났을 때 게임 세계에서 몇 초가 지나도록 할 것인지 설정하기 위한 변수
        [SerializeField] private float secondPerRealTimeSecound = 0.0f;
        // private float secondPerRealTimeSecound;

        // 밤 여부 판단
        private bool isNight = false;

        // fog 증감량 비율
        [SerializeField] public float fogDensityCalc;

        // 밤 상태의 Fog 밀도
        [SerializeField] public float nightFogDensity;

        // 낮 상태의 fog 밀도.
        public float dayFogDensity;

        // 계산
        public float currentFogDensity;

        public float dayVariance = 0.0f;
        public float nightVariance = -20.0f;

        public void Awake()
        {
                Academy.Instance.OnEnvironmentReset += SetParameters;
        }

        // Use this for initialization
        void Start()
        {
                // 유니티에 자체적으로 있는 fog 설정
                dayFogDensity = RenderSettings.fogDensity;
                // Linear로 설정을 바꾸면 연산이 간편해진다는 장점이 있다고 함 추후 고려해볼 것
                // RenderSettings.fogMode = FogMode.Linear;
                SetParameters();
        }

        void SetParameters()
        {
                // Setting parameters from python
                m_ResetParams = Academy.Instance.EnvironmentParameters;
                secondPerRealTimeSecound = m_ResetParams.GetWithDefault("day_night_speed", secondPerRealTimeSecound);
                dayVariance = m_ResetParams.GetWithDefault("day_variance", dayVariance);
                nightVariance = m_ResetParams.GetWithDefault("night_variance", nightVariance);
        }


        // Update is called once per frame
        void Update()
        {
                // GameObject인 Sun을 회전시키기 위한 함수
                transform.Rotate(Vector3.right, 0.1f * secondPerRealTimeSecound * Time.deltaTime);

                // GameObject인 Sun의 오일러 각도를 기준으로 낮과 밤을 나눔
                if (transform.eulerAngles.x >= 170)
                        isNight = true;
                else if (transform.eulerAngles.x >= -10)
                        isNight = false;

                if (isNight)
                {
                        // 만약 밤일 경우 현재의 fog 농도를 조금씩 증가시켜 nightFogDensity에 수렴하도록 함
                        if (currentFogDensity < nightFogDensity)
                        {
                                currentFogDensity += 0.1f * fogDensityCalc * Time.deltaTime;
                                RenderSettings.fogDensity = currentFogDensity;
                        }
                        else
                        {
                                RenderSettings.fogDensity = nightFogDensity;
                        }
                }
                else
                {
                        // 만약 낮일 경우 현재의 fog 농도를 조금씩 감소시켜 dayFogDensity에 수렴하도록 함
                        if (currentFogDensity > dayFogDensity)
                        {
                                currentFogDensity -= 10f * fogDensityCalc * Time.deltaTime;
                                RenderSettings.fogDensity = currentFogDensity;
                        }
                        else
                        {
                                RenderSettings.fogDensity = dayFogDensity;
                        }
                }
        }

        public bool GetIsNight()
        {
                return isNight;
        }
}