# Training
This will give you a quick start on how to start a training process. The basic idea of reinforcement learning is shown here:
<p align="center">
  <img src=https://www.kdnuggets.com/images/mathworks-reinforcement-learning-fig1-543.jpg alt="Image" height="200"/>
</p>

- **Observations** - what the agent perceives about the environment. Observations can be numeric and/or visual.
- **Actions** - what actions the agent can take. Similar to observations, actions can either be continuous or discrete depending on the complexity of the environment and agent.
- **Reward signals** - a scalar value indicating how well the medic is doing. Note that the reward signal need not be provided at every moment, but only when the agent performs an action that is good or bad.

## Start a Training
You need the opened Unity project and a terminal in which you cd to museum-heist-agent-training.
With the provided poetry set-up, simply run poetry run poe learn --force .\config\thief_config.yaml and wait until a message "listening on port ..." appears.
Then enter play mode in your unity project, which should start the training of the agent in the chosen scenario.

## Monitoring
In order to see what's going on during training start tensorboard by executing (in a second terminal) poetry run poe tensorboard and then opening http://localhost:6006/ in your favorite browser.
If you chose to use a different set-up, see the commands that poe learn and poe tensorboard aliases in the [tool.poe.tasks] section of museum-heist-agent-training/pyproject.toml and use their equivalents in your setup.

## Details
For a detailed description see the official Unity documentation. -> [here](https://github.com/Unity-Technologies/ml-agents/blob/main/docs/ML-Agents-Overview.md)