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
    private Field m_MyArea;
    private SceneInitialization m_SceneInitialization;
    private EnvironmentParameters m_ResetParams;
    private ResourceProperty[] FoodObjects;
    private Rigidbody m_AgentRb;
    private bool isAgentActionEat = false;
    public bool IsAgentActionEat { get { return this.isAgentActionEat; } set { this.isAgentActionEat = value; } }
    private float bodyTemp;


    [Header("Game Ojects for script")]
    public GameObject area;
    public GameObject sun;
    public GameObject heatMap;
    // public int seed = 8217;

    [Header("Actions")]
    public float moveSpeed = 6.0f;
    public float turnSpeed = 200.0f;
    public float eatingDistance = 1.0f;
    public bool autoEat = false;
    // public bool IsAutoEat { get { return this.autoEat; } set { this.autoEat = value; } }

    [Header("Observations")]
    public bool useOlfactoryObs;
    public float olfactorySensorLength = 100f;
    public int olfactoryFeatureSize = 10;
    public float[] olfactoryObservation;
    public bool useThermalObs;
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

    [Header("Essential variables (EV)")]
    public int countEV = 3;
    public float[] resourceLevels;
    // public float[] ResourceLevels { get { return resourceLevels; } set { resourceLevels = value; } }

    // red
    [Header("Food")]
    public float maxFoodLevel = 15.0f;
    public float minFoodLevel = -15.0f;
    public float changeFoodLevelRate = 0.002f;
    public float resourceFoodValue = 3.0f;
    private float priorFood = 0.0f;
    private float posteriorFood = 0.0f;
    private float dFood = 0.0f;

    // blue
    [Header("Water")]
    public float maxWaterLevel = 15.0f;
    public float minWaterLevel = -15.0f;
    public float changeWaterLevelRate = 0.002f;
    public float resourceWaterValue = 3.0f;
    private float priorWater = 0.0f;
    private float posteriorWater = 0.0f;
    private float dWater = 0.0f;

    // yellow
    [Header("Temperature")]
    public float maxThermoLevel = 15.0f;
    public float minThermoLevel = -15.0f;
    public float changeThermoLevelRate = 0.005f;
    public int thermoSensorChangeRate = 10;
    private float priorBodyTemp = 0.0f;
    private float posteriorBodyTemp = 0.0f;
    private float dBodyTemp = 0.0f;

    [Header("Merterials")]
    public Material agentMerterial;
    public Material redMaterial;
    public Material blueMaterial;

    // Interaction Coefficient
    public float food0 = 0.1f;
    public float water0 = 0.0f;
    public float bodyTemp0 = -1.7f;
    public float food1 = 0.0f;
    public float water1 = 0.1f;
    public float bodyTemp1 = -2000.0f;
    public float food2 = 0.3f;
    public float water2 = 0.3f;
    public float bodyTemp2 = 0.1f;

    // [Header("Predator / Prey")]
    // public GameObject Pig;
    // Rigidbody m_pig;
    //초기화 작업을 위해 한번 호출되는 메소드
    public void SetResetParameters()
    {
        moveSpeed = m_ResetParams.GetWithDefault("moveSpeed", moveSpeed);
        turnSpeed = m_ResetParams.GetWithDefault("turnSpeed", turnSpeed);
        autoEat = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("autoEat", 0));
        eatingDistance = m_ResetParams.GetWithDefault("eatingDistance", eatingDistance);

        countEV = System.Convert.ToInt32(m_ResetParams.GetWithDefault("countEV", countEV));

        maxFoodLevel = m_ResetParams.GetWithDefault("maxFoodLevel", maxFoodLevel);
        minFoodLevel = m_ResetParams.GetWithDefault("minFoodLevel", minFoodLevel);
        resourceFoodValue = m_ResetParams.GetWithDefault("resourceFoodValue", resourceFoodValue);
        changeFoodLevelRate = m_ResetParams.GetWithDefault("changeFoodLevelRate", changeFoodLevelRate);

        maxWaterLevel = m_ResetParams.GetWithDefault("maxWaterLevel", maxWaterLevel);
        minWaterLevel = m_ResetParams.GetWithDefault("minWaterLevel", minWaterLevel);
        resourceWaterValue = m_ResetParams.GetWithDefault("resourceWaterValue", resourceWaterValue);
        changeWaterLevelRate = m_ResetParams.GetWithDefault("changeWaterLevelRate", changeWaterLevelRate);

        useOlfactoryObs = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("useOlfactoryObs", 1));
        olfactorySensorLength = m_ResetParams.GetWithDefault("olfactorySensorLength", olfactorySensorLength);

        useThermalObs = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("useThermalObs", 1));
        maxThermoLevel = m_ResetParams.GetWithDefault("maxThermoLevel", maxThermoLevel);
        minThermoLevel = m_ResetParams.GetWithDefault("minThermoLevel", minThermoLevel);
        changeThermoLevelRate = m_ResetParams.GetWithDefault("changeThermoLevelRate", changeThermoLevelRate);
        thermoSensorChangeRate = (int)m_ResetParams.GetWithDefault("thermoSensorChangeRate", thermoSensorChangeRate);

        food0 = m_ResetParams.GetWithDefault("food0", food0);
        water0 = m_ResetParams.GetWithDefault("water0", water0);
        bodyTemp0 = m_ResetParams.GetWithDefault("bodyTemp0", bodyTemp0);
        food1 = m_ResetParams.GetWithDefault("food1", food1);
        water1 = m_ResetParams.GetWithDefault("water1", water1);
        bodyTemp1 = m_ResetParams.GetWithDefault("bodyTemp1", bodyTemp1);
        food2 = m_ResetParams.GetWithDefault("food2", food2);
        water2 = m_ResetParams.GetWithDefault("water2", water2);
        bodyTemp2 = m_ResetParams.GetWithDefault("bodyTemp2", bodyTemp2);
    }
    public override void Initialize()
    {
        m_ResetParams = Academy.Instance.EnvironmentParameters;
        SetResetParameters();

        m_AgentRb = GetComponent<Rigidbody>();
        m_MyArea = area.GetComponent<Field>();
        m_SceneInitialization = FindObjectOfType<SceneInitialization>();

        this.resourceLevels = new float[this.countEV];

        if (this.useOlfactoryObs)
        {
            this.olfactoryObservation = new float[this.olfactoryFeatureSize];
        }

        if (this.useThermalObs)
        {
            this.thermoObservation = new float[8];
        }

        // m_pig = GetComponent<Rigidbody>();
    }

    //에피소드(학습단위)가 시작할때마다 호출
    public override void OnEpisodeBegin()
    {
        print("New episode begin");

        // Reset agent
        m_AgentRb.velocity = Vector3.zero;
        transform.position = new Vector3(Random.Range(-m_MyArea.range, m_MyArea.range), 2f, Random.Range(-m_MyArea.range, m_MyArea.range)) + area.transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360)));
        SetResetParameters();

        // Reset cubes
        FoodObjects = FindObjectsOfType(typeof(ResourceProperty)) as ResourceProperty[];
        ResetObject(FoodObjects);

        // Reset DayAndNight (지금은 DayAndNight가 에피소드 시작할 때 초기화되지 않는데 필요하면 추가)

        // Reset energy
        for (int i = 0; i < this.countEV; i++)
        {
            this.resourceLevels[i] = 0;
        }

        // Reset olfactory
        if (this.useOlfactoryObs)
        {
            for (int i = 0; i < olfactoryFeatureSize; i++)
            {
                this.olfactoryObservation[i] = 0;
            }
        }

        // Reset prior, posterior, derivative of EV
        priorFood = 0.0f;
        posteriorFood = 0.0f;
        dFood = 0.0f;

        priorWater = 0.0f;
        posteriorWater = 0.0f;
        dWater = 0.0f;

        priorBodyTemp = 0.0f;
        posteriorBodyTemp = 0.0f;
        dBodyTemp = 0.0f;

        if (this.useThermalObs)
        {
            for (int i = 0; i < 8; i++)
            {
                this.thermoObservation[i] = 0;
            }

            bodyTemp = 0;

            thermoSensorCenter.GetComponent<ThermalSensing>().SetThermalSense(0);
            thermoSensorForward.GetComponent<ThermalSensing>().SetThermalSense(0);
            thermoSensorBackward.GetComponent<ThermalSensing>().SetThermalSense(0);
            thermoSensorLeft.GetComponent<ThermalSensing>().SetThermalSense(0);
            thermoSensorRight.GetComponent<ThermalSensing>().SetThermalSense(0);
            thermoSensorForwardLeft.GetComponent<ThermalSensing>().SetThermalSense(0);
            thermoSensorForwardRight.GetComponent<ThermalSensing>().SetThermalSense(0);
            thermoSensorBackwardLeft.GetComponent<ThermalSensing>().SetThermalSense(0);
            thermoSensorBackwardRight.GetComponent<ThermalSensing>().SetThermalSense(0);
        }

        if (useThermalObs)
        {
            // Reset area
            area.GetComponent<AreaTempSmoothing>().EpisodeAreaSmoothing();

            // Reset heatmap
            heatMap.GetComponent<HeatMap>().EpisodeHeatMap();
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
            sensor.AddObservation(olfactoryObservation);
        }
        if (useThermalObs)
        {
            sensor.AddObservation(thermoObservation);
        }
    }

    //브레인(정책)으로 부터 전달 받은 행동을 실행하는 메소드
    public override void OnActionReceived(ActionBuffers actions)
    {
        dFood = posteriorFood - priorFood;
        dWater = posteriorWater - priorWater;
        dBodyTemp = posteriorBodyTemp - priorBodyTemp;
        Debug.Log("dFood : " + dFood.ToString());
        Debug.Log("dWater : " + dWater.ToString());
        Debug.Log("dBodyTemp : " + dBodyTemp.ToString());

        priorFood = resourceLevels[0];
        priorWater = resourceLevels[1];
        priorBodyTemp = resourceLevels[2];

        this.resourceLevels[0] = this.resourceLevels[0] - this.changeFoodLevelRate * Time.fixedDeltaTime + food0 * dFood + water0 * dWater + bodyTemp0 * dBodyTemp;
        this.resourceLevels[1] = this.resourceLevels[1] - this.changeWaterLevelRate * Time.fixedDeltaTime + food1 * dFood + water1 * dWater + bodyTemp1 * dBodyTemp;
        if (this.useThermalObs)
        {
            thermoSensorCenter.GetComponent<ThermalSensing>().SetThermalSense(bodyTemp + food2 * dFood + water2 * dWater + bodyTemp2 * dBodyTemp);
            this.resourceLevels[2] = this.bodyTemp;
        }

        bool checkFoodLevel = (this.maxFoodLevel < this.resourceLevels[0] || this.resourceLevels[0] < this.minFoodLevel);
        bool checkWaterLevel = (this.maxWaterLevel < this.resourceLevels[1] || this.resourceLevels[1] < this.minWaterLevel);

        bool checkThermoLevel = false;
        if (this.useThermalObs)
        {
            checkThermoLevel = (this.maxThermoLevel < this.bodyTemp || this.bodyTemp < this.minThermoLevel);
        }

        if (checkFoodLevel || checkWaterLevel || checkThermoLevel)
            EndEpisode();

        if (this.useOlfactoryObs)
        {
            OlfactoryObserving();
        }

        if (this.useThermalObs)
        {
            ThermalChanging();
            ThermalObserving();

        }
        int action = actions.DiscreteActions[0];
        MoveAgent(action);

        posteriorFood = resourceLevels[0];
        posteriorWater = resourceLevels[1];
        posteriorBodyTemp = resourceLevels[2];
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

    //
    public void ResetObject(ResourceProperty[] objects)
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

        this.isAgentActionEat = false;
        switch (action)
        {
            case 0:
                break;
            case 1:
                dirToGo = transform.forward;
                m_AgentRb.velocity = dirToGo * moveSpeed;
                break;
            case 2:
                transform.Rotate(-transform.up, Time.fixedDeltaTime * turnSpeed);
                break;
            case 3:
                transform.Rotate(transform.up, Time.fixedDeltaTime * turnSpeed);
                break;
            case 4:
                this.isAgentActionEat = true;
                break;
        }
    }


    public void IncreaseLevel(string tag)
    {
        if (tag.ToLower() == "food")
        {
            this.resourceLevels[0] += this.resourceFoodValue;
            posteriorFood = resourceLevels[0];
        }
        if (tag.ToLower() == "water")
        {
            this.resourceLevels[1] += this.resourceWaterValue;
            posteriorWater = resourceLevels[1];
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
        // Food layer
        Collider[] olfactoryTargets = Physics.OverlapSphere(SpherePos, olfactorySensorLength, 1 << 8);

        int j = 0;
        foreach (Collider other in olfactoryTargets)
        {
            ResourceProperty food = other.gameObject.GetComponent<ResourceProperty>();
            if (food.CompareTag("water") || food.CompareTag("food"))
            {
                j += 1;
                float foodDistance = Vector3.Distance(SpherePos, food.transform.position);
                for (int i = 0; i < olfactoryFeatureSize; i++)
                {
                    olfactoryObservation[i] += food.ResourceP[i] * (1 / foodDistance);
                }
            }
        }
    }

    public void ThermalChanging()
    {
        thermoSensorForward.GetComponent<ThermalSensing>().CalculateThermalSense();
        thermoSensorBackward.GetComponent<ThermalSensing>().CalculateThermalSense();
        thermoSensorLeft.GetComponent<ThermalSensing>().CalculateThermalSense();
        thermoSensorRight.GetComponent<ThermalSensing>().CalculateThermalSense();
        thermoSensorForwardLeft.GetComponent<ThermalSensing>().CalculateThermalSense();
        thermoSensorForwardRight.GetComponent<ThermalSensing>().CalculateThermalSense();
        thermoSensorBackwardLeft.GetComponent<ThermalSensing>().CalculateThermalSense();
        thermoSensorBackwardRight.GetComponent<ThermalSensing>().CalculateThermalSense();
        thermoSensorCenter.GetComponent<ThermalSensing>().CalculateThermalSense();
    }

    public float[] ThermalObserving()
    {
        thermoObservation[0] = thermoSensorForward.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermoObservation[1] = thermoSensorBackward.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermoObservation[2] = thermoSensorLeft.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermoObservation[3] = thermoSensorRight.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermoObservation[4] = thermoSensorForwardLeft.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermoObservation[5] = thermoSensorForwardRight.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermoObservation[6] = thermoSensorBackwardLeft.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        thermoObservation[7] = thermoSensorBackwardRight.GetComponent<ThermalSensing>().GetThermalSense() - thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();
        bodyTemp = thermoSensorCenter.GetComponent<ThermalSensing>().GetThermalSense();

        return thermoObservation;
    }

}
