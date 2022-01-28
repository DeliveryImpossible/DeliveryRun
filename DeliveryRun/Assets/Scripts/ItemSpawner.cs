using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    GameObject bomb;
    GameObject booster;
    GameObject coin;
    GameObject increaseTime;
    GameObject skull;

    int bombNumber = 3;
    int boosterNumber = 4;
    int coinNumber = 6;
    int increaseTimeNumber = 4;
    int skullNumber = 6;

    
    void Start()
    {
        bomb = Resources.Load<GameObject>("Bomb");
        booster = Resources.Load<GameObject>("Booster");
        coin = Resources.Load<GameObject>("Coin");
        increaseTime = Resources.Load<GameObject>("IncreaseTime");
        skull = Resources.Load<GameObject>("Skull");

        Instantiation(bomb, bombNumber);
        Instantiation(booster, boosterNumber);
        Instantiation(coin, coinNumber);
        Instantiation(increaseTime, increaseTimeNumber);
        Instantiation(skull, skullNumber);
    }

    private void Instantiation(GameObject gameObject, int n){
        for(int i = 0; i< n ; i++){
            Instantiate(gameObject, transform.position, transform.rotation);
        }
        
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<RandomLocation>().CheckItem();
    }

    
}
