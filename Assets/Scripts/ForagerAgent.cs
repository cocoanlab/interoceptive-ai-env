using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
// using TMPro;

public class ForagerAgent : Agent
{
    // [Header("Energy Text Setting")]
    // public TMP_Text foodLevel;
    // public TMP_Text waterLevel;

    [Header("Status")]
    public float maxHunger = 15.0f;
    public float minHunger = -15.0f;
    public float hungerFallRate = 0.2f;
    public float maxThirst = 15.0f;
    public float minThirst = -15.0f;
    public float thirstFallRate = 0.2f;
    private float hungerLevel;
    private float thirstLevel;
    //
    public int numResources = 2;
    public float resourceDecreaseRate = 0.2f;  // [unit/sec]
    public float resourceLimit = 15.0f; // Episode Terminate if the agent exceed this limit
    private float[] resourceLevel;

    [Header("Movement")] 
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 200.0f;
    private float descentVelocity;
    private CharacterController character;

    [Header("Resource")]
    public GameObject hungerResourceObj;
    public GameObject thirstResourceObj;
    private GameObject[] hungerResourceObjs;
    private GameObject[] thirstResourceObjs;
    public int numHungerResourceObj = 200;
    public int numThirstResourceObj = 200;
    public float hungerResourceIncrease = 3.0f;
    public float thirstResourceIncrease = 3.0f;
    public float objInitialHeight= 3.0f;
    public float objInitialRange = 60.0f;
    public bool manualEatBehavior = true;
    // public int numCubes;

    [Header("Obstacle")]
    public GameObject treeObj;
    private GameObject[] treeObjs;
    private int numTrees = 100;

    // Monitor
    [DebugGUIPrint, DebugGUIGraph(max: 15f, min: -15f, group: 1, r: 1, g: 0.4f, b: 0.4f)]
    float resourceRed;
    [DebugGUIPrint, DebugGUIGraph(max: 15f, min: -15f, group: 1, r: 0.4f, g: 0.4f, b: 1)]
    float resourceBlue;

    public override void Initialize()
    {
        // base.Initialize();

        //Initialize Agent Position
        // InitializeAgentPosition();

        //Initialize cubes
        // for (int i = 0; i < numCubes; i++)
        // {
        //     survivalAgent.GetComponent<ItemGeneration>().InitializeItem("Food", cubes);
        //     survivalAgent.GetComponent<ItemGeneration>().InitializeItem("Water", cubes);
        // }

        //Initialize Energy Level
        thirstLevel = 0;
        hungerLevel = 0;

        //Setting Variables from Python (ml-agents support this)
        var envParameters = Academy.Instance.EnvironmentParameters;
        // float MAX_STEP = envParameters.GetWithDefault("MAX_STEP", 10000.0f);
        float MAX_HUNGER = envParameters.GetWithDefault("MAX_HUNGER", 15.0f);
        float MIN_HUNGER = envParameters.GetWithDefault("MIN_HUNGER", -15.0f);
        float HUNGER_FALL_RATE = envParameters.GetWithDefault("HUNGER_FALL_RATE", 0.2f);
        float MAX_THIRST = envParameters.GetWithDefault("MAX_THIRST", 15.0f);
        float MIN_THIRST = envParameters.GetWithDefault("MIN_THIRST", -15.0f);
        float THIRST_FALL_RATE = envParameters.GetWithDefault("THIRST_FALL_RATE", 0.2f);
        // float NUM_CUBE = envParameters.GetWithDefault("NUM_CUBE", 80.0f);
        // float WATER_ENERGY = envParameters.GetWithDefault("WATER_ENERGY", 60.0f);
        // float FOOD_ENERGY = envParameters.GetWithDefault("FOOD_ENERGY", 60.0f);
        float MOVE_SPEED = envParameters.GetWithDefault("MOVE_SPEED", 5.0f);
        float ROTATE_SPEED = envParameters.GetWithDefault("ROTATE_SPEED", 200.0f);
        // float FOCAL_LENGHT = envParameters.GetWithDefault("FOCAL_LENGHT", 10.0f);
        // float DECISION_PERIOD = envParameters.GetWithDefault("DECISION_PERIOD", 5.0f);
        float MANUAL_EAT_BEHAVIOR = envParameters.GetWithDefault("MANUAL_EAT_BEHAVIOR", 1.0f);

        // this.MaxStep = (int)MAX_STEP;
        maxHunger = MAX_HUNGER;
        minHunger = MIN_HUNGER;
        hungerFallRate = HUNGER_FALL_RATE;
        maxThirst = MAX_THIRST;
        minThirst = MIN_THIRST;
        thirstFallRate = THIRST_FALL_RATE;
        // numCubes = (int)NUM_CUBE;
        // hungerResourceObj.GetComponent<ItemProperties>().value = FOOD_ENERGY;
        // thirstResourceObj.GetComponent<ItemProperties>().value = WATER_ENERGY;
        moveSpeed = MOVE_SPEED;
        rotateSpeed = ROTATE_SPEED;
        // agentViewCamera.focalLength = FOCAL_LENGHT;
        // decisionRequet.DecisionPeriod = (int)DECISION_PERIOD;
        manualEatBehavior = System.Convert.ToBoolean(MANUAL_EAT_BEHAVIOR);

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
        this.manualEatBehavior = false;

        // Generate Hunger Objects
        this.hungerResourceObjs = new GameObject[this.numHungerResourceObj];
        for (int i = 0; i < this.numHungerResourceObj; i++)
        {
            GameObject obj = Instantiate(hungerResourceObj) as GameObject;
            hungerResourceObjs[i] = obj;
            hungerResourceObjs[i].transform.position = GetPos();
            hungerResourceObjs[i].transform.Rotate(0, Random.Range(0f, 90.0f), 0);
            hungerResourceObjs[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        // Generate Thirst Objects
        this.thirstResourceObjs = new GameObject[this.numThirstResourceObj];
        for (int i = 0; i < this.numThirstResourceObj; i++)
        {
            GameObject obj = Instantiate(thirstResourceObj) as GameObject;
            thirstResourceObjs[i] = obj;
            thirstResourceObjs[i].transform.position = GetPos();
            thirstResourceObjs[i].transform.Rotate(0, Random.Range(0f, 90.0f), 0);
            thirstResourceObjs[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
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
        this.manualEatBehavior = false;

        // Randomize agent position
        this.transform.position = new Vector3(0, 2.58f, 0);
        this.transform.Rotate(0, Random.Range(0f, 360.0f), 0);

        // Randomize object positions
        for (int i = 0; i < this.numHungerResourceObj; i++)
        {
            Vector3 pos = GetPos();
            hungerResourceObjs[i].transform.position = pos;
            hungerResourceObjs[i].transform.Rotate(0, Random.Range(0f, 90.0f), 0);
            hungerResourceObjs[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        for (int i = 0; i < this.numThirstResourceObj; i++)
        {
            Vector3 pos = GetPos();
            thirstResourceObjs[i].transform.position = pos;
            thirstResourceObjs[i].transform.Rotate(0, Random.Range(0f, 90.0f), 0);
            thirstResourceObjs[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
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
            this.descentVelocity -= 9.81f * Time.fixedDeltaTime;
            this.character.Move(new Vector3(0, -9.81f * Time.fixedDeltaTime));
        }
        else
        {
            this.descentVelocity = 0;
        }

        for (int i = 0; i < this.numResources; i++)
        {
            this.resourceLevel[i] -= this.resourceDecreaseRate * Time.fixedDeltaTime;
        }
        //print(this.resourceDecreaseRate * Time.deltaTime);  


        //print("Resource (red, blue) = (" + this.resourceLevel[0] + "," + this.resourceLevel[1] + ")");
        Monitor.Log("Red", this.resourceLevel[0] / 15f, transform);
        resourceRed = this.resourceLevel[0];
        Monitor.Log("Blue", this.resourceLevel[1] / 15f, transform);
        resourceBlue = this.resourceLevel[1];

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

        this.manualEatBehavior = false;
        switch (action)
        {
            case 0:
                break;
            case 1:
                Vector3 forward = transform.transform.forward;
                this.character.Move(this.moveSpeed * forward * Time.deltaTime);
                break;
            case 2:
                this.transform.Rotate(0, -this.rotateSpeed * Time.deltaTime, 0);
                break;
            case 3:
                this.transform.Rotate(0, this.rotateSpeed * Time.deltaTime, 0);
                break;
            case 4:
                this.manualEatBehavior = true;
                break;
        }

        // Set zero reward (reward will be defined in the learning-side)
        SetReward(0.0f);
        float max_deviation = Mathf.Max(Mathf.Abs(this.resourceLevel[0]), Mathf.Abs(this.resourceLevel[1]));
        if (max_deviation > this.resourceLimit )
        {
            print("Agent died... (-_-;) ");
            EndEpisode();
        }
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

    public void IncreaseResource(string tag)
    {
        if (tag == "food_red")
        {
            this.resourceLevel[0] += this.hungerResourceIncrease;
        }
        if (tag == "food_blue")
        {
            this.resourceLevel[1] += this.thirstResourceIncrease;
        }
    }

    public bool IsAgentTakingEatBehavior()
    {
        return this.manualEatBehavior;
    }
}
