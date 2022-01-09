using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class ForagerAgent : Agent
{

    [Header("Movement")]
    public float moveSpeed = 5.0f;
    public float turnSpeed = 200.0f;
    private float fallSpeed;
    private CharacterController character;

    [Header("Resource")]
    public int numResources = 2;
    private float[] resourceLevel;
    public float objInitialHeight = 3.0f;
    public float objInitialRange = 60.0f;
    public bool autoEat = false;
    public bool IsAutoEat { get { return this.autoEat; } }
    private bool isEat = false;
    public bool IsEat { get { return this.isEat; } set { this.isEat = value; } }

    // red
    public GameObject resourceRed;
    private GameObject[] resourcesRed;
    public int numResourceRed = 200;
    public float maxEnergyLevelRed = 15.0f;
    public float minEnergyLevelRed = -15.0f;
    public float resourceEnergyRed = 3.0f;

    public float lossRateRed = 0.004f;

    // blue
    public GameObject resourceBlue;
    private GameObject[] resourcesBlue;
    public int numResourceBlue = 200;
    public float maxEnergyLevelBlue = 15.0f;
    public float minEnergyLevelBlue = -15.0f;
    public float lossRateBlue = 0.004f;
    public float resourceEnergyBlue = 3.0f;

    [Header("Obstacle")]
    public GameObject treeObj;
    private GameObject[] treeObjs;
    private int numTrees = 100;
    // Monitor
    [DebugGUIPrint, DebugGUIGraph(max: 15f, min: -15f, group: 1, r: 1, g: 0.4f, b: 0.4f)]
    float energyLevelRed;

    [DebugGUIPrint, DebugGUIGraph(max: 15f, min: -15f, group: 1, r: 0.4f, g: 0.4f, b: 1)]
    float energyLevelBlue;

    public override void Initialize()
    {
        //Setting Variables from Python (ml-agents support this)
        var envParameters = Academy.Instance.EnvironmentParameters;
        moveSpeed = envParameters.GetWithDefault("move_speed", moveSpeed);
        turnSpeed = envParameters.GetWithDefault("turn_speed", turnSpeed);
        autoEat = System.Convert.ToBoolean(envParameters.GetWithDefault("auto_eat", 0));

        numResourceRed = (int)envParameters.GetWithDefault("num_resource_red", numResourceRed);
        maxEnergyLevelRed = envParameters.GetWithDefault("max_energy_level_red", maxEnergyLevelRed);
        minEnergyLevelRed = envParameters.GetWithDefault("min_energy_level_red", minEnergyLevelRed);
        resourceEnergyRed = envParameters.GetWithDefault("resource_energy_red", resourceEnergyRed);
        lossRateRed = envParameters.GetWithDefault("loss_rate_red", lossRateRed);

        numResourceBlue = (int)envParameters.GetWithDefault("num_resource_blue", numResourceBlue);
        maxEnergyLevelBlue = envParameters.GetWithDefault("max_energy_level_blue", maxEnergyLevelBlue);
        minEnergyLevelBlue = envParameters.GetWithDefault("min_energy_level_blue", minEnergyLevelBlue);
        resourceEnergyBlue = envParameters.GetWithDefault("resource_energy_blue", resourceEnergyBlue);
        lossRateBlue = envParameters.GetWithDefault("loss_rate_blue", lossRateBlue);

        Debug.Log("Initializing");
    }

    private void Awake()
    {
        Physics.autoSimulation = false;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = (int)(60.0 * Time.timeScale);
    }

    private void OnDestroy()
    {
        Physics.autoSimulation = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        print("Start");
        this.resourceLevel = new float[this.numResources];
        this.character = gameObject.GetComponent<CharacterController>();

        // Generate Red Objects
        this.resourcesRed = new GameObject[this.numResourceRed];
        for (int i = 0; i < this.numResourceRed; i++)
        {
            GameObject obj = Instantiate(resourceRed) as GameObject;
            resourcesRed[i] = obj;
            resourcesRed[i].transform.position = GetPos();
            resourcesRed[i].transform.Rotate(0, Random.Range(0f, 90.0f), 0);
            resourcesRed[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        // Generate Blue Objects
        this.resourcesBlue = new GameObject[this.numResourceBlue];
        for (int i = 0; i < this.numResourceBlue; i++)
        {
            GameObject obj = Instantiate(resourceBlue) as GameObject;
            resourcesBlue[i] = obj;
            resourcesBlue[i].transform.position = GetPos();
            resourcesBlue[i].transform.Rotate(0, Random.Range(0f, 90.0f), 0);
            resourcesBlue[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        // Generate Tree Objects
        this.treeObjs = new GameObject[this.numTrees];
        for (int i = 0; i < this.numTrees; i++)
        {
            GameObject obj = Instantiate(treeObj) as GameObject;
            treeObjs[i] = obj;
            treeObjs[i].transform.position = GetPos();
        }

    }

    public Vector3 GetPos()
    {
        return new Vector3(Random.Range(-this.objInitialRange, this.objInitialRange),
                        this.objInitialHeight,
                        Random.Range(-this.objInitialRange, this.objInitialRange));
    }

    public Vector3 GetPos(float offset_y)
    {
        return new Vector3(Random.Range(-this.objInitialRange, this.objInitialRange),
                        this.objInitialHeight + offset_y,
                        Random.Range(-this.objInitialRange, this.objInitialRange));
    }

    public override void OnEpisodeBegin()
    {
        print("New episode begin");

        for (int i = 0; i < this.numResources; i++)
        {
            this.resourceLevel[i] = 0;
        }

        // Randomize agent position
        this.transform.position = new Vector3(0, 2.58f, 0);
        this.transform.Rotate(0, Random.Range(0f, 360.0f), 0);

        // Randomize object positions
        for (int i = 0; i < this.numResourceRed; i++)
        {
            Vector3 pos = GetPos();
            resourcesRed[i].transform.position = pos;
            resourcesRed[i].transform.Rotate(0, Random.Range(0f, 90.0f), 0);
            resourcesRed[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        for (int i = 0; i < this.numResourceBlue; i++)
        {
            Vector3 pos = GetPos();
            resourcesBlue[i].transform.position = pos;
            resourcesBlue[i].transform.Rotate(0, Random.Range(0f, 90.0f), 0);
            resourcesBlue[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        for (int i = 0; i < this.numTrees; i++)
        {
            Vector3 pos = GetPos(-1.0f);
            treeObjs[i].transform.position = pos;
            treeObjs[i].transform.Rotate(0, Random.Range(0f, 360.0f), 0);
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(resourceLevel);
    }


    public void Update()
    {
        if (this.StepCount % 5 == 0)
        {
            RequestDecision();
        }
        else
        {
            RequestAction();
        }

        if (!this.character.isGrounded)
        {
            this.fallSpeed -= 9.81f * Time.fixedDeltaTime;
            this.character.Move(new Vector3(0, -9.81f * Time.fixedDeltaTime));
        }
        else
        {
            this.fallSpeed = 0;
        }

        this.resourceLevel[0] -= this.lossRateRed * Time.fixedDeltaTime;
        this.resourceLevel[1] -= this.lossRateBlue * Time.fixedDeltaTime;

        Monitor.Log("Red", this.resourceLevel[0] / 15f, transform);
        energyLevelRed = this.resourceLevel[0];
        Monitor.Log("Blue", this.resourceLevel[1] / 15f, transform);
        energyLevelBlue = this.resourceLevel[1];

        Physics.Simulate(Time.fixedDeltaTime);
        Application.targetFrameRate = (int)(60.0 * Time.timeScale);
    }


    public override void OnActionReceived(float[] vectorAction)
    {
        // Get the action index for movement
        int action = Mathf.FloorToInt(vectorAction[0]);
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
                Vector3 forward = transform.transform.forward;
                this.character.Move(this.moveSpeed * forward * Time.deltaTime);
                break;
            case 2:
                this.transform.Rotate(0, -this.turnSpeed * Time.deltaTime, 0);
                break;
            case 3:
                this.transform.Rotate(0, this.turnSpeed * Time.deltaTime, 0);
                break;
            case 4:
                this.isEat = true;
                break;
        }

        // Set zero reward (reward will be defined in the learning-side)
        SetReward(0.0f);
        if ((this.maxEnergyLevelRed < this.resourceLevel[0] || this.resourceLevel[0] < this.minEnergyLevelRed)
        || (this.maxEnergyLevelBlue < this.resourceLevel[1] || this.resourceLevel[1] < this.minEnergyLevelBlue))
            EndEpisode();

    }

    public override void Heuristic(float[] actionsOut)
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            actionsOut[0] = 1f;
            print("forward");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            actionsOut[0] = 2f;
            print("left");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            actionsOut[0] = 3f;
            print("right");
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            actionsOut[0] = 4f;
            print("eat");
        }
        else
        {
            actionsOut[0] = 0f;
        }
    }

    public void IncreaseLevel(string tag)
    {
        if (tag == "food_red")
        {
            this.resourceLevel[0] += this.resourceEnergyRed;
        }
        if (tag == "food_blue")
        {
            this.resourceLevel[1] += this.resourceEnergyBlue;
        }
    }
}
