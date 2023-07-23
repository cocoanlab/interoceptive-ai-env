# EVAAA : Essential Variables in Autonomous and Adaptive Agents

EVAAA will provide a mechanism to freely choose a goal across different surrounding conditions and keep a more stable reward function, which are the key to build and test autonomous and adaptive RL agents. We provide a 3D virtual environment platform that requires RL agents in the Unity environment. It is designed to facilitate testing RL agent.

![agent](https://github.com/cocoanlab/interoceptive-ai-env/assets/119106107/3ad778d8-38cd-4cb1-843b-9fa58947d6e3)

## Install and Setting
See here for a more detailed installation guide.
The setting process required to run this project is as follows.

1. Clone this repository
2. Download interoceptive AI environment from our [google drive](https://drive.google.com/drive/folders/1OnsRKaeks3kpiVeBAEh47NpcbOHIqfW2?usp=sharing)
3. Unzip environment files in the Example folder of this repository
4. Install [ml-agents](https://github.com/Unity-Technologies/ml-agents)
5. Follow example python code ("python_code_example.py") in Example folder of this repository

## Requirements
| Software | Version |
| -------- | ------- |
| python   | 3.9.13  |

| Package       | Version |
| ------------- | ------- |
| mlagents      | 0.28.0  |
| mlagents-envs | 0.28.0  |



<!-- ### Detailed Installation Guide
This is a more detailed step-by-step installation guide for EVAAA, written for users who don't have lots of experience with python dependencies, Github repositories, and/or Unity -- or in case you run into trouble with the installation.
Here we provide instructions for the installation required for the project. Make sure to follow all the necessary commands, configurations, and any additional setup required.

### Step 1. Clone EVAAA Repository
Here we provide the command to clone the main repository from GitHub to the local machine. We recommend creating a ‘root’ folder so that you can also keep your own training scripts, a Python virtual environment, and any other external EVAAA-related work in the same location.
Cloning this repository can be done either by:
- Downloading the .zip directly and extracting it into your 'root' folder
- Cloning using GitHub's command line interface

### Step 2. Install Dependencies
To run the project after replicating the repo, you must download the necessary packages in the following ways. You can install these via pip or conda, with or without a virtual environment created -- if you're more familiar with a particular method here it's probably best to stick to it.
In EVAAA, the implementation of environment and agent on Unity is based on C# and training is based on python. The way to download and set the packages needed are written at the below.

a. Python
따로 설치해야 할 python version이 존재하는지
- Download
b. Visual Studio Code
c. Unity

### Step 3. Download environment

### Step 4. Open at Unity Hub
Editor version: 2021.3.1f1
After all the packages are ready, then you can run EVAAA project at Unity.  -->


## Manual Control 
When you run this project on Unity, it will proceed with an agent view (a first-person perspective). Here you can control the agent with the following:
<!-- 

If you launch the environment directly from the executable or through the `play.py` script it will launch in player mode. Here you can control the agent with the following:

| Keyboard Key | Action               |
| ------------ | -------------------- |
| W            | move agent forwards  |
| S            | move agent backwards |
| A            | turn agent left      |
| D            | turn agent right     |
| C            | switch camera        |
| R            | reset environment    | --> |

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
