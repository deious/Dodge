using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private bool SteamPackCheck = false;
    private Color color;
    public float speed = 8f;
    public Animator ani;
    public Image img;
    public float coolTime;
    public float holdingTime;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        color = img.color;
        color.a = 0f;
        img.color = color;
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;
        transform.LookAt(transform.position + newVelocity);

        if (xSpeed == 0 && zSpeed == 0)
            ani.SetBool("RunCheck", false);
        else
            ani.SetBool("RunCheck", true);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (SteamPackCheck == false)
                UseSteampack();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }

    public void UseSteampack()
    {
        SteamPackCheck = true;
        speed += 5;
        StartCoroutine(CoolTime(coolTime));
        StartCoroutine(HoldingTime(holdingTime));
    }

    IEnumerator CoolTime(float coolTime)
    {
        color.a = 0.3f;
        img.color = color;
        float timeCheck = coolTime;
        img.fillAmount = 1;
        float temp = img.fillAmount / timeCheck;
        while(timeCheck > 0)
        {
            img.fillAmount -= temp * 0.1f;
            timeCheck -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        SteamPackCheck = false;
    }

    IEnumerator HoldingTime(float holdingTime)
    {
        while(holdingTime > 0)
        {
            holdingTime -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        speed -= 5;
    }
}