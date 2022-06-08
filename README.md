# Target Shooter
## VR experience project
Piet Bols  
Stef Santens  
Ali El Khattabi  
Vincent Van Oevelen  
Simon Baeck  

# Tutorial
## AI
### Unity instellingen
TODO
### YAML instellingen
Onze agent zal getraind kunnen worden via ML-Agents via volgende configuratie.  
```yaml
behaviors:
  ShootTarget:
    trainer_type: ppo
    hyperparameters:
      batch_size: 10
      buffer_size: 100
      learning_rate: 3.0e-4
      beta: 5.0e-4
      epsilon: 0.2
      lambd: 0.99
      num_epoch: 3
      learning_rate_schedule: constant
      beta_schedule: linear
      epsilon_schedule: constant
    network_settings:
      normalize: false
      hidden_units: 128
      num_layers: 2
    reward_signals:
      extrinsic:
        gamma: 0.99
        strength: 1.0
    max_steps: 1000000
    time_horizon: 64
    summary_freq: 1000
```
_config/ShootTarget.yaml_

## VR

## Omgeving
