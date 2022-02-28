using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject LevelPanel;
    public GameObject SettingPanel;

    //For Volume
    public AudioSource Volume;
    public Slider volumeSlider;

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
        SettingPanel.SetActive(false);
        MainPanel.SetActive(true);     
    }

    public void SetVolume()
    {
        Volume.volume=volumeSlider.value;
    }

    public void Setting()
    {
        SettingPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void Level5()
    {
        SceneManager.LoadScene("Level5");
    }


}
