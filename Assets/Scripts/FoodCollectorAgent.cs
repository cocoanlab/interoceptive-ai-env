using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System.Linq;


// GameObject인 Agent에 부착함
public class FoodCollectorAgent : Agent
{
    public GameObject area;
    public GameObject sun;

    FoodCollectorArea m_MyArea;
    SceneInitialization m_SceneInitialization;
    Rigidbody m_AgentRb;
    float m_LaserLength;
    EnvironmentParameters m_ResetParams;

    [Header("Movement")]
    public float moveSpeed = 6.0f;
    public float turnSpeed = 200.0f;

    [Header("Merterials")]
    public Material agentMerterial;
    public Material redMaterial;
    public Material blueMaterial;
    public bool useOlfactoryObs;
    public float SensorLength = 0.1f;
    public bool useThermalObs;


    [Header("Resourses")]
    public int numResources = 3;
    private float[] resourceLevels;
    public float[] ResourceLevels { get { return resourceLevels; } set { resourceLevels = value; } }
    private bool autoEat = false;
    public bool IsAutoEat { get { return this.autoEat; } set { this.autoEat = value; } }
    private bool isEat = false;
    public bool IsEat { get { return this.isEat; } set { this.isEat = value; } }

    // red
    [Header("Red")]
    public float maxEnergyLevelRed = 15.0f;
    public float minEnergyLevelRed = -15.0f;
    public float lossRateRed = 0.002f;
    public float resourceEnergyRed = 3.0f;

    // blue
    [Header("Blue")]
    public float maxEnergyLevelBlue = 15.0f;
    public float minEnergyLevelBlue = -15.0f;
    public float lossRateBlue = 0.002f;
    public float resourceEnergyBlue = 3.0f;

    // yellow
    [Header("Yellow")]
    public float maxEnergyLevelYellow = 15.0f;
    public float minEnergyLevelYellow = -15.0f;
    // public float lossRateYellow = 0.002f;
    // public float resourceEnergyYellow = 3.0f;

    // olfactory
    int olfactorySize = 10;
    float[] olfactory;

    // // thermal
    // int thermalSize = 10;
    // float range = 10;

    // // thermalObserving
    // float[] thermalSense;
    // float nightAreaTemp;
    // float dayAreaTemp;
    // string cubeName;
    // string[] index;
    // int x, y, z;

    private float bodyTemp;
    public GameObject sensorCenter;
    public GameObject sensorForward;
    public GameObject sensorBackward;
    public GameObject sensorLeft;
    public GameObject sensorRight;
    public GameObject sensorForwardLeft;
    public GameObject sensorForwardRight;
    public GameObject sensorBackwardLeft;
    public GameObject sensorBackwardRight;

    private float[] thermalSensor;


    FoodProperty[] FoodObjects;

    //초기화 작업을 위해 한번 호출되는 메소드
    public override void Initialize()
    {
        // For two resource
        this.resourceLevels = new float[this.numResources];
        olfactory = new float[olfactorySize];
        thermalSensor = new float[8];
        this.autoEat = false;

        m_AgentRb = GetComponent<Rigidbody>();
        m_MyArea = area.GetComponent<FoodCollectorArea>();
        m_SceneInitialization = FindObjectOfType<SceneInitialization>();
        m_ResetParams = Academy.Instance.EnvironmentParameters;
        SetResetParameters();
    }

    //에피소드(학습단위)가 시작할때마다 호출
    public override void OnEpisodeBegin()
    {
        print("New episode begin");

        // Reset energy
        for (int i = 0; i < this.numResources; i++)
        {
            this.resourceLevels[i] = 0;
        }

        // Reset olfactory
        for (int i = 0; i < olfactorySize; i++)
        {
            olfactory[i] = 0;
        }

        for (int i = 0; i < 8; i++)
        {
            thermalSensor[i] = 0;
        }

        bodyTemp = 0;

        sensorCenter.GetComponent<ThermalSensing>().SetThermalSense(0);
        sensorForward.GetComponent<ThermalSensing>().SetThermalSense(0);
        sensorBackward.GetComponent<ThermalSensing>().SetThermalSense(0);
        sensorLeft.GetComponent<ThermalSensing>().SetThermalSense(0);
        sensorRight.GetComponent<ThermalSensing>().SetThermalSense(0);
        sensorForwardLeft.GetComponent<ThermalSensing>().SetThermalSense(0);
        sensorForwardRight.GetComponent<ThermalSensing>().SetThermalSense(0);
        sensorBackwardLeft.GetComponent<ThermalSensing>().SetThermalSense(0);
        sensorBackwardRight.GetComponent<ThermalSensing>().SetThermalSense(0);


        // Reset agent
        m_AgentRb.velocity = Vector3.zero;
        transform.position = new Vector3(Random.Range(-m_MyArea.range, m_MyArea.range),
            2f, Random.Range(-m_MyArea.range, m_MyArea.range))
            + area.transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360)));
        SetResetParameters();

        // Reset cubes
        FoodObjects = FindObjectsOfType(typeof(FoodProperty)) as FoodProperty[];
        ResetObject(FoodObjects);

        // Reset DayAndNight (지금은 DayAndNight가 에피소드 시작할 때 초기화되지 않는데 필요하면 추가)
    }

    //환경 정보를 관측 및 수집해 정책 결정을 위해 브레인에 전달하는 메소드
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(resourceLevels);
        if (useOlfactoryObs)
        {
            sensor.AddObservation(olfactory);

            // 작동 확인용 (olfactory는 반경 내에서 임의의 음식 하나에 대한 property만 가져오는가?)
            // Debug.Log("Olfactory");
            // Debug.Log(olfactory[0].ToString() + "||" + olfactory[1].ToString() + "||" + olfactory[2].ToString());
        }
        if (useThermalObs)
        {
            sensor.AddObservation(thermalSensor);

            // Debug.Log("ThermalSense : " + thermalSense[0].ToString() + ", " + thermalSense[1].ToString() + ", " + thermalSense[2].ToString() + ", " + thermalSense[3].ToString() + ", " + thermalSense[4].ToString());
            // Debug.Log(resourceLevels[2].ToString());
            // Debug.Log(bodyTemp.ToString());

            // if (bodyTemp != 0)
            // {
            //     sensor.AddObservation(thermalSensor);
            //     Debug.Log("Success");
            // }

            // 작동 확인용
            // if (thermalSense[0] > 5)
            // {
            //     float temp = bodyTemp;
            //     sensor.AddObservation(thermalSense);
            //     Debug.Log("ThermalSense : " + thermalSense[0].ToString() + ", " + thermalSense[1].ToString() + ", " + thermalSense[2].ToString() + ", " + thermalSense[3].ToString() + ", " + thermalSense[4].ToString());
            //     Debug.Log(resourceLevels[2].ToString());
            //     Debug.Log(bodyTemp.ToString());
            // }
        }
    }

    //브레인(정책)으로 부터 전달 받은 행동을 실행하는 메소드
    public override void OnActionReceived(ActionBuffers actions)
    {
        this.resourceLevels[0] -= this.lossRateRed * Time.fixedDeltaTime;
        this.resourceLevels[1] -= this.lossRateBlue * Time.fixedDeltaTime;
        this.resourceLevels[2] = this.bodyTemp;

        if ((this.maxEnergyLevelRed < this.resourceLevels[0] || this.resourceLevels[0] < this.minEnergyLevelRed)
        || (this.maxEnergyLevelBlue < this.resourceLevels[1] || this.resourceLevels[1] < this.minEnergyLevelBlue)
        || (this.maxEnergyLevelYellow < this.bodyTemp || this.bodyTemp < this.minEnergyLevelYellow))
            EndEpisode();

        PropertyObserving();
        string olf = "Olfactory: ";
        for (int i = 0; i < olfactorySize; i++)
        {
            olf += olfactory[i];
            olf += ", ";
        }

        // olfactory 정보 출력 (정상적으로 작동하는 것 확인하면 주석 처리)
        // if (useOlfactoryObs) { Debug.Log(olf); }

        ThermalObserving();

        int action = actions.DiscreteActions[0];
        MoveAgent(action);
    }

    //개발자(사용자)가 직접 명령을 내릴때 호출하는 메소드(주로 테스트용도 또는 모방학습에 사용)
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = 0;
        // actionsOut[0] = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // actionsOut[0] = 1f;
            discreteActionsOut[0] = 1;
            Debug.Log("Forward!");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // actionsOut[0] = 2f;
            discreteActionsOut[0] = 2;
            Debug.Log("Left!");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // actionsOut[0] = 3f;
            discreteActionsOut[0] = 3;
            Debug.Log("Right!");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            // actionsOut[0] = 4f;
            discreteActionsOut[0] = 4;
            Debug.Log("Eat!");
        }
    }

    //
    public void ResetObject(FoodProperty[] objects)
    {
        foreach (var food in objects)
        {
            // Area must be square!!
            float food_x = food.transform.position.x;
            float food_y = food.transform.position.y;
            float food_z = food.transform.position.z;

            float area_x = m_MyArea.transform.position.x;
            float area_y = m_MyArea.transform.position.y;
            float area_z = m_MyArea.transform.position.z;

            if (food_x > (-m_MyArea.range + area_x) && food_x < (m_MyArea.range + area_x)
                && food_y > area_y && food_y < m_MyArea.height + area_y
                && food_z > (-m_MyArea.range + area_z) && food_z < (m_MyArea.range + area_z))
            {
                food.transform.position = new Vector3(Random.Range(-m_MyArea.range, m_MyArea.range),
                    m_MyArea.height, Random.Range(-m_MyArea.range, m_MyArea.range)) + m_MyArea.transform.position;
                food.InitializeProperties();
            }
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

        this.isEat = false;
        switch (action)
        {
            case 0:
                break;
            case 1:
                dirToGo = transform.forward;
                m_AgentRb.velocity = dirToGo * moveSpeed;
                Debug.Log("Forward!");
                break;
            case 2:
                transform.Rotate(-transform.up, Time.fixedDeltaTime * turnSpeed);
                Debug.Log("Left!");
                break;
            case 3:
                transform.Rotate(transform.up, Time.fixedDeltaTime * turnSpeed);
                Debug.Log("Right!");
                break;
            case 4:
                this.isEat = true;
                Debug.Log("Eat!");
                break;
        }
    }

    public void SetResetParameters()
    {
        moveSpeed = m_ResetParams.GetWithDefault("move_speed", moveSpeed);
        turnSpeed = m_ResetParams.GetWithDefault("turn_speed", turnSpeed);
        autoEat = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("auto_eat", 0));

        maxEnergyLevelRed = m_ResetParams.GetWithDefault("max_energy_level_red", maxEnergyLevelRed);
        minEnergyLevelRed = m_ResetParams.GetWithDefault("min_energy_level_red", minEnergyLevelRed);
        resourceEnergyRed = m_ResetParams.GetWithDefault("resource_energy_red", resourceEnergyRed);
        lossRateRed = m_ResetParams.GetWithDefault("loss_rate_red", lossRateRed);

        maxEnergyLevelBlue = m_ResetParams.GetWithDefault("max_energy_level_blue", maxEnergyLevelBlue);
        minEnergyLevelBlue = m_ResetParams.GetWithDefault("min_energy_level_blue", minEnergyLevelBlue);
        resourceEnergyBlue = m_ResetParams.GetWithDefault("resource_energy_blue", resourceEnergyBlue);
        lossRateBlue = m_ResetParams.GetWithDefault("loss_rate_blue", lossRateBlue);

        maxEnergyLevelYellow = m_ResetParams.GetWithDefault("max_energy_level_blue", maxEnergyLevelYellow);
        minEnergyLevelYellow = m_ResetParams.GetWithDefault("min_energy_level_blue", minEnergyLevelYellow);
        // resourceEnergyYellow = m_ResetParams.GetWithDefault("resource_energy_blue", resourceEnergyYellow);
        // lossRateYellow = m_ResetParams.GetWithDefault("loss_rate_blue", lossRateYellow);

        m_LaserLength = m_ResetParams.GetWithDefault("laser_length", 1.0f);
    }

    public void IncreaseLevel(string tag)
    {
        if (tag == "food_red")
        {
            this.resourceLevels[0] += this.resourceEnergyRed;
        }
        if (tag == "food_blue")
        {
            this.resourceLevels[1] += this.resourceEnergyBlue;
        }
    }

    private void PropertyObserving()
    {
        for (int i = 0; i < olfactorySize; i++)
        {
            olfactory[i] = 0;
        }

        // agent 크기 바뀌면 z값 확인하기
        Vector3 SpherePos = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y, gameObject.transform.position.z + 0.5f);
        // Food layer
        Collider[] foods = Physics.OverlapSphere(SpherePos, SensorLength, 1 << 8);

        int j = 0;
        foreach (Collider other in foods)
        {
            FoodProperty food = other.gameObject.GetComponent<FoodProperty>();
            if (food.CompareTag("food_blue") || food.CompareTag("food_red"))
            {
                j += 1;
                float foodDistance = Vector3.Distance(SpherePos, food.transform.position);
                for (int i = 0; i < olfactorySize; i++)
                {
                    olfactory[i] += food.FoodP[i] * (1 / foodDistance);
                }
            }
        }
        //return olfactory;
    }

    public float[] ThermalObserving()
    {
        thermalSensor[0] = sensorForward.GetComponent<ThermalSensing>().GetThermalSense() - sensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermalSensor[1] = sensorBackward.GetComponent<ThermalSensing>().GetThermalSense() - sensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermalSensor[2] = sensorLeft.GetComponent<ThermalSensing>().GetThermalSense() - sensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermalSensor[3] = sensorRight.GetComponent<ThermalSensing>().GetThermalSense() - sensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermalSensor[4] = sensorForwardLeft.GetComponent<ThermalSensing>().GetThermalSense() - sensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermalSensor[5] = sensorForwardRight.GetComponent<ThermalSensing>().GetThermalSense() - sensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermalSensor[6] = sensorBackwardLeft.GetComponent<ThermalSensing>().GetThermalSense() - sensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermalSensor[7] = sensorBackwardRight.GetComponent<ThermalSensing>().GetThermalSense() - sensorCenter.GetComponent<ThermalSensing>().GetThermalSense();

        // Debug.Log("Forward (0) : " + thermalSensor[0].ToString());
        // Debug.Log("Backward (1) : " + thermalSensor[1].ToString());
        // Debug.Log("Left (2) : " + thermalSensor[2].ToString());
        // Debug.Log("Right (3) : " + thermalSensor[3].ToString());
        // Debug.Log("ForwardLeft (4) : " + thermalSensor[4].ToString());
        // Debug.Log("ForwardRight (5) : " + thermalSensor[5].ToString());
        // Debug.Log("BackwardLeft (6) : " + thermalSensor[6].ToString());
        // Debug.Log("BackwardRight (7) : " + thermalSensor[7].ToString());

        bodyTemp = sensorCenter.GetComponent<ThermalSensing>().GetThermalSense();

        // Debug.Log("BodyTemp : " + bodyTemp.ToString());

        return thermalSensor;
    }

    // public float[] ThermalObserving()
    // {
    //     Vector3 offset = new Vector3(0, GetComponent<BoxCollider>().size.z, 0);
    //     Collider[] colliders = Physics.OverlapSphere(transform.position + offset, range);
    //     Collider[] isTriggerColliders = colliders.Where(data => data.tag == "cube").ToArray();
    //     Collider[] orderedByProximity = isTriggerColliders.OrderBy(data => (transform.position + offset - data.transform.position).sqrMagnitude).ToArray();
    //     if (orderedByProximity.Length != 0)
    //     {
    //         for (int i = 0; i < thermalSize; i++)
    //         {
    //             int j = i * 20;

    //             cubeName = orderedByProximity[j].gameObject.name;
    //             index = cubeName.Split(',');
    //             if (!int.TryParse(index[0], out x)) x = 0;
    //             if (!int.TryParse(index[1], out y)) y = 0;
    //             if (!int.TryParse(index[2], out z)) z = 0;

    //             if (sun.GetComponent<DayAndNight>().GetIsNight())
    //             {
    //                 nightAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) - 15.0f;
    //                 if (thermalSense[i] > nightAreaTemp)
    //                 {
    //                     thermalSense[i] -= Mathf.Abs(nightAreaTemp) * 0.05f * Time.deltaTime;

    //                     // 작동 확인용 코드
    //                     // Debug.Log(nightAreaTemp.ToString());
    //                     // Debug.Log((Mathf.Abs(nightAreaTemp) * 0.05f * Time.deltaTime).ToString());
    //                     // Debug.Log("NightAreaTemp : " + nightAreaTemp.ToString());
    //                     // Debug.LogFormat("AreaTemp[{0}, {1}] = {2}", x.ToString(), z.ToString(), thermalSense[i].ToString());
    //                 }
    //                 else if (thermalSense[i] < nightAreaTemp)
    //                 {
    //                     thermalSense[i] += Mathf.Abs(nightAreaTemp) * 0.05f * Time.deltaTime;

    //                     // Debug.Log(nightAreaTemp.ToString());
    //                     // Debug.Log((Mathf.Abs(nightAreaTemp) * 0.05f * Time.deltaTime).ToString());
    //                 }
    //                 else
    //                 {
    //                     thermalSense[i] = nightAreaTemp;

    //                     // Debug.Log("NightAreaTemp : " + nightAreaTemp.ToString());
    //                     // Debug.LogFormat("AreaTemp[{0}, {1}] = {2}", x.ToString(), z.ToString(), thermalSense[i].ToString());
    //                 }
    //             }
    //             else
    //             {
    //                 dayAreaTemp = area.GetComponent<AreaTempSmoothing>().GetAreaTemp(x + 50, z + 50) + 15.0f;
    //                 if (thermalSense[i] < dayAreaTemp)
    //                 {
    //                     thermalSense[i] += Mathf.Abs(dayAreaTemp) * 0.05f * Time.deltaTime;

    //                     // Debug.Log(dayAreaTemp.ToString());
    //                     // Debug.Log("DayAreaTemp : " + dayAreaTemp.ToString());
    //                     // Debug.Log((Mathf.Abs(dayAreaTemp) * 0.05f * Time.deltaTime).ToString());
    //                     // Debug.LogFormat("AreaTemp[{0}, {1}] = {2}", x.ToString(), z.ToString(), thermalSense[i].ToString());
    //                 }
    //                 else if (thermalSense[i] > dayAreaTemp)
    //                 {
    //                     thermalSense[i] -= Mathf.Abs(dayAreaTemp) * 0.05f * Time.deltaTime;

    //                     // Debug.Log(dayAreaTemp.ToString());
    //                     // Debug.Log((Mathf.Abs(dayAreaTemp) * 0.05f * Time.deltaTime).ToString());
    //                 }
    //                 else
    //                 {
    //                     thermalSense[i] = dayAreaTemp;

    //                     // Debug.Log("DayAreaTemp : " + dayAreaTemp.ToString());
    //                     // Debug.LogFormat("AreaTemp[{0}, {1}] = {2}", x.ToString(), z.ToString(), thermalSense[i].ToString());
    //                 }
    //             }
    //         }

    //         bodyTemp = thermalSense[0];

    //         // 작동 확인용
    //         // Debug.Log("BodyTemp : " + bodyTemp.ToString());
    //     }
    //     return thermalSense;
    // }

    // public float GetBodyTemp()
    // {
    //     return bodyTemp;
    // }
}
