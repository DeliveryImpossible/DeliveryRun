using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomClothing : MonoBehaviour
{
    private int cloth;
    private int cap = 3;
    private int hair;
    private int cloth_random_number;
    private int cap_random_number;
    private int hair_random_number;
    void Start()
    {
        cloth = gameObject.transform.GetChild(0).GetChild(1).GetChild(0).childCount;
        hair = gameObject.transform.GetChild(0).GetChild(2).childCount - 1;

        cloth_random_number = Random.Range(0,cloth);
        cap_random_number = Random.Range(0, cap + 1);
        hair_random_number = Random.Range(0, hair);

        gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(cloth_random_number).gameObject.SetActive(true);
        if(cap_random_number != 0){
            gameObject.transform.GetChild(0).GetChild(1).GetChild(cap_random_number).gameObject.SetActive(true);
        }
        gameObject.transform.GetChild(0).GetChild(2).GetChild(hair_random_number).gameObject.SetActive(true);
    }
}
