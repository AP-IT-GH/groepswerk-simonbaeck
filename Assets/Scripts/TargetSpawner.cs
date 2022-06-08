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
    private Bounds bounds;
    

    public void Start()
    {
        bounds = GameObject.FindGameObjectWithTag("Muur").GetComponent<Collider>().bounds;
        target = Instantiate(prefab);
        Spawn();
    }
    public void Spawn()
    {
        //spawnPoint.z = muur.transform.position.z -0.1f;
        //spawnPoint.x = Random.Range(-35f, 35f);
        //spawnPoint.x = Random.Range(-1.75f, 1.75f);
        //spawnPoint.y = Random.Range(0.5f, 10f);
        //spawnPoint.y = Random.Range(0.15f, 1.5f);
        //target.transform.position = spawnPoint;
        
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);

        target.transform.position = bounds.center + new Vector3(offsetX, offsetY, offsetZ);
    }
}
