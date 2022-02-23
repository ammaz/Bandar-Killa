using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject[] Sandals;
    private GameObject[] Enemies;

    public static GameObject SelectedSandal;

    //For Finding First Shortest 
    private float Distance;
    private float min = 1000;


    private int selectedEnemyIndex;
    private int RandomE=0;

    //private bool OnlyOnce=false;
    //public static GameObject selectedSandal;

    /*For Finding Second Shortest 
    public static GameObject selectedSandal2;*/

    // Start is called before the first frame update
    void Start()
    {
        Sandals = GameObject.FindGameObjectsWithTag("Sandal");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            CalculateShortDistance();
            //RandomEnemySelect();
            //ChooseRandomSandle();
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
    
    void CalculateShortDistance()
    {
        //Choosing Random Enemy who will pick the sandal
        while (selectedEnemyIndex == RandomE)
        {
            RandomE = Random.Range(0, Enemies.Length);
        }

        if (selectedEnemyIndex != RandomE)
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

            //Reseting Min Distance Value
            min = 1000;
        }         
    }             
}