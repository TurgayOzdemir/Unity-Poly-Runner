using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;

    private LevelDataTransmitter _levelDataTransmitter;

    public int CoinCount = 0;
    public int TotalCoinCount = 0;

    public bool HasKey = false;

    private void Awake()
    {
        _levelDataTransmitter =gameManager.GetComponent<LevelDataTransmitter>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            CoinCount++;
            TotalCoinCount++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Key"))
        {
            HasKey = true;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("End"))
        {
            _levelDataTransmitter.SetIsLevelCompleted(true);
        }

    }


}
