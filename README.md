# EVAAA : Essential Variables in Autonomous and Adaptive Agents

EVAAA will provide a mechanism to freely choose a goal across different surrounding conditions and keep a more stable reward function, which are the key to build and test autonomous and adaptive RL agents. We provide a 3D virtual environment platform that requires RL agents in the Unity environment. It is designed to facilitate testing RL agent.

![agent](https://github.com/cocoanlab/interoceptive-ai-env/assets/119106107/3ad778d8-38cd-4cb1-843b-9fa58947d6e3)

## Install and Setting
*see [here](docs/installationGuide.md) for a more detailed installation guide, including information on Python/pip/conda and using the command line during installation*

To get started you will need to:
1. Clone this repo.
2. **Install the animalai python package** and requirements by running `pip install -e animalai` from the root folder.
3. **Download the environment** for your system:

| OS | Environment link |
| --- | --- |
| Linux |  [v3.0.1](https://kv301.user.srcf.net/wp-content/uploads/2022/04/AAI_v3.0.1_build_linux_090422.zip) |
| Mac | [v3.0.1](https://kv301.user.srcf.net/wp-content/uploads/2022/04/AAI_v3.0.1_build_macOS_090422.zip) |
| Windows | [v3.0.1](https://kv301.user.srcf.net/wp-content/uploads/2022/04/AAI_v3.0.1_build_windows_090422.zip) |

(Old v2.x versions can be found [here](docs/oldVersions.md))

Unzip the **entire content** of the archive to the (initially empty) `env` folder. On linux you may have to make the file executable by running `chmod +x env/AnimalAI.x86_64`. Note that the env folder should contain the AnimalAI.exe/.x86_84/.app depending on your system and *any other folders* in the same directory in the zip file.

## Manual Control 

If you launch the environment directly from the executable or through the `play.py` script it will launch in player mode. Here you can control the agent with the following:

| Keyboard Key  | Action    |
| --- | --- |
| W   | move agent forwards |
| S   | move agent backwards|
| A   | turn agent left     |
| D   | turn agent right    |
| C   | switch camera       |
| R   | reset environment   |

## Unity Environment
We have a dynamically changing environment, and there are 5 levels in total. 

### Level 1. Basic setup: Food, water, and temperature.
![스크린샷 2023-05-22 오전 11 17 51](https://github.com/cocoanlab/interoceptive-ai-env/assets/119106107/bf056b30-339c-4064-bd7d-96968b743c62)

At level 1, the environment is simple, featuring only the fundamental resources, that is, food, water (i.e., a pond), and temperature

### Level 2. Obstacles.
### Level 3. Day/night cycle.
### Level 4. Weather changes.
### Level 5. Four seasons.



## Unity Script Overview

+ Agent
    + [InteroceptiveAgent](https://github.com/cocoanlab/interoceptive-ai-env/blob/2dfe4d8842bde685f6d2fea5f07070c5c37aada1/Assets/Scripts/InteroceptiveAgent.cs)
	
+ Animal
    + [Animal](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/Animal.cs)
    + [Pig](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/Pig.cs)
    + [Predator](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/Predator.cs)
    + [StrongAnimal](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/StrongAnimal.cs)
    + [WeakAnimal](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/WeakAnimal.cs)
	
+ Environment
    + [AreaTemp](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/AreaTemp.cs)
    + [cave2](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/cave2.cs)
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
    + [WeatherManager](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/WeatherManager.cs)
    + [Field](https://github.com/cocoanlab/interoceptive-ai-env/blob/r0.12.3/Assets/Scripts/Field.cs)
	
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

EVAAA environments are built using the following assets.

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
