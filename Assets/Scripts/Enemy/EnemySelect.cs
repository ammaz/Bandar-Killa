using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelect : MonoBehaviour
{
    public GameObject[] Enemies;

    public int RandomEnemySelect()
    {
        int num = Random.Range(0, Enemies.Length);
        return num;
    }
}
