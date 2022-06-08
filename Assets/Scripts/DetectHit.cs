using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.MLAgents;
using UnityEngine;

public class DetectHit : MonoBehaviour
{
    public Turret turretAgent;
    private GameObject Spawner;
    private GameObject Turret;

    // Start is called before the first frame update
    void Start()
    {
        Spawner = GameObject.FindGameObjectWithTag("Spawner");
        Turret = GameObject.FindGameObjectWithTag("TurretFoot");
        turretAgent = Turret.GetComponent<Turret>();
    }

    private void OnCollisionEnter(Collision other)
    {
        /* if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            
            if (gameObject.tag == "TargetHitZone")
            {
                Debug.Log("<b><color=green>Target</color></b>");
                turretAgent.SetReward(1f);
                //turretAgent.scoreText.text = turretAgent.GetCumulativeReward().ToString();
                //turretAgent.scoreText.color = Color.green;
                turretAgent.EndEpisode();
            } 
            
            if (gameObject.tag == "Muur")
            {
                Debug.Log("<b><color=red>Muur</color></b>");
                turretAgent.SetReward(-0.15f);
                //turretAgent.scoreText.text = turretAgent.GetCumulativeReward().ToString();
                //turretAgent.scoreText.color = Color.red;
                //turretAgent.EndEpisode();
            }
        } */

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            if (gameObject.tag == "TargetHitZone")
            {
                Debug.Log("<b><color=green>AI HIT</color></b>");
                turretAgent.SetReward(1f);
                //turretAgent.scoreText.text = turretAgent.GetCumulativeReward().ToString();
                //turretAgent.scoreText.color = Color.red;
                turretAgent.AddAIScore();
                turretAgent.EndEpisode();
            }
        }

        if (other.gameObject.tag == "Bullet")
        {
            if (gameObject.tag == "TargetHitZone")
            {
                Debug.Log("<b><color=green>Player HIT</color></b>");
                //turretAgent.scoreText.text = turretAgent.GetCumulativeReward().ToString();
                //turretAgent.scoreText.color = Color.red;
                turretAgent.AddPlayerScore();
                turretAgent.EndEpisode();
            }
        }
    }
}
