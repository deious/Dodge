using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    float surviveTime;
    bool isGameover;

    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        if(!isGameover)
        {
            surviveTime += Time.deltaTime;

            timeText.text = "Time: " + surviveTime.ToString("N2");
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
                Time.timeScale = 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + bestTime.ToString("N2");

        Time.timeScale = 0;
    }
}