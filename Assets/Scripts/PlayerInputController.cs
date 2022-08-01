using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{

    private PlayerInput _playerInput;
    private InputAction _jumpAction;


    [HideInInspector] public float HorizontalMovementAxis = 0;
    [HideInInspector] public bool IsJump = false;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _jumpAction = _playerInput.actions["Jump"];
    }

    private void OnEnable()
    {
        _jumpAction.started += _ => jumpButtonDown();
        _jumpAction.canceled += _ => jumpButtonUp();
    }

    private void OnDisable()
    {
        _jumpAction.started -= _ => jumpButtonDown();
        _jumpAction.canceled -= _ => jumpButtonUp();
    }


    private void jumpButtonDown()
    {
        IsJump = true;
    }
    private void jumpButtonUp()
    {
        IsJump = false;
    }

    private void OnMove(InputValue value)
    {
        HorizontalMovementAxis = value.Get<float>();
    }
}
