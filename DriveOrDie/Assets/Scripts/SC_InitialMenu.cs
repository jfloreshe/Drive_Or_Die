using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_InitialMenu : MonoBehaviour
{
    public GameObject InitialMenu;
    public GameObject DifficultyMenu;
    public GameObject button5;
    public GameObject button7;
    public GameObject button10;

    // Start is called before the first frame update
    void Start()
    {
        button5 = GameObject.Find("InitialMenu/DifficultyMenu/Canvas/Button5");
        button7 = GameObject.Find("InitialMenu/DifficultyMenu/Canvas/Button7");
        button10 = GameObject.Find("InitialMenu/DifficultyMenu/Canvas/Button10");
        initGlobalValues();
        InitialMenuButton();
    }

    public void initGlobalValues()
    {
        MainControllers.menu = new MenuController();
        BikeObject.velocity = 25f;
        BikeObject.currentRoute = 0;
        BombObject.timerIsRunning = false;
        BombObject.module1Timer = 50f;
        BombObject.module2Timer = 50f;
        BombObject.module1Done = false;
        BombObject.module2Done = false;
        TaskPoolObject.taskPool = new Dictionary<string, bool>();
        AddedTasks.tasks = new Dictionary<string, bool>();
        CompletedTasks.tasks = new Dictionary<string, bool>();
        string[] tasksToAdd = { "TakeRoute","DodgeCars","FindTrafficSign"};
        string[] tasksToComplete = { "TakeRoute1", "TakeRoute2" };
        foreach(string task in tasksToAdd)
        {
            AddedTasks.tasks[task] = false;
        }
        foreach(string task in tasksToComplete)
        {
            CompletedTasks.tasks[task] = false;
        }
    }
    public void PlayButton(int totalGameTime)
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        InitialMenu.SetActive(false);
        DifficultyMenu.SetActive(false);
        BombObject.startTime = Time.time;
        TimerObject.totalTime = totalGameTime * 60;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Drive");
    }

    public void RightButton()
    {
        if (button10.activeSelf == true)
        {
            button7.SetActive(true);
            button10.SetActive(false);
        }
        else if (button7.activeSelf == true)
        {
            button5.SetActive(true);
            button7.SetActive(false);
        }
    }

    public void LeftButton()
    {
        if(button7.activeSelf == true) 
        {
            button10.SetActive(true);
            button7.SetActive(false);
        }
        else if(button5.activeSelf == true)
        {
            button7.SetActive(true);
            button5.SetActive(false);
        }
    }
    public void Play5MinButton()
    {
        PlayButton(5);
    }
    public void Play7MinButton()
    {
        PlayButton(7);
    }
    public void Play10MinButton()
    {
        PlayButton(10);
    }
    public void DifficultyButton()
    {
        // Show Credits Menu
        InitialMenu.SetActive(false);
        DifficultyMenu.SetActive(true);
        button5.SetActive(false);
        button7.SetActive(false);
        button10.SetActive(true);
    }

    public void InitialMenuButton()
    {
        // Show Main Menu
        InitialMenu.SetActive(true);
        DifficultyMenu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}
