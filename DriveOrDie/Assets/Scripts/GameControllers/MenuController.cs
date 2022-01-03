using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : Controller
{
    // Start is called before the first frame update
    public enum State { RUN, PAUSE };
    private State _currentState;
    public MenuController()
    {
        Debug.Log("Menu has been created");
        Time.timeScale = 1;
        setCurrentState(State.RUN);

    }
    private State getCurrentState()
    {
        return _currentState;
    }
    private void setCurrentState(State state_)
    {
        _currentState = state_;
    }
    public void openMenu()
    {
        Time.timeScale = 0;
        setCurrentState(State.PAUSE);
        UnityEngine.SceneManagement.SceneManager.LoadScene("InGameMenu");
    }
    public void closeMenu()
    {
        Time.timeScale = 1;
        setCurrentState(State.RUN);
        //like we are not saving position reset speeds
        BombObject.module1Velocity = 0f;
        BombObject.module2Velocity = 0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Drive");
    }
    public void checkUserInput()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            State currentState = getCurrentState();
            if (currentState == State.RUN)
            {
                openMenu();
            }
            else if (currentState == State.PAUSE)
            {
                closeMenu();
            }
            //Debug.Log("my current state is " + getCurrentState());
        }
    }
}
