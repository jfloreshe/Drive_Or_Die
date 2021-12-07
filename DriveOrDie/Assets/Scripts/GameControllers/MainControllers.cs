using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControllers
{
    
    MenuController menu;
    public MainControllers() { 
        menu = new MenuController();
    }

    public void checkUserInputs()
    {
        menu.checkUserInput();
    }
    
}
