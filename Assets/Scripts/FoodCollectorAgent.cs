using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class FoodCollectorAgent : Agent
{
    public GameObject area;
    FoodCollectorArea m_MyArea;
    FoodCollectorSettings m_FoodCollecterSettings;
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
    private GameObject[] reds;
    public float maxEnergyLevelRed = 15.0f;
    public float minEnergyLevelRed = -15.0f;
    public float lossRateRed = 0.002f;
    public float resourceEnergyRed = 3.0f;
    public int numResourceRed = 30;

    // blue
    [Header("Blue")]
    private GameObject[] blues;
    public float maxEnergyLevelBlue = 15.0f;
    public float minEnergyLevelBlue = -15.0f;
    public float lossRateBlue = 0.002f;
    public float resourceEnergyBlue = 3.0f;
    public int numResourceBlue = 30;


    //초기화 작업을 위해 한번 호출되는 메소드
    public override void Initialize()
    {
        // For two resource
        this.resourceLevels = new float[this.numResources];
        this.autoEat = false;

        m_AgentRb = GetComponent<Rigidbody>();
        m_MyArea = area.GetComponent<FoodCollectorArea>();
        m_FoodCollecterSettings = FindObjectOfType<FoodCollectorSettings>();
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

        // Reset agent
        m_AgentRb.velocity = Vector3.zero;
        transform.position = new Vector3(Random.Range(-m_MyArea.range, m_MyArea.range),
            2f, Random.Range(-m_MyArea.range, m_MyArea.range))
            + area.transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360)));
        SetResetParameters();

        // Reset cubes
        ResetObject(GameObject.FindGameObjectsWithTag("food_blue"));
        ResetObject(GameObject.FindGameObjectsWithTag("food_red"));
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(resourceLevels);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        this.resourceLevels[0] -= this.lossRateRed * Time.fixedDeltaTime;
        this.resourceLevels[1] -= this.lossRateBlue * Time.fixedDeltaTime;

        Debug.Log("0: " + resourceLevels[0] + ", 1: " + resourceLevels[1]);

        if ((this.maxEnergyLevelRed < this.resourceLevels[0] || this.resourceLevels[0] < this.minEnergyLevelRed)
        || (this.maxEnergyLevelBlue < this.resourceLevels[1] || this.resourceLevels[1] < this.minEnergyLevelBlue))
            EndEpisode();
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

    //
    public void ResetObject(GameObject[] objects)
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
        if (tag == "food_red")
        {
            this.resourceLevels[0] += this.resourceEnergyRed;
        }
        if (tag == "food_blue")
        {
            this.resourceLevels[1] += this.resourceEnergyBlue;
        }
    }
}
