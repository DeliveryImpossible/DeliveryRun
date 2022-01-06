using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnIcon : MonoBehaviour
{

    private SelectIndex selectIndex;

    float angle = 0f;
    GameObject[] turningObjs;
    private void Awake()
    {
        selectIndex = GetComponent<SelectIndex>();
    }

    private void Start()
    {
        angle = 0f;
    }

    void Update()
    {
        angle += 1f;
        for (int i = 0; i < turningObjs.Length; i++)
        {
            turningObjs[i].transform.GetChild(0).rotation = Quaternion.Euler(0, angle, 0)
;
        }
        angle %= 360f;
    }

    public void CheckIndexItems()
    {
        turningObjs = GameObject.FindGameObjectsWithTag(selectIndex.index.ToString());
    }
}
