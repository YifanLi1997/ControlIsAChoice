using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
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
    Light[] lights;

    void Start()
    {
        startTime = Time.time;
    }

    
    void Update()
    {
        lights = FindObjectsOfType<Light>();
        Debug.Log("there are " + lights.Length.ToString() + "lights");

        // For test
        if (isLosing)
        {
            Lose();
        }

        currentTime = Time.time;
        passedTime = currentTime - startTime;
        remainedTime = Mathf.RoundToInt(levelTimeInSeconds - passedTime);
        if (level != 3)
        {
            convertSecondToMin();
        }
        else
        {
            timerText.text = "??:??";
        }
        
        // TODO: BUG - it should not be done every frame. Levels can be skipped.
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
        Debug.Log("level: " + level);
        level++;
        if (level == 4)
        {
            sceneLoader.LoadSceneByName("Win");
        }

        startTime = Time.time;
        levelTimeInSeconds = laterLevelsTimeInSeconds;
        if (level == 3)
        {
            levelTimeInSeconds = laterLevelsTimeInSeconds + UnityEngine.Random.value * laterLevelsTimeInSeconds;
        }
    }

    public int GetLevel()
    {
        return level;
    }
}
