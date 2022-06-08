using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Turret : Agent
{
    [Header("General settings")]
    public TextMeshProUGUI scoreText;

    [Header("Turret general settings")]
    public string turretHeadTag;
    public string turretFootTag;
    public GameObject turretProjectile;
    public Shoot shoot;

    [Header("Turret rotation settings")]
    [Range(10, 100)] 
    public float rotationYSpeed = 25f;
    public float rotationYMax = 0f;
    public float rotationYMin = 0f;
    [Range(10, 100)]
    public float rotationXSpeed = 25f;
    public float rotationXMax = 0f;
    public float rotationXMin = 0f;

    [Header("Scoreboard settings")]
    public TextMeshPro playerScoreText;
    public TextMeshPro aiScoreText;
    private int playerScore = 0;
    private int aiScore = 0;

    private GameObject _turretHead;
    private GameObject _turretFoot;
    private GameObject _Spawner;
    private float rotationY = 0f;
    private float rotationX = 0f;
    private GameObject _target;
    private GameObject _targetHitZone;
    private GameObject _Laser;
    private float timeLeft = 30f;

    public override void Initialize()
    {
        _turretHead = GameObject.FindGameObjectWithTag(turretHeadTag);
        _turretFoot = GameObject.FindGameObjectWithTag(turretFootTag);
        _Spawner = GameObject.FindGameObjectWithTag("Muur");
        _Laser = GameObject.FindGameObjectWithTag("Laser");
    }

    public override void OnEpisodeBegin()
    {
        _target = GameObject.FindGameObjectWithTag("Target");
        _targetHitZone = GameObject.FindGameObjectWithTag("TargetHitZone");
        rotationY = 0f;
        rotationX = 0f;
        _Spawner.GetComponent<TargetSpawner>().Spawn();
        timeLeft = 30f;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //sensor.AddObservation(_target.transform.position);
        sensor.AddObservation(_targetHitZone.transform.position);
        //sensor.AddObservation(_turretFoot.transform.position);
        //sensor.AddObservation(_turretFoot.transform.rotation);
        //sensor.AddObservation(_turretHead.transform.position);
        //sensor.AddObservation(_turretHead.transform.rotation);
        sensor.AddObservation(timeLeft);
        sensor.AddObservation(Vector3.Distance(_targetHitZone.transform.position, _Laser.transform.position));
        sensor.AddObservation(Vector3.Distance(_target.transform.position, _Laser.transform.position));
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int controlSignalHead = actions.DiscreteActions[0];
        int controlSignalFoot = actions.DiscreteActions[1];
        float controlSignalShoot = actions.ContinuousActions[0];

        //print(actions.DiscreteActions[0]);
        //print(actions.DiscreteActions[1]);

        /* if (GetCumulativeReward() <= -1)
        {
            scoreText.text = GetCumulativeReward().ToString();
            EndEpisode();
        } */

        if (controlSignalHead == 2)
        {
            rotationX -= rotationXSpeed * Time.deltaTime;
        }

        if (controlSignalHead == 1)
        {
            rotationX += rotationXSpeed * Time.deltaTime;
        }

        if (controlSignalFoot == 2)
        {
            rotationY -= rotationYSpeed * Time.deltaTime;
        }

        if (controlSignalFoot == 1)
        {
            rotationY += rotationYSpeed * Time.deltaTime;
        }

        /* if (controlSignalShoot > 0)
        {
            SetReward(0.20f);
            shoot.Schiet();
        } */
    }

    private void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            SetReward(-1f);
            Debug.Log("<b><color=yellow>Times up</color></b>");
            //scoreText.text = GetCumulativeReward().ToString();
            //scoreText.color = Color.yellow;
            EndEpisode();
        }

        rotationY = Mathf.Clamp(rotationY, rotationYMax, rotationYMin);
        var rotY = _turretFoot.transform.localEulerAngles;
        rotY.y = rotationY;
        _turretFoot.transform.localEulerAngles = rotY;

        rotationX = Mathf.Clamp(rotationX, rotationXMax, rotationXMin);
        var rotX = _turretHead.transform.localEulerAngles;
        rotX.z = rotationX;
        _turretHead.transform.localEulerAngles = rotX;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = (int)Input.GetAxisRaw("Vertical");
        discreteActions[1] = (int)Input.GetAxisRaw("Horizontal");

        var continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxis("Fire1");
    }

    public void AddAIScore()
    {
        aiScore++;
        aiScoreText.text = aiScore + " AI";
        aiScoreText.color = Color.red;
    }

    public void AddPlayerScore()
    {
        playerScore++;
        playerScoreText.text = "PLAYER " + playerScore;
        playerScoreText.color = Color.green;
    }
}
