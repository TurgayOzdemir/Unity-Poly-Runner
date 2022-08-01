using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataTransmitter : MonoBehaviour
{
    private PlayerInputController _playerInputController;
    private PlayerMovementController _playerMovementController;

    private void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
        _playerMovementController = GetComponent<PlayerMovementController>();
    }

    public float GetPlayerHorizontalMovementAxis()
    {
        return _playerInputController.HorizontalMovementAxis;
    }

    public bool GetPlayerIsJump()
    {
        return _playerInputController.IsJump;
    }

    public float GetPlayerHorizontalSpeed()
    {
        return _playerMovementController.HorizontalSpeed;
    }

    public void SetPlayerHorizontalSpeed(float speed)
    {
        _playerMovementController.HorizontalSpeed = speed;
    }
    public float GetPlayerVerticalSpeed()
    {
        return _playerMovementController.VerticalSpeed;
    }

    public void SetPlayerVerticalSpeed(float speed)
    {
        _playerMovementController.VerticalSpeed = speed;
    }
}
