using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject[] Sandals;
    public GameObject[] Enemies;
    public static GameObject SelectedSandal;
    //For Finding First Shortest 
    private float Distance;
    private float min = 1000;
    private int selectedEnemyIndex=0;
    //public static GameObject selectedSandal;

    /*For Finding Second Shortest 
    public static GameObject selectedSandal2;*/

    // Start is called before the first frame update
    void Start()
    {
 
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
        selectedEnemyIndex = Random.Range(0, Enemies.Length);
        int selectedSandalIndex = 0;
        for (int a = 0; a < Sandals.Length; a++)
        {
            Distance = Vector3.Distance(Sandals[a].transform.position, Enemies[selectedEnemyIndex].transform.position);
            if (Distance < min)
            {
                min = Distance;
                selectedSandalIndex = a;
            }
        }
        //Debug.Log(min);
        //Debug.Log(SelectedSandal);
        SelectedSandal = Sandals[selectedSandalIndex];
        Petroller.EnemeyGotoSandal(Enemies[selectedEnemyIndex]);
        min = 1000;
        Distance = 0;
        /*float min1 = 1000;
        float Distance1;
        for (int a = 0; a < Sandals.Length; a++)
        {
            Distance1 = Vector3.Distance(selectedSandal.transform.position, Sandals[a].transform.position);
            if (Distance1 < min1 && Distance1!=0)
            {
                min1 = Distance1;
                selectedSandal2 = Sandals[a];
            }
        }*/

        //Debug.Log(min);
        //Debug.Log(min1);
        //Debug.Log(SelectedSandal);
        //Debug.Log(selectedSandal2);
    }
}
