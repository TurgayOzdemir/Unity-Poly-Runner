using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataTransmitter : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private LevelController _levelController;
    private UIController _uiController;
    private PlayerDataTransmitter _playerDataTransmitter;

    private void Awake()
    {
        _levelController = GetComponent<LevelController>();
        _uiController = GetComponent<UIController>();
        _playerDataTransmitter = player.GetComponent<PlayerDataTransmitter>();
    }

    public bool GetIsLevelCompleted() {
        return _levelController.IsLevelCompleted; 
    }
    
    public void SetIsLevelCompleted(bool val)
    {
        _levelController.IsLevelCompleted = val;
    }

    public void EndOfLevel(int starCount, float beginningTime, float givingStarTime)
    {
        _uiController.EndOfLevel(starCount, beginningTime, givingStarTime);
    }

    public int GetCoinCount()
    {
        return _playerDataTransmitter.GetCoinCount();
    }
}
