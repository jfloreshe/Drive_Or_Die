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
        _currentState = State.RUN;
    }
    private State getCurrentState()
    {
        return _currentState;
    }
    private void setCurrentState(State state_)
    {
        _currentState = state_;
    }
    private void openMenu()
    {
        Time.timeScale = 0;
        setCurrentState(State.PAUSE);
    }
    private void closeMenu()
    {
        Time.timeScale = 1;
        setCurrentState(State.RUN);
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
            Debug.Log("my current state is " + getCurrentState());
        }
    }
}
