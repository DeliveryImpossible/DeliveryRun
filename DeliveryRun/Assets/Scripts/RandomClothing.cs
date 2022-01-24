using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomClothing : MonoBehaviour
{
    private int random_number;
    void Start()
    {
        random_number = Random.Range(0,12);
        gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(random_number).gameObject.SetActive(true);
    }
}
