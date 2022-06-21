using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System;


public class FoodCollectorAgent : Agent
{
    public GameObject area;
    public GameObject sun;
    // public GameObject hotzone;
    FoodCollectorArea m_MyArea;
    SceneInitialization m_SceneInitialization;
    Rigidbody m_AgentRb;
    float m_LaserLength;
    EnvironmentParameters m_ResetParams;
    DayAndNight m_sun;

    // animator
    public Animator animator;

    [Header("Movement")]
    public float moveSpeed = 6.0f;
    public float turnSpeed = 200.0f;

    public bool useOlfactoryObs;
    public float SensorLength = 0.1f;


    [Header("Resourses")]
    private int numResources = 6;
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

    // olfactory
    int olfactorySize = 10;
    float[] olfactory;

    bool isOnHotzone;
    public float lossRate = 0.002f;

    float rTt;

    //energe increase rate per action
    float raE = 0.1f;
    float raT = 0.1f;
    float raB = 0.1f;

    //energy decrease rate per action
    float rEa = -0.002f;
    float rBa = 0.002f;
    float rGE = -0.005f;
    float rOE = -0.005f;
    float rET = -0.005f;
    float rOT = -0.005f;
    float rEB = -0.005f;
    float rOB = -0.005f;

    FoodProperty[] FoodObjects;

    //초기화 작업을 위해 한번 호출되는 메소드
    public override void Initialize()
    {
        // For two resource
        this.resourceLevels = new float[this.numResources];
        olfactory = new float[olfactorySize];
        this.autoEat = false;
        isOnHotzone = false;

        m_AgentRb = GetComponent<Rigidbody>();
        m_MyArea = area.GetComponent<FoodCollectorArea>();
        m_SceneInitialization = FindObjectOfType<SceneInitialization>();
        m_ResetParams = Academy.Instance.EnvironmentParameters;
        m_sun = sun.GetComponent<DayAndNight>();
        SetResetParameters();
    }

    //에피소드(학습단위)가 시작할때마다 호출
    public override void OnEpisodeBegin()
    {
        print("New episode begin");

        isOnHotzone = false;
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

        // Reset agent
        m_AgentRb.velocity = Vector3.zero;
        transform.position = new Vector3(UnityEngine.Random.Range(-m_MyArea.range, m_MyArea.range),
            2f, UnityEngine.Random.Range(-m_MyArea.range, m_MyArea.range))
            + area.transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0f, UnityEngine.Random.Range(0, 360)));
        SetResetParameters();

        // Reset cubes
        FoodObjects = FindObjectsOfType(typeof(FoodProperty)) as FoodProperty[];
        ResetObject(FoodObjects);
    }

    //환경 정보를 관측 및 수집해 정책 결정을 위해 브레인에 전달하는 메소드
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(resourceLevels);
        if (useOlfactoryObs)
        {
            sensor.AddObservation(olfactory);
        }
    }
    void EnergyFallingPerStep()
    {
        // calculate rate of temperature loss with sun angle
        float sunAngle = m_sun.GetSunAngle();
        if (sunAngle >= 0 && sunAngle <= 90)
        {
            rTt = sunAngle + 92;
        }
        else if (sunAngle >= 270 && sunAngle <= 360)
        {
            rTt = sunAngle - 269;
        }
        rTt = 183 - rTt;

        // isOnHotzone = m_hotzone.IsAgentOnHotzone();
        this.resourceLevels[0] -= lossRateBlue; // O
        this.resourceLevels[1] -= lossRateRed; // G
        this.resourceLevels[2] -= lossRate; // B
        this.resourceLevels[3] -= lossRate * (1 + rTt / 182); // T
        this.resourceLevels[4] -= lossRate; // E
        this.resourceLevels[5] = 0;

        for (int i = 0; i < numResources - 1; i++)
        {
            this.resourceLevels[5] += this.resourceLevels[i];
        }
        this.resourceLevels[5] = this.resourceLevels[5] / (numResources - 1);
    }
    //브레인(정책)으로 부터 전달 받은 행동을 실행하는 메소드
    public override void OnActionReceived(ActionBuffers actions)
    {
        EnergyFallingPerStep();
        // this.resourceLevels[0] -= this.lossRateRed * Time.fixedDeltaTime;
        // this.resourceLevels[1] -= this.lossRateBlue * Time.fixedDeltaTime;

        float maxDeviation = Mathf.Max(Mathf.Abs(resourceLevels[2]), Mathf.Abs(resourceLevels[3]), Mathf.Abs(resourceLevels[4]), Mathf.Abs(resourceLevels[5]));
        if ((this.maxEnergyLevelBlue < this.resourceLevels[0] || this.resourceLevels[0] < this.minEnergyLevelBlue)
        || (this.maxEnergyLevelRed < this.resourceLevels[1] || this.resourceLevels[1] < this.minEnergyLevelRed)
        || (maxDeviation > 15.0f))
            EndEpisode();

        PropertyObserving();
        string olf = "Olfactory: ";
        for (int i = 0; i < olfactorySize; i++)
        {
            olf += olfactory[i];
            olf += ", ";
        }
        // if (useOlfactoryObs) { Debug.Log(olf); }
        MoveAgent(actions);
    }

    //개발자(사용자)가 직접 명령을 내릴때 호출하는 메소드(주로 테스트용도 또는 모방학습에 사용)
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            discreteActionsOut[0] = 1;
            Debug.Log("Forward!");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            discreteActionsOut[0] = 2;
            Debug.Log("Left!");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            discreteActionsOut[0] = 3;
            Debug.Log("Right!");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            discreteActionsOut[0] = 4;
            Debug.Log("Eat!");
        }
        if (Input.GetKey(KeyCode.A))
        {
            discreteActionsOut[0] = 5;
            Debug.Log("Increase E!");
        }
        if (Input.GetKey(KeyCode.S))
        {
            discreteActionsOut[0] = 6;
            Debug.Log("Increase T!");
        }
        if (Input.GetKey(KeyCode.D))
        {
            discreteActionsOut[0] = 7;
            Debug.Log("Increase B!");
        }

    }

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
                food.transform.position = new Vector3(UnityEngine.Random.Range(-m_MyArea.range, m_MyArea.range),
                    m_MyArea.height, UnityEngine.Random.Range(-m_MyArea.range, m_MyArea.range)) + m_MyArea.transform.position;
                food.InitializeProperties();
            }
        }
    }

    public void MoveAgent(ActionBuffers actions)
    {
        var dirToGo = Vector3.zero;
        var rotateDir = Vector3.zero;

        // Get the action index for movement
        int action = Mathf.FloorToInt(actions.DiscreteActions[0]);
        /*** Action Category
         * 0 : None 
         * 1 : Forward  
         * 2 : Left
         * 3 : Right
         * 4 : Eat
         * 5 : Increase energy(green) & decrease gluco(red) & decrease osmo(blue)
         * 6 : Increase Thermo(yellow) & decrease energy(green) & decrease osmo(blue)
         * 7 : Increase Baro(orange) & decrease energy(green) & decrease osmo(blue)
         * ***/

        this.isEat = false;
        animator.SetBool("Walk", false);
        switch (action)
        {
            case 0:
                break;
            case 1:
                animator.SetBool("Walk", true);
                dirToGo = transform.forward;
                m_AgentRb.velocity = dirToGo * moveSpeed;
                this.resourceLevels[4] += rEa;
                Debug.Log("Forward!");
                break;
            case 2:
                animator.SetBool("Walk", true);
                transform.Rotate(-transform.up, Time.fixedDeltaTime * turnSpeed);
                this.resourceLevels[4] += rEa;
                this.resourceLevels[2] += rBa;
                Debug.Log("Left!");
                break;
            case 3:
                animator.SetBool("Walk", true);
                transform.Rotate(transform.up, Time.fixedDeltaTime * turnSpeed);
                this.resourceLevels[4] += rEa;
                this.resourceLevels[2] += rBa;
                Debug.Log("Right!");
                break;
            case 4:
                this.isEat = true;
                this.resourceLevels[4] += rEa;
                this.resourceLevels[2] += rBa;
                Debug.Log("Eat!");
                break;
            case 5:
                this.resourceLevels[4] += raE; // increse E
                this.resourceLevels[1] += rGE; // decrease G
                this.resourceLevels[0] += rOE; // decrease O
                Debug.Log("Increase E!");
                break;
            case 6:
                this.resourceLevels[3] += raT; // increase T
                this.resourceLevels[4] += rET; // decrease E
                this.resourceLevels[0] += rOT; // decrease O
                Debug.Log("Increase T!");
                break;
            case 7:
                this.resourceLevels[2] += raB; // increase B
                this.resourceLevels[4] += rEB; // decrease E
                this.resourceLevels[0] += rOB; // decrease O
                Debug.Log("Increase B!");
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


        m_LaserLength = m_ResetParams.GetWithDefault("laser_length", 1.0f);
    }

    public void IncreaseLevel(string tag)
    {
        if (tag == "food_blue")
        {
            this.resourceLevels[0] += this.resourceEnergyBlue;
        }
        if (tag == "food_red")
        {
            this.resourceLevels[1] += this.resourceEnergyRed;
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
}
