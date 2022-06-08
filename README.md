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
Voeg de nodige packages toe aan het unity project
•	XR Interaction ToolKit 
•	Xr plugin manager
•	Oculus xr plugin

Dan voeg je een xr origin base(action based) toe. Door op je rechter muis knop te clicken. En dit aanduiden onder XR.  Als dit correct verlopen is krijg je een action manager en een origin.  

![image](https://user-images.githubusercontent.com/93989713/172633562-ac47ae3b-390a-4399-8b0d-6df761a73f87.png)

In deze origin moet je nog de data juist zetten van het rechter en linker hand.
Vervolgen moet je naar project settings gaan en onder xr plugin management de provider correct zetten voor welke vr je gebruik. 
![image](https://user-images.githubusercontent.com/93989713/172633622-60a1f5e9-95e7-4f6f-aa8b-c13d827e43a9.png)




Acties
Om een actie uit te voeren maken we een lijst met al de devices in. Die we daarna opvullen met getdevices. In dit voorbeeld gebruiken we de rechter hand dus gebruiken we device 2. De vologorde van devices is vr-headset,linkerhand, rechterhand. 

 ![image](https://user-images.githubusercontent.com/93989713/172633669-8712cf40-ecff-47e3-803e-e19fe3cd13c0.png)


Om een actie te doen waneer er een knop word ingedrukt.  Gebruiken we de getfeaturvale in dit voorbeeld gebruiken we de trigger. En we zetten deze in een float. Waneer deze float grooter is dan 0.1f dan zal de funtie worden uitgevoert. 

![image](https://user-images.githubusercontent.com/93989713/172633708-f7644d8f-b3c9-401f-a549-1810d690f9b6.png)


## Omgeving
