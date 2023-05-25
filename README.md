# EVAAA : Essential Variables in Autonomous and Adaptive Agents

EVAAA will provide a mechanism to freely choose a goal across different surrounding conditions and keep a more stable reward function, which are the key to build and test autonomous and adaptive RL agents. We provide a 3D virtual environment platform that requires RL agents in the Unity environment. It is designed to facilitate testing RL agent.

![agent](https://github.com/cocoanlab/interoceptive-ai-env/assets/119106107/3ad778d8-38cd-4cb1-843b-9fa58947d6e3)

## Install and Setting
See [here](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/docs/install) for a more detailed installation guide, including information on python/pip/conda and using the command line during installation.
The setting process required to run this project is as follows.
1. Clone EVAAA repository.
2. Install dependencies, which are the packages required for execution EVAAA, by running pip install -e EVAAA from the root folder.
The required packages and each version:
3. Download the environment for your system
4. Open at Unity Hub
Editor version “2021.3.1f1” should be installed.


## Manual Control 
When you run this project on Unity, it will proceed with an agent view (a first-person perspective). Here you can control the agent with the following:
| Keyboard Key  | Action    |
| --- | --- |
| W   | move agent forwards |
| S   | move agent backwards|
| A   | turn agent left     |
| D   | turn agent right    |


## Unity Environment
We have a dynamically changing environment, and there are 5 levels in total. 

### Level 1. Basic setup: Food, water, and temperature.
![스크린샷 2023-05-22 오전 11 17 51](https://github.com/cocoanlab/interoceptive-ai-env/assets/119106107/bf056b30-339c-4064-bd7d-96968b743c62)

At level 1, the environment is simple, featuring only the fundamental resources, that is, food, water (i.e., a pond), and temperature
- The food is organized into cubes and possesses the ability to undergo color changes over time.
- The water is arranged in the form of a pond. 
- The temperature is randomized based on the specified parameters and is regenerated whenever the agent dies.
  - The temperature can be directly modified through the "Field Temperature parameters".


### Level 2. Obstacles.
![image](https://github.com/cocoanlab/interoceptive-ai-env/assets/119106107/befa3f25-bf09-4179-a678-7b8f30df8d82)

The agent needs to leverage the knowledge acquired from the previous level to successfully adapt to a more complex environmental setting. 
At level 2, we adds natural objects, such as trees, rocks, and bushes, which act as obstacles that hinder the agent’s vision

### Level 3. Day/night cycle.
![dayandhignt](https://github.com/cocoanlab/interoceptive-ai-env/assets/119106107/f41d31a3-2180-437d-9c29-478a4e5c6b37)

In level 3, we implemented the day/night cycle using a sun game object that rotates at a predefined degree over time.

At night, the overall temperature is lower and the agent's vision is darker, so it receives less visual input. 

### Level 4. Weather changes.
![weather](https://github.com/cocoanlab/interoceptive-ai-env/assets/119106107/1bd12896-3bbe-4b4b-ad54-0ebe251f26e3)

In level 4, we implemented the weather changes. We incorporated two weather variations into EVAAA: rain and snow, drawing inspiration from nature.

Weather options can be selected as a parameter in Unity itself, and can be applied to any scene. 
You can also set temperature changes based on the weather, with rain or snow obstructing the agent's view. 

### Level 5. Four seasons.
![season](https://github.com/cocoanlab/interoceptive-ai-env/assets/119106107/d3bff940-96c9-4ce6-ad04-e5858dd7a95d)

In level 5, we combine all challenges from lower level environments, e.g., day/night cycle and weather changes, with seasonal variations– spring, summer, fall, and winter.
Each season is characterized by a number of unique features with varying colors, which can disrupt the agent’s vision for navigating and detecting resources.

## Unity Script Overview

EVAAA environment consists of four large categories of scripts.

+ Agent
    + [InteroceptiveAgent](https://github.com/cocoanlab/interoceptive-ai-env/blob/2dfe4d8842bde685f6d2fea5f07070c5c37aada1/Assets/Scripts/InteroceptiveAgent.cs)
	
+ Animal
    + [Animal](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/Animal.cs)
    + [Pig](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/Pig.cs)
    + [Predator](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/Predator.cs)
    + [StrongAnimal](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/StrongAnimal.cs)
    + [WeakAnimal](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/WeakAnimal.cs)
	
+ Environment
    + [Field](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/Field.cs)
    + [WeatherManager](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/WeatherManager.cs)
    + [AreaTemp](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/AreaTemp.cs)
    + [DayAndNight](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/DayAndNight.cs)
    + [ObjectiveTemp](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/ObjectTemp.cs)
    + [PondBuild](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/PondBuild.cs)
    + [Treebuild](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/TreeBuild.cs)
    + [TreeShader](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/TreeShader.cs)
    + [ThermalObject](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/ThermalObject.cs)
    + [ThermalSensing](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/ThermalSensing.cs)
    + [HeatMap](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/HeatMap.cs)
    + [FieldThermoGrid](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/FieldThermoGrid.cs)
    + [skybox](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/skybox.cs)
    + [cave2](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/cave2.cs)
	
+ Resource
    + [ResourceEating](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/ResourceEating.cs)
    + [ResourceProperty](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/ResourceProperty.cs)
    + [ResourceUI](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/ResourceUI.cs)
	
+ Others
    + [AgentTrack](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/AgentTrack.cs)
    + [CameraFollow](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/CameraFollow.cs)
    + [CaptureScreenShot](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/CaptureScreenShot.cs)
    + [FieldOfViewAngle](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/FieldOfViewAngle.cs)
    + [SceneInitialization](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/SceneInitialization.cs)


## Unity Assets Sources

EVAAA environments are built using the following assets. (All assets are free assets from Unity Asset Store.)

+ [Field Material 1](https://assetstore.unity.com/packages/3d/environments/landscapes/mountain-terrain-rock-tree-97905)
+ [Field Material 2](https://assetstore.unity.com/packages/2d/textures-materials/floors/yughues-free-ground-materials-13001#content)
+ [Field Material 3](https://assetstore.unity.com/packages/2d/textures-materials/nature/snow-cliff-materials-137086#content)
+ [Pond Rock](https://assetstore.unity.com/packages/3d/props/exterior/rock-and-boulders-2-6947#content)
+ [Water Material for Pond](https://assetstore.unity.com/packages/2d/textures-materials/water/stylize-water-texture-153577#content)
+ [Rock](https://assetstore.unity.com/packages/3d/environments/landscapes/rocky-hills-environment-light-pack-89939#content)
+ [Bush](https://assetstore.unity.com/packages/3d/vegetation/plants/yughues-free-bushes-13168#content)
+ [Tree](https://assetstore.unity.com/packages/3d/vegetation/trees/2022-pbr-xfrogplants-sampler-229007#content)
+ [Hill](https://assetstore.unity.com/packages/3d/environments/landscapes/autumn-mountain-52251#content)
+ [Flower](https://assetstore.unity.com/packages/3d/environments/fantasy-landscape-103573#content)
+ [Snowman](https://assetstore.unity.com/packages/3d/props/free-snowman-105123#content)
+ [Snow Material](https://assetstore.unity.com/packages/2d/textures-materials/water/stylize-snow-texture-153579#content)

# Parameters

See [here](https://github.com/cocoanlab/interoceptive-ai/blob/dev-sw-0.1.0/config/config.yaml) for a more detailed parameter setting and temporary setting value.

You can set some parameters important for implementing the environment at Unity.

Here, () means a list of words located in the corresponding place.
For example, numResource(Food, Water, Pond) means numResourceFood, numResourceWater, numResourcePond.

## Environment parameters
This is a part that defines parameters necessary to implement the environment on Unity.

### Resources
Set the number and position of each food and water cube, and pond.
- numResource(Food, Water, Pond): The generation number of resources.
- resource(Food, Water)Value: The decreasing and increasing amounts for each resource at the food, water bar of agent.
- IsRandom(Food, Water, Pond)Position: As a Boolean variable, it sets whether the generation location of resources is random.

Set the pond and food cubes’ position. The food cube creation method is to pull out a new location every time and if the location is too close to the pond, then pull the location again. These parameters below are related to this function. You can see ([here](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.13.1/Assets/Scripts/Field.cs)) for the detailed implementation.
- pondReourcePosition(X, Y, Z): The x, y, and z-axis positions of the center of the pond on the field of unity.
- minDistanceToPond: Minimum distance the food cube should stay away from the pond. This prevents food cubes from forming on or near the pond.
- randomPositionMaxTry: When algorithm pull out new location, it uses while loop. So, if there’re no exact spawn position, the code will be repeated forever. To prevent this severe problem, we have limited the maximum number of pull-out attempts.
  
### Fieldtemperature
We set field temperature as the portion of cubes acting as a grid. Therefore, in this part, important features of grid cube each representing temperature of ground are set. You can check these parameters in these codes([Field](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/Field.cs),
[HeatMap](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.13.1/Assets/Scripts/HeatMap.cs),
[ThermalSensing](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.13.1/Assets/Scripts/ThermalSensing.cs)).
- numberOfGrideCube(X, Z): The number of cubes which set the temperature of the ground.
- sizeOfGridCube(X, Y, Z): The size of 3D grid cube corresponds to temperature.
- positionOfGridCenter(X, Y, Z): The x, y, and z-axis position of the center of grid cubes.

Settings of temperature and heat map of environment’s ground. Hotspot sets the temperature of certain spots of the terrain to vary the temperature of each area.
- useObjectHotSpot: Set the hotspot of selected game objects such as trees, caves, and ponds.
- useRandomHotSpot: Select a random cube among grid cubes each representing temperature regardless of the game objects and designate them as a hotspot.
- hotspot(Count, Temp): The number of hotspot cubes and their temperature.
- fieldDefaultTemp: Default temperature of cubes representing field’s temperature.
- heatMap(Max, Min)Temp: Implementation of heat map located on the lower right side of Screen. Set of maximum and minimum temperature of heatmap.
- smoothingSigma: We perform smoothing of the temperature assigned to the cube from the center to the edge. This is used as a temperature smoothing factor.
- dayNightSpeed: Set how many seconds to pass in the game world after one second in the real world. Features of sky in unity environment like color changes as the time flows at a set speed.
- (day, night)TemperatureVariance: Temperature changing variance of day and night.
  
### Action
Set agent’s speed including moving and eating.
- (move, turn)Speed: Speed of agent’s about moving and turning.
- autoEat: As a Boolean variable, justifying whether to eat automatically if the agent encounter or hit the food and water cube.
- eatingDistance: Distance between cube and agent that agent can eat. 

### ev
This part relates to the agent's interoceptive bar including **Food, Water, Thermo** located in the upper middle of the unity screen.
- (max, min, start)(Food, Water, Thermo)Level: Maximum and minimum from the defined starting level of each variable.
- change(Food, Water, Thermo)(_0, LevelRate): 
  
### Visual, Olfactory, Thermo Sensor
Sensory inputs including visual, olfactory, and thermo that go into the agent.
Each sensory inputs can be detected by agent through grid cubes around agent.
- use(Visual, Olfactory, Thermo): As a Boolean variable, set whether to use each sensory input.
- visual(Hight, Width): 
- olfactorySensor(Length, Size):
- thermoSensor(ChangeRate, Size):
### touchSensor
- useTouchObs:
