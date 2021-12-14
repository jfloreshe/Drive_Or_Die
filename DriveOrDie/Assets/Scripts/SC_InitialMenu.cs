using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_InitialMenu : MonoBehaviour
{
    public GameObject InitialMenu;
    public GameObject DifficultyMenu;

    // Start is called before the first frame update
    void Start()
    {
        initGlobalValues();
        InitialMenuButton();
    }

    public void initGlobalValues()
    {
        MainControllers.menu = new MenuController();
        BikeObject.velocity = BikeObject.MAX_VELOCITY;
        BombObject.timerIsRunning = false;
        BombObject.module1Timer = 50f;
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
        Debug.Log("HOLA DERECHA");
    }

    public void LeftButton()
    {
        Debug.Log("HOLA IZQUIERDA");
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
