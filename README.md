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
Voor onze AI maken wij gebruik van een turret die kan draaien om zijn as. Voor de turret zelf gebruiken wij een asset. De Turret bevat het turret script, decission Requester en Behavior Parameters. Verder heeft de laser die gelijk loopt met zijn barrel/loop een Box Collider met De Is Trigger aangevinkt en een rigidbody zonder Use Gravity maar met Is Kinematic. De turret zelf heeft bevat 4 Ray Perception Sensor 3D's. Deze zijn allen een beetje hoger/lager aan elkaar. Dit doen we omdat zodat de turret de target sneller kan vinden. Voor het script zelf zetten wij de turret altijd terug op zijn beginpositie als de episode begint. Als observations houden we de afstand bij tussen de laser en het target, de positie van het target en de tijd die nog over is voor het target zich verplaatst. Als de tijd verstreken is zal de turret een reward krijgen van -1. Als hij de target raakt krijgt hij een reward van 1. na beide wordt de episode beeindigt.
1. Snelheid van de draaibeweging instellen in de turret prefab.
2. Text selecteren waar de score moet weergeven worden.
3. Behaviour parameters worden als volgt ingesteld:  
- Behaviour name: ShootTarget
- Vector observation
  - Space size: 6
  - Stacked vectors: 1
- Actions
  - Continous actions: 2
  - Discrete branches: 2
    - Branch 0 size: 4
    - Branch 1 size: 4
- Model: .onnx bestand dat gegenereert word na het trainen van de AI
### YAML instellingen
Onze agent zal getraind kunnen worden via ML-Agents met volgende configuratie. 
1. Maak een map **config** aan in de root van het project.
2. Maak een bestand \<naam-yaml-bestand\>.yaml en plak de onderstaande code erin.
3. Verander het behaviour name value in het yaml bestand naar dat wat ingesteld staat in de **Behaviour Parameters** in Unity.
4. Activeer het configuratiebestand om in Unity te gebruiken via volgende commando (uitvoeren in config map):
```cmd
mlagents-learn <naam-yaml-bestand>.yaml --run-id=<naam-run>
```
```yaml
behaviors:
  <behaviour-name>:
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
Nog aanvullen...

## Omgeving
### Spawner
Om onze targets te laten spawnen hebben wij een script geschreven dat een instantie van een prefab gaat verplaatsen als de Spawn() functie wordt aangeroepen. Deze zal het target van plaats veranderen binnen de bounds van het muur object. De traget zal dus alleen binnen de muur kunnen verplaats worden.
1. Plaats een object in de scene.
2. Pas de grootte en locatie aan waar je het target wilt laten spawnen.
3. Voeg een Prefab toe in de inspector, deze zal dienen als object dat spawnt.

### Scorebord
Onze game bevat ook een scorebord waar de score word bijgehouden van de AI en de speler zelf.
1. Maak twee TextMeshPro objecten aan, 1 voor AI en 1 voor speler.
2. Kies op welke positie de tekst moet komen te staan.
3. Voeg de twee tekst objecten toe in het turret script.
