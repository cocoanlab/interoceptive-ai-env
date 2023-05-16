# EVAAA : Essential Variables in Autonomous and Adaptive Agents

EVAAA will provide a mechanism to freely choose a goal across different surrounding conditions and keep a more stable reward function, which are the key to build and test autonomous and adaptive RL agents. We provide a 3D virtual environment platform that requires RL agents in the Unity environment. It is designed to facilitate testing RL agent.

우리 연구 이미지 or gif 첨부 

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

각 레벨 별 구체적인 설명

## Unity Code

사용된 코드 링크 달아서 표로 정리해도 좋을 듯 

## Unity Assets Sources
[Field Material 1]([https://assetstore.unity.com/packages/3d/environments/landscapes/mountain-terrain-rock-tree-97905](https://assetstore.unity.com/packages/3d/environments/landscapes/mountain-terrain-rock-tree-97905))

[Field Material 2]([https://assetstore.unity.com/packages/2d/textures-materials/floors/yughues-free-ground-materials-13001#content](https://assetstore.unity.com/packages/2d/textures-materials/floors/yughues-free-ground-materials-13001#content))

[Field Material 3]([https://assetstore.unity.com/packages/2d/textures-materials/nature/snow-cliff-materials-137086#content](https://assetstore.unity.com/packages/2d/textures-materials/nature/snow-cliff-materials-137086#content))

[Pond Rock]([https://assetstore.unity.com/packages/3d/props/exterior/rock-and-boulders-2-6947#content](https://assetstore.unity.com/packages/3d/props/exterior/rock-and-boulders-2-6947#content))

[Water Material for Pond]([https://assetstore.unity.com/packages/2d/textures-materials/water/stylize-water-texture-153577#content](https://assetstore.unity.com/packages/2d/textures-materials/water/stylize-water-texture-153577#content))

[Rock]([https://assetstore.unity.com/packages/3d/environments/landscapes/rocky-hills-environment-light-pack-89939#content](https://assetstore.unity.com/packages/3d/environments/landscapes/rocky-hills-environment-light-pack-89939#content))

[Bush]([https://assetstore.unity.com/packages/3d/vegetation/plants/yughues-free-bushes-13168#content](https://assetstore.unity.com/packages/3d/vegetation/plants/yughues-free-bushes-13168#content))

[Tree]([https://assetstore.unity.com/packages/3d/vegetation/trees/2022-pbr-xfrogplants-sampler-229007#content](https://assetstore.unity.com/packages/3d/vegetation/trees/2022-pbr-xfrogplants-sampler-229007#content))

[Hill]([https://assetstore.unity.com/packages/3d/environments/landscapes/autumn-mountain-52251#content](https://assetstore.unity.com/packages/3d/environments/landscapes/autumn-mountain-52251#content))

[Flower]([https://assetstore.unity.com/packages/3d/environments/fantasy-landscape-103573#content](https://assetstore.unity.com/packages/3d/environments/fantasy-landscape-103573#content))

[Snowman]([https://assetstore.unity.com/packages/3d/props/free-snowman-105123#content](https://assetstore.unity.com/packages/3d/props/free-snowman-105123#content))

[Snow Material]([https://assetstore.unity.com/packages/2d/textures-materials/water/stylize-snow-texture-153579#content](https://assetstore.unity.com/packages/2d/textures-materials/water/stylize-snow-texture-153579#content))
