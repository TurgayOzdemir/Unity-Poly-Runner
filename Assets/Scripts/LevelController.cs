using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [HideInInspector] public bool IsLevelCompleted = false;

    [SerializeField] private GameObject player;

    [SerializeField] private float waitSecondAfterStop = 2;
    [SerializeField] private float waitSecondAfterPanel = 2;
    [SerializeField] private float waitSecondBetweenStar = 0.75f;

    private PlayerDataTransmitter _playerDataTransmitter;
    private LevelDataTransmitter _levelDataTransmitter;

    private IEnumerator endOfLevel(int starCount, float waitSecondAfterStop, float waitSecondAfterPanel, float waitSecondBetweenStar)
    {
        _playerDataTransmitter.SetPlayerVerticalSpeed(0);
        _playerDataTransmitter.SetPlayerHorizontalSpeed(0);
        yield return new WaitForSeconds(waitSecondAfterStop);
        _levelDataTransmitter.EndOfLevel(starCount, waitSecondAfterPanel, waitSecondBetweenStar);
    }

    private void Awake()
    {
        _playerDataTransmitter = player.GetComponent<PlayerDataTransmitter>();
        _levelDataTransmitter = GetComponent<LevelDataTransmitter>();
    }

    private void Update()
    {
        if (IsLevelCompleted)
        {
            StartCoroutine(endOfLevel(_levelDataTransmitter.GetCoinCount(), waitSecondAfterStop, waitSecondAfterPanel, waitSecondBetweenStar));
            IsLevelCompleted = false;
        }
        
    }
}
