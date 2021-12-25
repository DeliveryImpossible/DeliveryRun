using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBombZone : MonoBehaviour
{
    GameObject player;
    GameObject[] item;
    GameObject[] enemy;
    Vector3 playerPosition;
    Vector3[] itemPosition;
    Vector3[] enemyPosition;
    

    void BombInit()
    {
        player = GameObject.FindGameObjectWithTag("Player");

       item = GameObject.FindGameObjectsWithTag("Item");
       itemPosition = new Vector3[item.Length];

       enemy = GameObject.FindGameObjectsWithTag("Enemy");
       enemyPosition = new Vector3[enemy.Length];

    }

    public void BombZone(){        
        BombInit();
        playerPosition = player.gameObject.transform.position;

        CheckInsideBombZone(itemPosition, item);
        CheckInsideBombZone(enemyPosition, enemy);
    }


    public void CheckInsideBombZone(Vector3[] position, GameObject[] objectArray){
        float bombDistroyRadius = 5f;
        
        for(int i = 0; i<objectArray.Length; i++){
            float distance = Vector3.Distance(playerPosition, objectArray[i].gameObject.transform.position);
            if(distance < bombDistroyRadius){
                Destroy(objectArray[i]);
            }
        }
    }
}
