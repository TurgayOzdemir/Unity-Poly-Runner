using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelController : MonoBehaviour
{
    [HideInInspector] public bool IsLevelCompleted = false;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject chestTop;

    [SerializeField] private float waitSecondAfterStop = 2;
    [SerializeField] private float waitSecondAfterPanel = 1;
    [SerializeField] private float waitSecondBetweenStar = 0.75f;

    private PlayerDataTransmitter _playerDataTransmitter;
    private LevelDataTransmitter _levelDataTransmitter;

    private int _starCount = 1;

    private IEnumerator endOfLevel(int starCount, float waitSecondAfterStop, float waitSecondAfterPanel, float waitSecondBetweenStar)
    {
        _playerDataTransmitter.SetPlayerVerticalSpeed(0);
        _playerDataTransmitter.SetPlayerHorizontalSpeed(0);
        yield return new WaitForSeconds(waitSecondAfterStop);
        chestOpening();
        _levelDataTransmitter.Dancing();
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

            if (_levelDataTransmitter.getHasKey())
            {
                _starCount++;
            }

            if (_levelDataTransmitter.GetCoinCount() >= 10)
            {
                _starCount++;
            }

            StartCoroutine(endOfLevel(_starCount, waitSecondAfterStop, waitSecondAfterPanel, waitSecondBetweenStar));
            IsLevelCompleted = false;
        }
        
    }

    private void chestOpening()
    {
        chestTop.transform.DORotate(new Vector3(0, chestTop.transform.rotation.y, chestTop.transform.rotation.z), 1);
    }
}
