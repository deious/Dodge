using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    float spawnRateMin = 0.3f;
    float spawnRateMax = 3f;

    Transform target;
    float spawnRate;
    float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        
        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
