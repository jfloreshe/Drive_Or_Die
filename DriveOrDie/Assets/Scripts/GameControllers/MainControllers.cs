using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControllers
{
    
    MenuController menu;
    MovementController player;
    public MainControllers() { 
        menu = new MenuController();
        player = new MovementController();
    }

    public void checkUserInputs()
    {
        menu.checkUserInput();
        player.applyAcceleration();
        player.checkUserInput();
    }
    
}
