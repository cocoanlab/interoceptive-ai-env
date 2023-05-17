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

## Unity Script Overview

## Unity Assets Sources

EVAAA environments are built using the following assets.