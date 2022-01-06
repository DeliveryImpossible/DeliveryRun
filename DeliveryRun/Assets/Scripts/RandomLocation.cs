using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour
{
    static GameObject[] enemiesRandomLocations;
    static GameObject[] itemsRandomLocations;
    static GameObject[] enemies;
    static GameObject[] items;
    static int[] enemiesLocation;
    static int[] itemsLocation;
    
    static bool flag = true;
   
    
    
    public static void CheckEnemy()
    {
        enemiesRandomLocations = GameObject.FindGameObjectsWithTag("RandomEnemyLocation");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLocation = new int[enemies.Length];
       
        InitLocation(enemiesLocation);
        SelectLocation(enemies, enemiesRandomLocations, enemiesLocation);
        
    }

    public static void CheckItem(){
        itemsRandomLocations = GameObject.FindGameObjectsWithTag("RandomItemLocation");
        items = GameObject.FindGameObjectsWithTag("Item");
        itemsLocation = new int[items.Length];

        InitLocation(itemsLocation);
        SelectLocation(items, itemsRandomLocations, itemsLocation);
    }

    static void InitLocation(int[] locations){
        for(int i = 0; i< locations.Length; i++){
            locations[i] = -1;
        }
    }

    static void SelectLocation(GameObject[] objectArray, GameObject[] randomLocations, int[] selectedLocations){
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

    static void TransferLocation(GameObject[] objectArray, GameObject[] randomLocations, int[] selectedLocations){
        for(int i = 0; i< objectArray.Length; i++){
            objectArray[i].transform.position = randomLocations[selectedLocations[i]].transform.position;
        }
    }

}
