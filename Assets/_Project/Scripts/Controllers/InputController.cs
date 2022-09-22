using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : ControllerBaseModel
{
    public static bool IsTouchActive;

    public override void ControllerUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsTouchActive = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsTouchActive = false;
        }
    }

}
