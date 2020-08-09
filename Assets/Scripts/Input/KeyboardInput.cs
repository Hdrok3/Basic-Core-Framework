using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardInput : BaseInputController
{
    protected override void CheckInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Up      = vertical > 0;
        Down    = vertical < 0;
        Right   = horizontal > 0;
        Left    = horizontal < 0;

        Fire1 = Input.GetButton("Fire1");
    }

    void Update()
    {
        CheckInput();
    }
}
