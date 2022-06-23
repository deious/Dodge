using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
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

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = BulletPool.Instance.GetObject();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            target = FindObjectOfType<PlayerController>().transform;
            bullet.transform.LookAt(target);
            StartCoroutine(ReCall(bullet, 3.0f));
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    IEnumerator ReCall(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);
        BulletPool.Instance.ReturnObject(gameObject);
    }
}
