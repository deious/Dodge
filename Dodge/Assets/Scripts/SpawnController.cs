using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] Spawners;
    public float showTime = 5f;
    int num = 0;

    void Start()
    {
        int len = Spawners.Length;

        for (int i = 0; i < len; i++)
        {
            Spawners[i].SetActive(false);
        }

        StartCoroutine(ShowSpawner());
    }

    IEnumerator ShowSpawner()
    {
        if (num > 3)
        {
            StopAllCoroutines();
        }

        yield return new WaitForSeconds(showTime);
        Spawners[num].SetActive(true);
        num++;
        StartCoroutine(ShowSpawner());
    }
}
