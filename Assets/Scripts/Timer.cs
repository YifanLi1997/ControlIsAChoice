using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float levelTimeInSeconds = 300;
    float startTime;
    float currentTime;
    float passedTime;
    int remainedTime;

    void Start()
    {
        startTime = Time.time;
    }

    
    void Update()
    {
        currentTime = Time.time;
        passedTime = currentTime - startTime;
        remainedTime = Mathf.RoundToInt(levelTimeInSeconds - passedTime);
        convertSecondToMin();
    }

    public void convertSecondToMin()
    {
        int minute = remainedTime / 60;
        int second = remainedTime % 60;
        timerText.text = minute.ToString("d2") + ":" + second.ToString("d2");
    }
}
