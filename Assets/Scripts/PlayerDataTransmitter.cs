using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataTransmitter : MonoBehaviour
{
    [SerializeField] GameObject gameManager;

    private PlayerInputController _playerInputController;
    private PlayerMovementController _playerMovementController;
    private PlayerCollisionController _playerCollisionController;
    private PlayerAnimationController _playerAnimationController;

    private LevelDataTransmitter _levelDataTransmitter;

    private void Awake()
    {
        _playerInputController = GetComponent<PlayerInputController>();
        _playerMovementController = GetComponent<PlayerMovementController>();
        _playerCollisionController = GetComponent<PlayerCollisionController>();
        _playerAnimationController = GetComponent<PlayerAnimationController>();
        _levelDataTransmitter = gameManager.GetComponent<LevelDataTransmitter>();
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

    public int GetTotalCoinCount()
    {
        return _playerCollisionController.TotalCoinCount;
    }
    
    public int GetCoinCount()
    {
        return _playerCollisionController.CoinCount;
    }

    public bool GetHasKey()
    {
        return _playerCollisionController.HasKey;
    }

    public void Dancing()
    {
        _playerAnimationController.Dancing();
    }

    public void Dying()
    {
        _playerAnimationController.Dying();
    }

    public void setHeartCount(int health)
    {
        _levelDataTransmitter.setHeartCount(health);
    }



}
