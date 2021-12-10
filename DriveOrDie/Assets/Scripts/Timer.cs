using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public int totalTimeHalf;
    public int totalTimeFirstTop;
    public float currentTime;
    public Text timerInApp, message;
    public float r, g, b, a;

    void showTimeInScreen(float timeLeft)
    {

        if (timeLeft <= 0f)
        {
            BombObject.timerIsRunning = false;
            timeLeft = 0f;
        }
        int minutes = ((int)timeLeft / 60);
        int seconds = (Mathf.FloorToInt(timeLeft % 60));
        timerInApp.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        

        if (timeLeft <= totalTimeFirstTop && timeLeft >= totalTimeHalf/2)
        {
            r = 1f;
            timerInApp.color = new Color(r,g,b,a);
            
        }
        if(timeLeft < totalTimeHalf/2)
        {
            g = 0f;
            timerInApp.color = new Color(r, g, b, a);
            int atemp = seconds % 2;
            message.color = new Color(1, 1, 0, atemp);
        }
            
    }
    void Start()
    {
        totalTimeHalf = TimerObject.totalTime / 2;
        totalTimeFirstTop = totalTimeHalf + totalTimeHalf / 2;

        r = 0; g = 1; b = 0; a = 1;

        BombObject.timerIsRunning = true;

        timerInApp = GameObject.Find("Canvas/Timer").GetComponent<Text>();
        message = GameObject.Find("Canvas/Message").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BombObject.timerIsRunning)
        {
            currentTime = Time.time - BombObject.startTime;
            showTimeInScreen(TimerObject.totalTime - currentTime);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("YouLose");
        }
    }
}
