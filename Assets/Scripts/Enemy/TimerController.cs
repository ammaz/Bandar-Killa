using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    //Change for reply
    public float timeValue = 90;
    public Text timeText;

    private GameManagerScript gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerScript>();
    }
    void Update()
    {
        if (!GameManagerScript.GameOverCheck)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
                gameManager.Victory();
            }

            DisplayTime(timeValue);
        }  
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
