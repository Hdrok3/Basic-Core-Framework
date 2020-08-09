using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInputController : MonoBehaviour
{
    public bool Up;
    public bool Down;
    public bool Right;
    public bool Left;

    public float horizontal;
    public float vertical;

    public bool Fire1;

    protected abstract void CheckInput();
    public virtual float GetHorizontal() => horizontal;
    public virtual float GetVertical() => vertical;
    public virtual bool GetFire() => Fire1;
    public virtual Vector3 GetMovementDirectionVector3()
    {
        return new Vector3(horizontal, vertical, 0);
    }
}
