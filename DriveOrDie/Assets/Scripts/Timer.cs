using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentTime;
    public Text timerInApp;
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
        

        if (timeLeft <= 180f && timeLeft >= 60f)
        {
            r = 1f;
            timerInApp.color = new Color(r,g,b,a);
            
        }
        if(timeLeft < 60f)
        {
            g = 0f;
            timerInApp.color = new Color(r, g, b, a);
        }
            
    }
    void Start()
    {

        r = 0; g = 1; b = 0; a = 1;

        BombObject.timerIsRunning = true;

        timerInApp = GameObject.Find("bike/Bomb/ModuloTiempo/Canvas/Timer").GetComponent<Text>();
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
