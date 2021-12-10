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
        InitialMenuButton();
    }

    public void PlayButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        InitialMenu.SetActive(false);
        DifficultyMenu.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Drive");
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
