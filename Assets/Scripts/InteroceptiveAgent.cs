using System.IO;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;
using System.Linq;

// GameObject인 Agent에 부착함

public class InteroceptiveAgent : Agent
{
        // Variables for script
        // protected Field m_MyArea;
        protected SceneInitialization m_SceneInitialization;
        protected EnvironmentParameters m_ResetParams;
        protected ResourceProperty[] FoodObjects;
        protected Rigidbody m_AgentRb;
        protected bool isAgentActionEat = false;
        public bool IsAgentActionEat { get { return this.isAgentActionEat; } set { this.isAgentActionEat = value; } }
        protected bool eatenResource = false;
        public bool EatenResource { get { return this.eatenResource; } set { this.eatenResource = value; } }
        protected string eatenResourceTag;
        public string EatenResourceTag { get { return this.eatenResourceTag; } set { this.eatenResourceTag = value; } }
        protected float bodyTemp;
        protected GameObject[] agents;


        [Header("Game Ojects for script")]
        public GameObject field;
        public GameObject sun;
        public GameObject heatMap;
        public GameObject playRecorder;
        public GameObject foodEatRange;

        [Header("Environment settings")]
        public bool singleTrial = false;
        public bool initRandomAgentPosition = false;
        public Vector3 initAgentPosition;
        public Vector3 initAgentAngle;

        [Header("Actions")]
        public float moveSpeed = 12.0f;
        public float turnSpeed = 800.0f;
        public float eatingDistance = 1.0f;
        public bool autoEat = false;

        // private Rigidbody rb;
        // public float agentVelocity;
        public Vector3 agentRotation;
        public Vector3 agentPosition;
        // public bool IsAutoEat { get { return this.autoEat; } set { this.autoEat = value; } }

        [Header("Observations")]
        public bool useTouchObs;
        public float touchObservation;
        public bool isTouched;
        public bool useOlfactoryObs;
        public float olfactorySensorLength = 100f;
        public int olfactoryFeatureSize = 10;
        public float[] olfactoryObservation;
        public bool useThermalObs;
        public bool relativeThermalObs;
        public float[] thermoObservation;
        public GameObject thermoSensorCenter;
        public GameObject thermoSensorForward;
        public GameObject thermoSensorBackward;
        public GameObject thermoSensorLeft;
        public GameObject thermoSensorRight;
        public GameObject thermoSensorForwardLeft;
        public GameObject thermoSensorForwardRight;
        public GameObject thermoSensorBackwardLeft;
        public GameObject thermoSensorBackwardRight;

        public GameObject WeatherSystem;
        public WeatherState weatherState;


        [Header("Essential variables (EV)")]
        public int countEV = 4;
        public float[] resourceLevels;
        private float[] oldResourceLevels;
        // public float[] ResourceLevels { get { return resourceLevels; } set { resourceLevels = value; } }

        // red
        [Header("Food")]
        public float maxFoodLevel = 15.0f;
        public float minFoodLevel = -15.0f;
        // public float changeFoodLevelRate = 0.002f;
        public float resourceFoodValue = 3.0f;
        public float startFoodLevel = 0.0f;

        // blue
        [Header("Water")]
        public float maxWaterLevel = 15.0f;
        public float minWaterLevel = -15.0f;
        // public float changeWaterLevelRate = 0.002f;
        public float resourceWaterValue = 3.0f;
        public float startWaterLevel = 0.0f;

        // yellow
        [Header("Temperature")]
        public float maxThermoLevel = 15.0f;
        public float minThermoLevel = -15.0f;
        // public float changeThermoLevelRate = 0.005f;
        // public int thermoSensorChangeRate = 10;
        public float startThermoLevel = 0.0f;

        [Header("Merterials")]
        public Material agentMerterial;
        public Material redMaterial;
        public Material blueMaterial;

        // Food Function Coefficient
        // Index 0 : Constant Decay
        // Index 1 : Food Effect
        // Index 2 : Water Effect
        // Index 3 : Thermo Effect
        // Index 4 : Interaction Effect
        // Index 5 : Discrete Change (Eating)
        [Header("Coefficient (Food)")]
        public float changeFood_0 = -0.02f;
        public float changeFood_1 = 0.0f;
        public float changeFood_2 = 0.0f;
        public float changeFood_3 = 0.0f;
        public float changeFood_4 = 0.0f;
        private float changeFood_5 = 0.0f;

        // Water Function Coefficient
        [Header("Coefficient (Water)")]
        public float changeWater_0 = -0.04f;
        public float changeWater_1 = 0.0f;
        public float changeWater_2 = 0.0f;
        public float changeWater_3 = 0.0f;
        public float changeWater_4 = 0.0f;
        private float changeWater_5 = 0.0f;

        // Thermo Function Coefficient
        [Header("Coefficient (Thermo)")]
        public float changeBody_0 = -0.01f;
        public float changeBody_1 = 0.0f;
        public float changeBody_2 = 0.0f;
        public float changeBody_3 = 0.0f;
        public float changeBody_4 = 0.0f;

        // hp
        [Header("Health Point")]
        public float maxHP = 100.0f;
        public float minHP = 0.0f;
        public float changeHP = 1.0f;
        public bool checkHP;
        public float startHP = 100.0f;

        // [Header("Predator / Prey")]
        // public GameObject Pig;
        // Rigidbody m_pig;
        //초기화 작업을 위해 한번 호출되는 메소드
        public override void Initialize()
        {
                m_ResetParams = Academy.Instance.EnvironmentParameters;
                SetResetParameters();

                m_AgentRb = GetComponent<Rigidbody>();
                // m_MyArea = field.GetComponent<Field>();
                eatenResource = false;

                // this.rb = this.gameObject.GetComponent<Rigidbody>();
                this.agentPosition = this.transform.position;
                this.agentRotation = this.transform.eulerAngles;

                this.resourceLevels = new float[this.countEV];
                this.oldResourceLevels = new float[this.countEV];

                if (this.useOlfactoryObs)
                {
                        this.olfactoryObservation = new float[this.olfactoryFeatureSize];
                }

                if (this.useThermalObs)
                {
                        this.thermoObservation = new float[8];

                        // Reset area
                        field.GetComponent<FieldThermoGrid>().EpisodeAreaSmoothing();

                        // Reset heatmap
                        heatMap.GetComponent<HeatMap>().EpisodeHeatMap();
                }
                if (this.useTouchObs)
                {
                        this.touchObservation = 0.0f;
                }

                // m_pig = GetComponent<Rigidbody>();
        }

        //에피소드(학습단위)가 시작할때마다 호출
        public override void OnEpisodeBegin()
        {
                print("New episode begin");

                // Reset agent
                m_AgentRb.velocity = Vector3.zero;
                field.GetComponent<Field>().ResetResourceArea(this.gameObject);
                // m_MyArea.ResetResourceArea(this.gameObject);
                eatenResource = false;

                SetResetParameters();

                // Reset DayAndNight (지금은 DayAndNight가 에피소드 시작할 때 초기화되지 않는데 필요하면 추가)

                // Reset energy
                for (int i = 0; i < this.countEV; i++)
                {
                        if (i == 0)
                        {
                                this.resourceLevels[i] = startFoodLevel;
                                this.oldResourceLevels[i] = this.resourceLevels[i];
                        }
                        else if (i == 1)
                        {
                                this.resourceLevels[i] = startWaterLevel;
                                this.oldResourceLevels[i] = this.resourceLevels[i];
                        }
                        else if (i == 2)
                        {
                                this.resourceLevels[i] = startThermoLevel;
                                this.oldResourceLevels[i] = this.resourceLevels[i];
                        }
                        else if (i == 3)
                        {
                                this.resourceLevels[i] = startHP;
                                this.oldResourceLevels[i] = this.resourceLevels[i];
                        }
                }

                // Reset olfactory
                if (this.useOlfactoryObs)
                {
                        for (int i = 0; i < olfactoryFeatureSize; i++)
                        {
                                this.olfactoryObservation[i] = 0;
                        }
                }

                if (this.useThermalObs)
                {
                        for (int i = 0; i < 8; i++)
                        {
                                this.thermoObservation[i] = 0;
                        }

                        bodyTemp = 0;

                        // thermoSensorCenter.GetComponent<ThermalSensing>().SetThermalSense(0);
                        thermoSensorForward.GetComponent<ThermalSensing>().SetThermalSense(0);
                        thermoSensorBackward.GetComponent<ThermalSensing>().SetThermalSense(0);
                        thermoSensorLeft.GetComponent<ThermalSensing>().SetThermalSense(0);
                        thermoSensorRight.GetComponent<ThermalSensing>().SetThermalSense(0);
                        thermoSensorForwardLeft.GetComponent<ThermalSensing>().SetThermalSense(0);
                        thermoSensorForwardRight.GetComponent<ThermalSensing>().SetThermalSense(0);
                        thermoSensorBackwardLeft.GetComponent<ThermalSensing>().SetThermalSense(0);
                        thermoSensorBackwardRight.GetComponent<ThermalSensing>().SetThermalSense(0);
                        // Reset area
                        field.GetComponent<FieldThermoGrid>().EpisodeAreaSmoothing();

                        // Reset heatmap
                        heatMap.GetComponent<HeatMap>().EpisodeHeatMap();
                }

                if (useTouchObs)
                {
                        this.touchObservation = 0.0f;
                }

                // Reset pig
                //    m_pig.velocity = Vector3.zero;
                //    transform.position = new Vector3(Random.Range(-m_MyArea.range, m_MyArea.range), 2f, Random.Range(-m_MyArea.range, m_MyArea.range)) + area.transform.position;
                //    transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360)));
                //    SetResetParameters();

        }

        //환경 정보를 관측 및 수집해 정책 결정을 위해 브레인에 전달하는 메소드
        public override void CollectObservations(VectorSensor sensor)
        {
                sensor.AddObservation(resourceLevels);
                if (useOlfactoryObs)
                {
                        OlfactorySensingRangeVisualize();
                        sensor.AddObservation(olfactoryObservation);
                }
                if (useThermalObs)
                {
                        sensor.AddObservation(thermoObservation);
                }
                if (useTouchObs)
                {
                        sensor.AddObservation(touchObservation);
                }
                sensor.AddObservation(agentPosition);
                sensor.AddObservation(agentRotation);
        }

        //브레인(정책)으로 부터 전달 받은 행동을 실행하는 메소드
        public override void OnActionReceived(ActionBuffers actions)
        {
                if (playRecorder.GetComponent<CaptureScreenShot>().recordEnable)
                {
                        playRecorder.GetComponent<CaptureScreenShot>().CaptureImage();
                }
                
                this.agentPosition = this.transform.position;
                this.agentRotation = this.transform.eulerAngles;

                if(WeatherSystem.activeSelf == true)  //WeatherSystem.enabled == true
                {
                        if (weatherState == WeatherState.Rain)
                        {   
                        olfactorySensorLength = 50f;
                        }

                        if (weatherState == WeatherState.Thunder)
                        {   
                        olfactorySensorLength = 30f;
                        }

                        if (weatherState == WeatherState.Snow)
                        {   
                        olfactorySensorLength = 20f;
                        }
                        
                } 

                if (eatenResource)
                {
                        if (eatenResourceTag.ToLower() == "food")
                        {
                                changeFood_5 = 1.0f;
                        }
                        if (eatenResourceTag.ToLower() == "water" || eatenResourceTag.ToLower() == "pond")
                        {
                                changeWater_5 = 1.0f;
                        }

                        if (singleTrial)
                        {
                                EndEpisode();
                        }
                }

                // EV (Food, Water, Thermo) Update
                FoodUpdate(changeFood_0, changeFood_1, changeFood_2, changeFood_3, changeFood_4, changeFood_5);
                WaterUpdate(changeWater_0, changeWater_1, changeWater_2, changeWater_3, changeWater_4, changeWater_5);
                // if (this.useThermalObs)
                // {

                // }

                // Olfactory Observation
                if (this.useOlfactoryObs)
                {
                        OlfactoryObserving();
                }

                // ThermalChanging() : thermalSense에 변화 반영시킴
                // ThermalObserving() : 반영된 thermalSense를 다시 가져와 observation에 추가가
                if (this.useThermalObs)
                {
                        // ThermalChanging();
                        ThermalObserving();
                }

                if (this.useTouchObs)
                {
                        TouchObserving();
                        ThermoUpdate(changeBody_0, changeBody_1, changeBody_2, changeBody_3, changeBody_4);
                        field.GetComponent<FieldThermoGrid>().SetDayNightTemperature();
                        // Debug.Log("Touch Obs: " + touchObservation);
                }

                // EV의 상한이나 하한을 넘어가는지 확인
                bool checkFoodLevel = (this.maxFoodLevel < this.resourceLevels[0] || this.resourceLevels[0] < this.minFoodLevel);
                bool checkWaterLevel = (this.maxWaterLevel < this.resourceLevels[1] || this.resourceLevels[1] < this.minWaterLevel);
                bool checkThermoLevel = false;
                if (this.useThermalObs)
                {
                        checkThermoLevel = (this.maxThermoLevel < this.bodyTemp || this.bodyTemp < this.minThermoLevel);
                }

                bool checkHP = (this.resourceLevels[3] < this.minHP);

                // 만약 상한이나 하한을 넘어간 EV가 있다면 episode 종료
                if (checkFoodLevel || checkWaterLevel || checkThermoLevel || checkHP)
                        EndEpisode();

                int action = actions.DiscreteActions[0];
                MoveAgent(action);

                // Reset eating state as default
                eatenResource = false;
                eatenResourceTag = "none";
                changeFood_5 = 0.0f;
                changeWater_5 = 0.0f;

                for (int i = 0; i < this.countEV; i++)
                {
                        oldResourceLevels[i] = resourceLevels[i];
                }
        }

        //개발자(사용자)가 직접 명령을 내릴때 호출하는 메소드(주로 테스트용도 또는 모방학습에 사용)
        public override void Heuristic(in ActionBuffers actionsOut)
        {
                var discreteActionsOut = actionsOut.DiscreteActions;
                discreteActionsOut[0] = 0;
                if (Input.GetKey(KeyCode.UpArrow))
                {
                        discreteActionsOut[0] = 1;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                        discreteActionsOut[0] = 2;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                        discreteActionsOut[0] = 3;
                }
                if (Input.GetKey(KeyCode.Space))
                {
                        discreteActionsOut[0] = 4;
                }
        }

        public void MoveAgent(int action)
        {
                var dirToGo = Vector3.zero;
                var rotateDir = Vector3.zero;

                // Get the action index for movement
                // int action = Mathf.FloorToInt(act[0]);
                /*** Action Category
                 * 0 : None 
                 * 1 : Forward  
                 * 2 : Left
                 * 3 : Right
                 * 4 : Eat
                 * ***/

                this.isAgentActionEat = false;
                switch (action)
                {
                        case 0:
                                m_AgentRb.velocity = Vector3.zero;
                                break;
                        case 1:
                                dirToGo = transform.forward;
                                m_AgentRb.velocity = dirToGo * moveSpeed;
                                break;
                        case 2:
                                transform.Rotate(-transform.up, Time.fixedDeltaTime * turnSpeed);
                                m_AgentRb.velocity = Vector3.zero;
                                break;
                        case 3:
                                transform.Rotate(transform.up, Time.fixedDeltaTime * turnSpeed);
                                m_AgentRb.velocity = Vector3.zero;
                                break;
                        case 4:
                                this.isAgentActionEat = true;
                                m_AgentRb.velocity = Vector3.zero;
                                break;
                }
        }

        private void OlfactoryObserving()
        {
                for (int i = 0; i < olfactoryFeatureSize; i++)
                {
                        olfactoryObservation[i] = 0;
                }

                // agent 크기 바뀌면 z값 확인하기
                Vector3 SpherePos = new Vector3(gameObject.transform.position.x,
                    gameObject.transform.position.y, gameObject.transform.position.z + 0.5f);
                // Detect layer number 8
                Collider[] olfactoryTargets = Physics.OverlapSphere(SpherePos, olfactorySensorLength, 1 << 8);

                int j = 0;
                foreach (Collider other in olfactoryTargets)
                {
                        ResourceProperty resource = other.gameObject.GetComponent<ResourceProperty>();
                        if (resource.CompareTag("pond") || resource.CompareTag("water") || resource.CompareTag("food"))
                        {
                                j += 1;
                                float resourceDistance = Vector3.Distance(SpherePos, resource.transform.position);
                                for (int i = 0; i < olfactoryFeatureSize; i++)
                                {
                                        olfactoryObservation[i] += resource.ResourceP[i] * (1 / resourceDistance);
                                }
                        }
                }
        }

        private void OlfactorySensingRangeVisualize()
        {
                GameObject olfactorySensingRange = this.transform.Find("SensingRange").gameObject;
                Vector3 newScale = new Vector3(this.olfactorySensorLength, this.olfactorySensorLength, this.olfactorySensorLength);
                olfactorySensingRange.transform.localScale = newScale;
        }

        // public void ThermalChanging()
        // {
        //         thermoSensorForward.GetComponent<ThermalSensing>().CalculateThermalSense();
        //         thermoSensorBackward.GetComponent<ThermalSensing>().CalculateThermalSense();
        //         thermoSensorLeft.GetComponent<ThermalSensing>().CalculateThermalSense();
        //         thermoSensorRight.GetComponent<ThermalSensing>().CalculateThermalSense();
        //         thermoSensorForwardLeft.GetComponent<ThermalSensing>().CalculateThermalSense();
        //         thermoSensorForwardRight.GetComponent<ThermalSensing>().CalculateThermalSense();
        //         thermoSensorBackwardLeft.GetComponent<ThermalSensing>().CalculateThermalSense();
        //         thermoSensorBackwardRight.GetComponent<ThermalSensing>().CalculateThermalSense();
        //         thermoSensorCenter.GetComponent<ThermalSensing>().CalculateThermalSense();
        // }

        // 온도에 대한 observation 값은 각 sensor에 입력되는 값과 중앙 sensor (agent의 체온)의 값의 차이를 받아옴
        // 실제 생명체가 온도를 느낄 때 절대적인 온도를 감지하는 것이 아니라 체온과 비교한 상대적인 온도를 감지하기 때문임
        public float[] ThermalObserving()
        {
                // thermoObservation[0] = thermoSensorForward.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
                // thermoObservation[1] = thermoSensorBackward.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
                // thermoObservation[2] = thermoSensorLeft.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
                // thermoObservation[3] = thermoSensorRight.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
                // thermoObservation[4] = thermoSensorForwardLeft.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
                // thermoObservation[5] = thermoSensorForwardRight.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
                // thermoObservation[6] = thermoSensorBackwardLeft.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
                // thermoObservation[7] = thermoSensorBackwardRight.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();

                if (relativeThermalObs)
                {
                        thermoObservation[0] = thermoSensorForward.GetComponent<ThermalSensing>().GetThermalSense() - this.resourceLevels[2];
                        thermoObservation[1] = thermoSensorBackward.GetComponent<ThermalSensing>().GetThermalSense() - this.resourceLevels[2];
                        thermoObservation[2] = thermoSensorLeft.GetComponent<ThermalSensing>().GetThermalSense() - this.resourceLevels[2];
                        thermoObservation[3] = thermoSensorRight.GetComponent<ThermalSensing>().GetThermalSense() - this.resourceLevels[2];
                        thermoObservation[4] = thermoSensorForwardLeft.GetComponent<ThermalSensing>().GetThermalSense() - this.resourceLevels[2];
                        thermoObservation[5] = thermoSensorForwardRight.GetComponent<ThermalSensing>().GetThermalSense() - this.resourceLevels[2];
                        thermoObservation[6] = thermoSensorBackwardLeft.GetComponent<ThermalSensing>().GetThermalSense() - this.resourceLevels[2];
                        thermoObservation[7] = thermoSensorBackwardRight.GetComponent<ThermalSensing>().GetThermalSense() - this.resourceLevels[2];
                }
                else
                {
                        thermoObservation[0] = thermoSensorForward.GetComponent<ThermalSensing>().GetThermalSense();
                        thermoObservation[1] = thermoSensorBackward.GetComponent<ThermalSensing>().GetThermalSense();
                        thermoObservation[2] = thermoSensorLeft.GetComponent<ThermalSensing>().GetThermalSense();
                        thermoObservation[3] = thermoSensorRight.GetComponent<ThermalSensing>().GetThermalSense();
                        thermoObservation[4] = thermoSensorForwardLeft.GetComponent<ThermalSensing>().GetThermalSense();
                        thermoObservation[5] = thermoSensorForwardRight.GetComponent<ThermalSensing>().GetThermalSense();
                        thermoObservation[6] = thermoSensorBackwardLeft.GetComponent<ThermalSensing>().GetThermalSense();
                        thermoObservation[7] = thermoSensorBackwardRight.GetComponent<ThermalSensing>().GetThermalSense();
                }
                // bodyTemp = thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();

                return thermoObservation;
        }

        public void TouchObserving()
        {
                if (isTouched)
                {
                        touchObservation = 1.0f;
                        isTouched = false;
                }
                else
                {
                        touchObservation = 0.0f;
                }
        }

        // EV 간 상호작용을 고려한 업데이트
        public void FoodUpdate(float changeFood_0, float changeFood_1, float changeFood_2, float changeFood_3, float changeFood_4, float changeFood_5)
        {
                this.resourceLevels[0] = this.resourceLevels[0] +
                                        changeFood_0 * maxFoodLevel * Time.fixedDeltaTime +
                                        changeFood_1 * (this.oldResourceLevels[0] + 15) * Time.fixedDeltaTime +
                                        changeFood_2 * (this.oldResourceLevels[1] + 15) * Time.fixedDeltaTime +
                                        changeFood_3 * (this.oldResourceLevels[2] + 15) * Time.fixedDeltaTime +
                                        changeFood_4 * (CalculateInteraction(oldResourceLevels[0], oldResourceLevels[1], oldResourceLevels[2])) * Time.fixedDeltaTime +
                                        changeFood_5 * resourceFoodValue;
        }

        public void WaterUpdate(float changeWater_0, float changeWater_1, float changeWater_2, float changeWater_3, float changeWater_4, float changeWater_5)
        {
                this.resourceLevels[1] = this.resourceLevels[1] +
                                        changeWater_0 * maxWaterLevel * Time.fixedDeltaTime +
                                        changeWater_1 * (this.oldResourceLevels[0] + 15) * Time.fixedDeltaTime +
                                        changeWater_2 * (this.oldResourceLevels[1] + 15) * Time.fixedDeltaTime +
                                        changeWater_3 * (this.oldResourceLevels[2] + 15) * Time.fixedDeltaTime +
                                        changeWater_4 * (CalculateInteraction(oldResourceLevels[0], oldResourceLevels[1], oldResourceLevels[2])) * Time.fixedDeltaTime +
                                        changeWater_5 * resourceWaterValue;
        }

        public void ThermoUpdate(float changeBody_0, float changeBody_1, float changeBody_2, float changeBody_3, float changeBody_4)
        {
                float surroundTemp = 0.0f;
                for (int i = 0; i < thermoObservation.Length; i++)
                {
                        if (relativeThermalObs)
                        { surroundTemp += thermoObservation[i]; }
                        else
                        { surroundTemp += thermoObservation[i] - this.resourceLevels[2]; }

                }
                // Debug.Log("surroundTemp: " + surroundTemp);
                // Debug.Log("Temp Update1: " + changeBody_0 * surroundTemp * Time.fixedDeltaTime);

                bodyTemp = this.bodyTemp +
                            changeBody_0 * surroundTemp * Time.fixedDeltaTime +
                            changeBody_1 * (this.oldResourceLevels[0] + 15) * Time.fixedDeltaTime +
                            changeBody_2 * (this.oldResourceLevels[1] + 15) * Time.fixedDeltaTime +
                            changeBody_3 * (this.oldResourceLevels[2] + 15) * Time.fixedDeltaTime +
                            changeBody_4 * (CalculateInteraction(oldResourceLevels[0], oldResourceLevels[1], oldResourceLevels[2])) * Time.fixedDeltaTime;
                // thermoSensorCenter.GetComponent<ThermalSensing>().SetThermalSense(bodyTemp);
                this.resourceLevels[2] = this.bodyTemp;
        }

        public float CalculateInteraction(float food, float water, float bodyTemp)
        {
                return 1.0f;
        }

        public void Damage()
        {
                resourceLevels[3] -= changeHP * Time.fixedDeltaTime;
        }

        public void SetResetParameters()
        {
                singleTrial = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("singleTrial", System.Convert.ToSingle(singleTrial)));
                initRandomAgentPosition = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("initRandomAgentPosition", System.Convert.ToSingle(initRandomAgentPosition)));

                moveSpeed = m_ResetParams.GetWithDefault("moveSpeed", moveSpeed);
                turnSpeed = m_ResetParams.GetWithDefault("turnSpeed", turnSpeed);
                autoEat = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("autoEat", System.Convert.ToSingle(autoEat)));
                eatingDistance = m_ResetParams.GetWithDefault("eatingDistance", eatingDistance);

                countEV = System.Convert.ToInt32(m_ResetParams.GetWithDefault("countEV", countEV));

                maxFoodLevel = m_ResetParams.GetWithDefault("maxFoodLevel", maxFoodLevel);
                minFoodLevel = m_ResetParams.GetWithDefault("minFoodLevel", minFoodLevel);
                resourceFoodValue = m_ResetParams.GetWithDefault("resourceFoodValue", resourceFoodValue);
                // changeFoodLevelRate = m_ResetParams.GetWithDefault("changeFoodLevelRate", changeFoodLevelRate);
                startFoodLevel = m_ResetParams.GetWithDefault("startFoodLevel", startFoodLevel);

                maxWaterLevel = m_ResetParams.GetWithDefault("maxWaterLevel", maxWaterLevel);
                minWaterLevel = m_ResetParams.GetWithDefault("minWaterLevel", minWaterLevel);
                resourceWaterValue = m_ResetParams.GetWithDefault("resourceWaterValue", resourceWaterValue);
                // changeWaterLevelRate = m_ResetParams.GetWithDefault("changeWaterLevelRate", changeWaterLevelRate);
                startWaterLevel = m_ResetParams.GetWithDefault("startWaterLevel", startWaterLevel);

                useTouchObs = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("useTouchObs", System.Convert.ToSingle(useTouchObs)));

                useOlfactoryObs = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("useOlfactoryObs", System.Convert.ToSingle(useOlfactoryObs)));
                olfactorySensorLength = m_ResetParams.GetWithDefault("olfactorySensorLength", olfactorySensorLength);

                useThermalObs = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("useThermalObs", System.Convert.ToSingle(useThermalObs)));
                maxThermoLevel = m_ResetParams.GetWithDefault("maxThermoLevel", maxThermoLevel);
                minThermoLevel = m_ResetParams.GetWithDefault("minThermoLevel", minThermoLevel);
                // changeThermoLevelRate = m_ResetParams.GetWithDefault("changeThermoLevelRate", changeThermoLevelRate);
                // thermoSensorChangeRate = (int)m_ResetParams.GetWithDefault("thermoSensorChangeRate", thermoSensorChangeRate);
                startThermoLevel = m_ResetParams.GetWithDefault("startThermoLevel", startThermoLevel);

                changeFood_0 = m_ResetParams.GetWithDefault("changeFood_0", changeFood_0);
                changeFood_1 = m_ResetParams.GetWithDefault("changeFood_1", changeFood_1);
                changeFood_2 = m_ResetParams.GetWithDefault("changeFood_2", changeFood_2);
                changeFood_3 = m_ResetParams.GetWithDefault("changeFood_3", changeFood_3);
                changeFood_3 = m_ResetParams.GetWithDefault("changeFood_4", changeFood_4);

                changeWater_0 = m_ResetParams.GetWithDefault("changeWater_0", changeWater_0);
                changeWater_1 = m_ResetParams.GetWithDefault("changeWater_1", changeWater_1);
                changeWater_2 = m_ResetParams.GetWithDefault("changeWater_2", changeWater_2);
                changeWater_3 = m_ResetParams.GetWithDefault("changeWater_3", changeWater_3);
                changeWater_3 = m_ResetParams.GetWithDefault("changeWater_4", changeWater_4);

                changeBody_0 = m_ResetParams.GetWithDefault("changeBody_0", changeBody_0);
                changeBody_1 = m_ResetParams.GetWithDefault("changeBody_1", changeBody_1);
                changeBody_2 = m_ResetParams.GetWithDefault("changeBody_2", changeBody_2);
                changeBody_3 = m_ResetParams.GetWithDefault("changeBody_3", changeBody_3);
                changeBody_3 = m_ResetParams.GetWithDefault("changeBody_4", changeBody_4);

                maxHP = m_ResetParams.GetWithDefault("maxHP", maxHP);
                minHP = m_ResetParams.GetWithDefault("minHP", minHP);
                changeHP = m_ResetParams.GetWithDefault("changeHP", changeHP);
                startHP = m_ResetParams.GetWithDefault("startHP", startHP);
        }
}
