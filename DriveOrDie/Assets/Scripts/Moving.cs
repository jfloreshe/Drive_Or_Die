using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    void Start()
    {
        MainControllers.player = new MovementController();
    }

    // Update is called once per frame
    void Update()
    {
        MainControllers.checkUserInputs();
    }
}
