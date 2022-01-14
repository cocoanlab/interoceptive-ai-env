using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class FoodCollectorAgent : Agent
{
    public GameObject area;
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


    [Header("Resourses")]
    private int numResources = 2;
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

    FoodProperty[] FoodObjects;

    //초기화 작업을 위해 한번 호출되는 메소드
    public override void Initialize()
    {
        // For two resource
        this.resourceLevels = new float[this.numResources];
        olfactory = new float[olfactorySize];
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

        // Reset agent
        m_AgentRb.velocity = Vector3.zero;
        transform.position = new Vector3(0, 2f, 0f) + area.transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360)));
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

    //브레인(정책)으로 부터 전달 받은 행동을 실행하는 메소드
    public override void OnActionReceived(float[] vectorAction)
    {
        this.resourceLevels[0] -= this.lossRateRed * Time.fixedDeltaTime;
        this.resourceLevels[1] -= this.lossRateBlue * Time.fixedDeltaTime;

        if ((this.maxEnergyLevelRed < this.resourceLevels[0] || this.resourceLevels[0] < this.minEnergyLevelRed)
        || (this.maxEnergyLevelBlue < this.resourceLevels[1] || this.resourceLevels[1] < this.minEnergyLevelBlue))
            EndEpisode();

        PropertyObserving();
        string olf = "Olfactory: ";
        for (int i = 0; i < olfactorySize; i++)
        {
            olf += olfactory[i];
            olf += ", ";
        }
        if (useOlfactoryObs) { Debug.Log(olf); }
        MoveAgent(vectorAction);
    }

    //개발자(사용자)가 직접 명령을 내릴때 호출하는 메소드(주로 테스트용도 또는 모방학습에 사용)
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            actionsOut[0] = 1f;
            Debug.Log("Forward!");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            actionsOut[0] = 2f;
            Debug.Log("Left!");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            actionsOut[0] = 3f;
            Debug.Log("Right!");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            actionsOut[0] = 4f;
            Debug.Log("Eat!");
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

            // 특정 지역에 큐브 뿌리ㄱ
            if (food_x > (-m_MyArea.range + area_x) && food_x < (m_MyArea.range + area_x)
                && food_y > area_y && food_y < m_MyArea.height + area_y
                && food_z > (-m_MyArea.range + area_z) && food_z < (m_MyArea.range + area_z) && food.CompareTag("food_blue"))
            {
                food.transform.position = new Vector3(Random.Range(-m_MyArea.range, -5),
                    m_MyArea.height, Random.Range(20, m_MyArea.range)) + m_MyArea.transform.position;
                food.InitializeProperties();
            }

            else if (food_x > (-m_MyArea.range + area_x) && food_x < (m_MyArea.range + area_x)
                && food_y > area_y && food_y < m_MyArea.height + area_y
                && food_z > (-m_MyArea.range + area_z) && food_z < (m_MyArea.range + area_z) && food.CompareTag("food_red"))
            {
                food.transform.position = new Vector3(Random.Range(5, m_MyArea.range),
                    m_MyArea.height, Random.Range(20, m_MyArea.range)) + m_MyArea.transform.position;
                food.InitializeProperties();
            }

        }
    }

    public void MoveAgent(float[] act)
    {
        var dirToGo = Vector3.zero;
        var rotateDir = Vector3.zero;

        // Get the action index for movement
        int action = Mathf.FloorToInt(act[0]);
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
