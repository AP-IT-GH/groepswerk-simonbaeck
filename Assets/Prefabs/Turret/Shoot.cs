using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    float timer = 10f;
    bool start = false;
    public float shootRate = 3f;
    public int ShootForce = 75;

    private GameObject _agent;

    private void Start()
    {
        _agent = GameObject.FindGameObjectWithTag("TurretFoot");
    }

    public void Schiet()
    {
        if (timer >= shootRate)//shoot{
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * ShootForce, ForceMode.VelocityChange);
            start = true;
            timer = 0f;
        }

        if (start)
        {
            if (timer < shootRate)
                timer += Time.deltaTime;
            else
            {
                timer = shootRate;
                start = false;
            }

        }
    }
}
