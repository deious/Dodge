using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    [SerializeField]
    public GameObject bulletPrefab;
    public GameObject pool;
    public int poolSize;

    public Queue<GameObject> bulletQueue = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;

        Initialize(poolSize);
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
            bulletQueue.Enqueue(CreateNewObject());

    }

    private GameObject CreateNewObject()
    {
        GameObject newObj = Instantiate(bulletPrefab);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(pool.transform);
        return newObj;
    }

    public GameObject GetObject()
    {
        if (bulletQueue.Count > 0)
        {
            GameObject obj = bulletQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            GameObject newObj = CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.SetActive(true);
            return newObj;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(pool.transform);
        bulletQueue.Enqueue(obj);
    }
}
