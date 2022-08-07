using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathController : MonoBehaviour
{
    private PlayerDataTransmitter _playerDataTransmitter;
    private int _health = 3;

    private void Awake()
    {
        _playerDataTransmitter = GetComponent<PlayerDataTransmitter>();
    }

    private IEnumerator DyingAnimation()
    {
        _playerDataTransmitter.SetPlayerVerticalSpeed(0);
        _playerDataTransmitter.SetPlayerHorizontalSpeed(0);
        _playerDataTransmitter.Dying();
        yield return new WaitForSeconds(5);
        _health--;
        PlayerPrefs.SetInt("HEALTH", _health);
        healthCheck();
    }
    

    private void Update()
    {
        if (gameObject.transform.position.y < -15f)
        {
            _health--;
            PlayerPrefs.SetInt("HEALTH",_health);
            healthCheck();
        }

        _health = PlayerPrefs.GetInt("HEALTH");
        _playerDataTransmitter.setHeartCount(_health);
    }

    private void healthCheck()
    {
        if (_health > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("Level1");
            _health = 3;
            PlayerPrefs.SetInt("HEALTH", _health);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Saw") || other.CompareTag("Spike"))
        {
            StartCoroutine(DyingAnimation());
        }
    }

}
