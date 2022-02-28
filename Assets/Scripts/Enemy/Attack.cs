using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    //Change for reply
    private GameObject[] Sandals;
    private GameObject[] Enemies;

    public static GameObject SelectedSandal;

    //For Finding First Shortest 
    private float Distance;
    private float min = 1000;


    private int selectedEnemyIndex;
    private int RandomE=0;

    //For Sandal Text
    public Text SandalCount;

    //Attack function running
    private bool AttackFuncRunning=false;

    //private bool OnlyOnce=false;
    //public static GameObject selectedSandal;

    /*For Finding Second Shortest 
    public static GameObject selectedSandal2;*/

    // Start is called before the first frame update
    void Start()
    {
        Sandals = GameObject.FindGameObjectsWithTag("Sandal");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        SandalCount.text = ""+Sandals.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Calling Enemy
        /*if (Input.GetButtonDown("Horizontal"))
        {
            CalculateShortDistance();
            //RandomEnemySelect();
            //ChooseRandomSandle();
        }*/

        if (AttackFuncRunning == false && (!GameManagerScript.VictoryCheck || !GameManagerScript.GameOverCheck))
        {
            StartCoroutine(CalculateShortDistance());
        }

        //Updating Sandal Text
        if (int.Parse(SandalCount.text) != GameObject.FindGameObjectsWithTag("Sandal").Length)
        {
            SandalCount.text = "" + GameObject.FindGameObjectsWithTag("Sandal").Length;
        }
    }

    /// <summary>
    /// In for loop "Random.Range(1,4)" --> Selects how many Chapals it want to target and loops run for that amount of iterations
    /// In "Sandals[Random.Range(0, Sandals.Length)]" --> It randomaly selects the chapals from 0-Sandals Amount
    /// In "GetComponent<Renderer>().material.SetColor("_Color", Color.green);" It changes color of selected Chapals.
    /// </summary>

    /*void ChooseRandomSandle()
    {
        int HowManySandals = Random.Range(1,4);
        bool OnlyOnce=true;
        for(int a = 0; a < HowManySandals; a++)
        {
            int Rand = Random.Range(0, Sandals.Length);
            Sandals[Rand].GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            if (OnlyOnce)
            {
                SelectedSandal = Sandals[Rand];
                //Petroller.EnemeyGotoSandal();
                OnlyOnce = false;
            }
        }

    }*/

    /*void RandomEnemySelect()
    {
        selectedEnemyIndex = Random.Range(0, Enemies.Length);
        Petroller.EnemeyGotoSandal(Enemies[selectedEnemyIndex]);
    }*/
    
    IEnumerator CalculateShortDistance()
    {
        AttackFuncRunning = true;

        //Here I can change Range based of difficulty
        yield return new WaitForSeconds(Random.Range(5,10));

        if (GameManagerScript.VictoryCheck || GameManagerScript.GameOverCheck)
            yield break;

        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //Choosing Random Enemy who will pick the sandal
        if (Enemies.Length != 1)
        {
            while (selectedEnemyIndex == RandomE)
            {
                RandomE = Random.Range(0, Enemies.Length);
            }
        }

        else
        {
            RandomE = 0;
        }
        

        if (!GameManagerScript.VictoryCheck || !GameManagerScript.GameOverCheck)
        {
            selectedEnemyIndex = RandomE;

            //Reseting Selected Sandal Index
            int selectedSandalIndex = 0;

            //Loop to find minimum distance to choose the nearest sandal
            for (int a = 0; a < Sandals.Length; a++)
            {
                if (Sandals[a] != null)
                {
                    Distance = Vector3.Distance(Sandals[a].transform.position, Enemies[selectedEnemyIndex].transform.position);
                    if (Distance < min)
                    {
                        min = Distance;
                        selectedSandalIndex = a;
                    }
                }
            }

            //Setting SelectedSandal for the player to chase it
            SelectedSandal = Sandals[selectedSandalIndex];
            Sandals[selectedSandalIndex] = null;
            Petroller.EnemeyGotoSandal(Enemies[selectedEnemyIndex]);

            //Changing color of selected sandal
            SelectedSandal.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

            min = 1000;
        }
        AttackFuncRunning = false;
    }
}
