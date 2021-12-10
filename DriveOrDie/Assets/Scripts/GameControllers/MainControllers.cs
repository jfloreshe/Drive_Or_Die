using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainControllers
{
    
    public static MenuController menu;
    public static MovementController player;
  
    public static void checkUserInputs()
    {
        menu.checkUserInput();
        player.applyAcceleration();
        player.checkUserInput();
    }
    
}
