using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
         VictoryPanel.SetActive(true);
    }
}
