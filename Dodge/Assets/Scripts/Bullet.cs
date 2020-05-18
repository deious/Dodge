using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float minSpeed = 6f;
    float maxSpeed = 12f;
    private Rigidbody bulletRigidbody;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * Random.Range(minSpeed,maxSpeed);

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
