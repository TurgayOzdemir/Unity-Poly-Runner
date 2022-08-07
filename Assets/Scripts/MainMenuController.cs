using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject creditPanel;
    [SerializeField] private GameObject levels;

    public void playGameButtonOnClick()
    {
        buttons.SetActive(false);
        levels.SetActive(true);
    }

    public void creditButtonOnClick()
    {
        buttons.SetActive(false);
        creditPanel.SetActive(true);
    }

    public void quitGameButtonOnClick()
    {
        Application.Quit();
    }

    public void creditBackButtonOnClick()
    {
        creditPanel.SetActive(false);
        buttons.SetActive(true);
    }

    public void levelBackButtonOnClick()
    {
        levels.SetActive(false);
        buttons.SetActive(true);
    }

    public void level1ButtonOnClick()
    {
        SceneManager.LoadScene("Level1");
        PlayerPrefs.SetInt("LEVEL", 1);
    }

    public void level2ButtonOnClick()
    {
        SceneManager.LoadScene("Level2");
        PlayerPrefs.SetInt("LEVEL", 2);
    }

    public void level3ButtonOnClick()
    {
        SceneManager.LoadScene("Level3");
        PlayerPrefs.SetInt("LEVEL", 3);
    }

    public void level4ButtonOnClick()
    {
        SceneManager.LoadScene("Level4");
        PlayerPrefs.SetInt("LEVEL", 4);
    }

    public void level5ButtonOnClick()
    {
        SceneManager.LoadScene("Level5");
        PlayerPrefs.SetInt("LEVEL", 5);
    }

    public void level6ButtonOnClick()
    {
        SceneManager.LoadScene("Level6");
        PlayerPrefs.SetInt("LEVEL", 6);
    }
}
