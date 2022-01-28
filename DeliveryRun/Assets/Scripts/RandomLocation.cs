using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour
{
    private GameObject[] enemiesRandomLocations;
    private GameObject[] itemsRandomLocations;
    private GameObject[] enemies;
    private GameObject[] items;
    private int[] enemiesLocation;
    private int[] itemsLocation;
    
    private bool flag = true;
   
    
    
    public void CheckEnemy()
    {
        enemiesRandomLocations = GameObject.FindGameObjectsWithTag("RandomEnemyLocation");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLocation = new int[enemies.Length];
       
        InitLocation(enemiesLocation);
        SelectLocation(enemies, enemiesRandomLocations, enemiesLocation);
        
    }

    public void CheckItem(){
        itemsRandomLocations = GameObject.FindGameObjectsWithTag("RandomItemLocation");
        items = GameObject.FindGameObjectsWithTag("Item");
        itemsLocation = new int[items.Length];

        InitLocation(itemsLocation);
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
