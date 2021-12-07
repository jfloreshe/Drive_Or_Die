using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    public MainControllers controllers;
    void Start()
    {
        controllers = new MainControllers();
    }

    // Update is called once per frame
    void Update()
    {
        controllers.checkUserInputs();
    }
}
