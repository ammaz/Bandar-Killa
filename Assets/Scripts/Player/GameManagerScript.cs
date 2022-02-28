using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject VictoryPanel;
    public GameObject GameOverPanel;
    public GameObject GameplayPanel;

    public Text VictorySandalText;
    public Text EnemiesCount;
    public Text GameplayTimeLeft;

    //Change for reply
    public static bool GameOverCheck=false;
    public static bool VictoryCheck = false;

    public Text GameOverTimeText;

    //Change for reply
    private bool functionCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        //How to call functions from one script to another
        //gameManager= FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Sandal").Length == 0 && !functionCalled)
        {
            GameOver();
            functionCalled = true;
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !functionCalled)
        {
            Victory();
            functionCalled = true;
        }
    }

    public void GameOver()
    {
        GameplayPanel.SetActive(false);

        GameOverCheck = true;

        EnemiesCount.text = "" + GameObject.FindGameObjectsWithTag("Enemy").Length;
        GameOverTimeText.text = GameplayTimeLeft.text;
        GameOverPanel.SetActive(true);
    }

    public void Victory()
    {
         VictorySandalText.text = "" + GameObject.FindGameObjectsWithTag("Sandal").Length;
         GameplayPanel.SetActive(false);

         VictoryCheck = true;

         VictoryPanel.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Replay2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Replay3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Replay4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void Replay5()
    {
        SceneManager.LoadScene("Level5");
    }
}
