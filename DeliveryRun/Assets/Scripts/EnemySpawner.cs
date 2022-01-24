﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameObject prefab;
    public static int enemyNumber = 10;
    
    void Start()
    {
        prefab = Resources.Load<GameObject>("Enemy");
        for(int i = 0; i<enemyNumber; i++){
            Instantiate(prefab);      
        }

        RandomLocation.CheckEnemy();
    }

}
