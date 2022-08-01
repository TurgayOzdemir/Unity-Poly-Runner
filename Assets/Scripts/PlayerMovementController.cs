using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private PlayerDataTransmitter _playerDataTransmitter;
    private CharacterController _characterController;

    private Vector3 _playerVelocity;
    private bool _groundedPlayer;


    public float HorizontalSpeed = 5f;
    public  float VerticalSpeed = 5f;

    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerDataTransmitter = GetComponent<PlayerDataTransmitter>();
    }

    void Update()
    {

        setIsGrounded();

        playerMove();

        playerJump();

    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * VerticalSpeed * Time.fixedDeltaTime);
    }




    private void playerMove()
    {

        Vector3 move = new Vector3(_playerDataTransmitter.GetPlayerHorizontalMovementAxis(), 0, 0);
        _characterController.Move(move * Time.deltaTime * HorizontalSpeed);

        

        
    }

    private void setIsGrounded()
    {
        _groundedPlayer = _characterController.isGrounded;

        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }
    }

    private void playerJump()
    {
        if (_playerDataTransmitter.GetPlayerIsJump() && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        _playerVelocity.y += gravityValue * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }
}
