using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public float Speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) == true)
        {
            PlayerRigidbody.AddForce(0f, 0f, Speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            PlayerRigidbody.AddForce(0f, 0f, -Speed);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            PlayerRigidbody.AddForce(Speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            PlayerRigidbody.AddForce(-Speed, 0f, 0f);
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
