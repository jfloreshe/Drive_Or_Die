using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public const int TOTAL_TIME = 75;
    public const int TOTAL_TIME_HALF = TOTAL_TIME / 2;
    public const int TOTAL_TIME_FIRST_TOP = TOTAL_TIME_HALF + TOTAL_TIME_HALF / 2;

    public float currentTime;
    public float startTime;
    public bool timerIsRunning = false;
    public Text timerInApp, message;
    public float r, g, b, a;

    void showTimeInScreen(float timeLeft)
    {

        if (timeLeft <= 0f)
        {
            timerIsRunning = false;
            timeLeft = 0f;
        }
        int minutes = ((int)timeLeft / 60);
        int seconds = (Mathf.FloorToInt(timeLeft % 60));
        timerInApp.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        

        if (timeLeft <= TOTAL_TIME_FIRST_TOP && timeLeft >= TOTAL_TIME_HALF/2)
        {
            r = 1f;
            timerInApp.color = new Color(r,g,b,a);
            
        }
        if(timeLeft < TOTAL_TIME_HALF/2)
        {
            g = 0f;
            timerInApp.color = new Color(r, g, b, a);
            int atemp = seconds % 2;
            message.color = new Color(1, 1, 0, atemp);
        }
            
    }
    void Start()
    {
        r = 0; g = 1; b = 0; a = 1;
        timerIsRunning = true;
        startTime = Time.time;
        timerInApp = GameObject.Find("Canvas/Timer").GetComponent<Text>();
        message = GameObject.Find("Canvas/Message").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            currentTime = Time.time - startTime;
            showTimeInScreen(TOTAL_TIME - currentTime);
        }
    }
}
