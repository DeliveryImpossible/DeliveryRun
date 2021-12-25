using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDeliverZone : MonoBehaviour
{
    public GameObject player;
    public GameObject[] totalStoreObj;
    Vector3[] totalStorePos;
    Vector3 playerPos;
    int distancePlayerToStore;

    public Button Deliverbtn;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        MakeStorePos();
    }

    void Update()
    {
        playerPos = player.gameObject.transform.position;

        if (isDeliverZone(playerPos))
        {
            Deliverbtn.interactable = true;
        }
        else
        {
            Deliverbtn.interactable = false;
        }
    }

    public void MakeStorePos()
    {
        MakeReceipt makeReceipt = gameObject.GetComponent<MakeReceipt>();
        Debug.Log("왜 범위 밖이니" + makeReceipt.totalStoreObj.Length);
        totalStorePos = new Vector3[9];
        for (int i = 0; i < 9; i++)
        {
            totalStorePos[i] = totalStoreObj[i].gameObject.transform.position;
        }
    }

    public bool isDeliverZone(Vector3 playerPos)
    {
        bool flag = false;
        float distance;
        foreach (Vector3 tg in totalStorePos)
        {
            distance = Vector3.Distance(tg, playerPos);
            if (distance < distancePlayerToStore)
            {
                flag = true;
                break;
            }
        }
        if (flag) return true;
        else return false;
    }
}
