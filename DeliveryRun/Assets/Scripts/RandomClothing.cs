using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomClothing : MonoBehaviour
{
    private int random_number;
    private int cloth;
    void Start()
    {
        cloth = gameObject.transform.GetChild(0).GetChild(1).GetChild(0).childCount;
        random_number = Random.Range(0,cloth);
        gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(random_number).gameObject.SetActive(true);
    }
}
