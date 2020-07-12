using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    [SerializeField] GameObject losePanel;
    [SerializeField] TextMeshProUGUI timerText;
    [Tooltip("Applies to the first level")]
    [SerializeField] float levelTimeInSeconds = 240f;
    [SerializeField] float laterLevelsTimeInSeconds = 90f;
    [SerializeField] Player player;
    int level = 1;
    float startTime;
    float currentTime;
    float passedTime;
    int remainedTime;

    [Header("For test")]
    [SerializeField] bool isLosing;

    void Start()
    {
        startTime = Time.time;
    }

    
    void Update()
    {
        // For test
        if (isLosing)
        {
            Lose();
        }

        currentTime = Time.time;
        passedTime = currentTime - startTime;
        remainedTime = Mathf.RoundToInt(levelTimeInSeconds - passedTime);
        convertSecondToMin();

        if (remainedTime < 0)
        {
            if (level == 1)
            {
                Lose();
            }
            else
            {
                player.LevelUp();
            }
        }
    }

    private void Lose()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }

    public void convertSecondToMin()
    {
        int minute = remainedTime / 60;
        int second = remainedTime % 60;
        timerText.text = minute.ToString("d2") + ":" + second.ToString("d2");
    }

    public void LevelUp()
    {
        level++;
        startTime = Time.time;
        levelTimeInSeconds = laterLevelsTimeInSeconds;
    }
}
