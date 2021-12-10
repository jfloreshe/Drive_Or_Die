using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_InGameMenu : MonoBehaviour
{
    public GameObject InGameMenu;
    void Start()
    {
        InGameMenuButton();
    }
    void Update()
    {
        MainControllers.menu.checkUserInput();
    }

    public void PlayButton(int totalGameTime)
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        InGameMenu.SetActive(false);
        MainControllers.menu.closeMenu();
    }
    public void InGameMenuButton()
    {
        // Show Main Menu
        InGameMenu.SetActive(true);
    }
    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}
