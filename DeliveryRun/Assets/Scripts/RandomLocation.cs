using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour
{
    GameObject[] enemiesRandomLocations;
    GameObject[] itemsRandomLocations;
    GameObject[] enemies;
    GameObject[] items;
    int[] enemiesLocation;
    int[] itemsLocation;
    
    bool flag = true;
   
    
    
    void Start()
    {
        enemiesRandomLocations = GameObject.FindGameObjectsWithTag("RandomEnemyLocation");
        itemsRandomLocations = GameObject.FindGameObjectsWithTag("RandomItemLocation");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        items = GameObject.FindGameObjectsWithTag("Item");

        enemiesLocation = new int[enemies.Length];
        itemsLocation = new int[items.Length];

        InitLocation(enemiesLocation);
        InitLocation(itemsLocation);

        SelectLocation(enemies, enemiesRandomLocations, enemiesLocation);
        SelectLocation(items, itemsRandomLocations, itemsLocation);
    }

    void InitLocation(int[] locations){
        for(int i = 0; i< locations.Length; i++){
            locations[i] = -1;
        }
    }

    void SelectLocation(GameObject[] objectArray, GameObject[] randomLocations, int[] selectedLocations){
        for(int i = 0; i < objectArray.Length; i++){
            int randomNumber = Random.Range(0, randomLocations.Length);
            
            for(int j = 0; j < i; j++){
                if(selectedLocations[j] == randomNumber){
                    i--;
                    flag = false;
                    break;
                }
            }
            
            if(flag){
                selectedLocations[i] = randomNumber;
            }else{
                flag = true;
            }
        }

        TransferLocation(objectArray, randomLocations, selectedLocations);
    }

    void TransferLocation(GameObject[] objectArray, GameObject[] randomLocations, int[] selectedLocations){
        for(int i = 0; i< objectArray.Length; i++){
            objectArray[i].transform.position = randomLocations[selectedLocations[i]].transform.position;
        }
    }

}
