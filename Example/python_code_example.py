# %%
import os, yaml
import numpy as np

from mlagents_envs.environment import ActionTuple, UnityEnvironment
from mlagents_envs.side_channel.environment_parameters_channel import (
    EnvironmentParametersChannel,
)
from mlagents_envs.side_channel.engine_configuration_channel import (
    EngineConfigurationChannel,
)

# %%
env_file = "YourCurrentDirectory/Example/level-01/level-01"
engineChannel = EngineConfigurationChannel()
paramChannel = EnvironmentParametersChannel()

env = UnityEnvironment(
    file_name=env_file,
    seed=1234,
    side_channels=[engineChannel, paramChannel],
    base_port=1235,
)

engineChannel.set_configuration_parameters(time_scale=1, width=600, height=600)
# %%

config_path = "YourCurrentDirectory/Example/config.yml"
with open(config_path) as f:
    config = yaml.load(f, Loader=yaml.FullLoader)

for key in config.keys():
    for parameters in config[key].keys():
        value = config[key][parameters]
        paramChannel.set_float_parameter(parameters, float(value))

# %%
env.reset()
# %%
behavior_name = list(env.behavior_specs)[0]
spec = env.behavior_specs[behavior_name]
action_spec = spec.action_spec.discrete_branches[0]

# %%
decision_steps, terminal_steps = env.get_steps(behavior_name)
observation = decision_steps[decision_steps.agent_id[0]]
visual_obs = observation.obs[0]
vector_obs = observation.obs[1]

# %%
action_tuple = ActionTuple()
action = 0 # Possible actions: 0:none, 1:move, 2:turn left, 3:turn right, 4: eat
action_tuple.add_discrete(np.resize(action, (len(decision_steps), 1)))
# %%
env.set_actions(behavior_name, action_tuple)
env.step()
# %%
decision_steps, terminal_steps = env.get_steps(behavior_name)

observation = decision_steps[decision_steps.agent_id[0]]
visual_obs = observation.obs[0]
vector_obs = observation.obs[1]
# %%
for i in range(300):
    action = np.random.randint(0, 5)
    action_tuple.add_discrete(np.resize(action, (len(decision_steps), 1)))
    env.set_actions(behavior_name, action_tuple)
    env.step()

# %%
# env.close()
# %%
