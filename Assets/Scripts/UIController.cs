using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] TMP_Text totalCoinCount;

    [Header("Pause Button")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject pauseImageObject;
    [SerializeField] private Sprite playIcon;
    [SerializeField] private Sprite pauseIcon;
    private Image _pauseIcon;

    [Header("End Screen")]
    [SerializeField] private GameObject EndGamePanel;
    [SerializeField] private GameObject topPanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject star1;
    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject star3;
    private Image _star1;
    private Image _star2;
    private Image _star3;


    private PlayerDataTransmitter _playerDataTransmitter;
    private bool _pauseToggle = true;

    private Scene _activeScene;

    private void Awake()
    {
        _playerDataTransmitter = player.GetComponent<PlayerDataTransmitter>();
        _pauseIcon = pauseImageObject.GetComponent<Image>();
        _star1 = star1.GetComponent<Image>();
        _star2 = star2.GetComponent<Image>();
        _star3 = star3.GetComponent<Image>();
    }

    private void Start()
    {
        _activeScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        setTotalCoinCount();
    }

    private void setTotalCoinCount()
    {
        totalCoinCount.text= _playerDataTransmitter.GetTotalCoinCount().ToString();
    }

    private IEnumerator starAnimation(int starCount, float beginningTime, float givingStarTime)
    {
        Image[] stars = {_star1,_star2,_star3};
        yield return new WaitForSeconds(beginningTime);
        for (int i = 0; i < starCount; i++)
        {
            stars[i].color = new Color(255, 255, 255, 255);
            yield return new WaitForSeconds(givingStarTime);
        }

    }

    public void EndOfLevel(int starCount, float beginningTime, float givingStarTime)
    {
        EndGamePanel.SetActive(true);
        topPanel.SetActive(false);
        pauseButton.SetActive(false);
        StartCoroutine(starAnimation(starCount, beginningTime, givingStarTime));

    }

    public void PauseButtonOnClick()
    {
        if (_pauseToggle)
        {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        _pauseIcon.sprite = playIcon;
        _pauseToggle = false;
        }
        else
        {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        _pauseIcon.sprite = pauseIcon;
        _pauseToggle = true;
        }
    }

    public void CircleExitButtonOnClick()
    {
        if (!_pauseToggle)
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            _pauseIcon.sprite = pauseIcon;
            _pauseToggle = true;
        }
        else
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(false);
            _pauseIcon.sprite = playIcon;
            _pauseToggle = false;
        }
    }

    public void NextLevelButtonOnClick()
    {

    }

    public void RestartButtonOnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }

    public void ExitButtonOnClick()
    {
        Application.Quit();
    }


}
