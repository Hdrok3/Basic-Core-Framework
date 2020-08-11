using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseTopDownMovement2D : BaseMonoBehavior
{
    public float moveXSpeed = 5f;
    public float moveYSpeed = 5f;

    public float clampX = 50f;
    public float clampY = 15f;

    BaseInputController inputController;

    bool didInit;
    bool gameStarted;

    float horizontalInput;
    float verticalinput;
    Vector2 inputVector;

    protected virtual void Start()
    {
        didInit = false;
        gameStarted = false;
        Init();

    }

    public virtual void Init()
    {
        myTransform = transform;
        myGO = gameObject;
        myBody2d = GetComponent<Rigidbody2D>();

        inputController = myGO.AddComponent<KeyboardInput>();

        didInit = true;

        // Delete This later
        gameStarted = true;
    }

    public virtual void GameStart()
    {
        gameStarted = true;
    }

    // Burasi silinecek yuksek ihtimalle.
    public virtual void Update()
    {
        UpdateCharacter();
    }

    public virtual void UpdateCharacter()
    {
        if (!didInit) return;
        if (!gameStarted) return;

        CheckInput();

        Vector2 newPosition;
        newPosition.x = Mathf.Lerp(transform.position.x, transform.position.x + inputVector.x, Time.deltaTime * moveXSpeed);
        newPosition.y = Mathf.Lerp(transform.position.y, transform.position.y + inputVector.y, Time.deltaTime * moveYSpeed);

        myBody2d.MovePosition(newPosition);
    }

    protected virtual void CheckInput()
    {
        horizontalInput = inputController.GetHorizontal();
        verticalinput = inputController.GetVertical();

        inputVector = Vector2.zero;
        inputVector = new Vector2(horizontalInput, verticalinput).normalized;
    }
}
