using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private PlayerDataTransmitter _playerDataTransmitter;
    private Animator _animator;


    private void Awake()
    {
        _playerDataTransmitter = GetComponent<PlayerDataTransmitter>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("isMove", checkMovement() );
    }

    private bool checkMovement()
    {
        if (_playerDataTransmitter.GetPlayerVerticalSpeed() != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Dancing()
    {
        _animator.SetBool("isLevelCompleted", true);
    }

    public void Dying()
    {
        _animator.SetBool("isObstacle", true);

    }


}
