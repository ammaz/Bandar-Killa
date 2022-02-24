using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject LevelPanel;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Play()
    {
        MainPanel.SetActive(false);
        LevelPanel.SetActive(true);
    }

    public void Home()
    {
        LevelPanel.SetActive(false);
        MainPanel.SetActive(true);     
    }
}
