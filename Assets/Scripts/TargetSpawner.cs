using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject prefab;
    private GameObject target;
    public GameObject muur;
    public Vector3 spawnPoint;
    public float min = 1.0f;
    public float max = 3.5f;

    public void Start()
    {
        target = Instantiate(prefab);
        Spawn();
    }
    public void Spawn()
    {
        spawnPoint.z = muur.transform.position.z -0.1f;
        spawnPoint.x = Random.Range(-35f, 35f);
        //spawnPoint.x = Random.Range(-1.75f, 1.75f);
        spawnPoint.y = Random.Range(0.5f, 10f);
        //spawnPoint.y = Random.Range(0.15f, 1.5f);
        target.transform.position = spawnPoint;
    }
}
