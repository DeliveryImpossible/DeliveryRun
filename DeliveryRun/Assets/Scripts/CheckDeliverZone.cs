using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDeliverZone : MonoBehaviour
{
    public GameObject player;
    public GameObject[] totalStoreObj;
    public Vector3[] totalStorePos;
    Vector3 playerPos;
    int distancePlayerToStore = 5;
    UiActiveController uac;
    public Button Deliverbtn;

    GameObject targetManger;
    GameObject gameManager;



    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        targetManger = GameObject.FindGameObjectWithTag("TargetManager");
        player = GameObject.FindGameObjectWithTag("Player");
        uac = gameManager.GetComponent<UiActiveController>();
    }

    void Update()
    {
        //InteractDeliverBtn();
        if (uac.isStart)
        {
            playerPos = player.gameObject.transform.position;
            if (uac.isStart)
            {
                if (IsDeliverZone(playerPos))
                {
                    Deliverbtn.interactable = true;
                }
                else
                {
                    Deliverbtn.interactable = false;
                }
            }
        }

    }

    public void MakeStorePos()
    {
        MakeReceipt makeReceipt = targetManger.GetComponent<MakeReceipt>();
        totalStorePos = new Vector3[9];
        for (int i = 0; i < 9; i++)
        {
            totalStorePos[i] = makeReceipt.totalStoreObj[i].gameObject.transform.position;
        }
    }

    public void InteractDeliverBtn()
    {
        
        
    }

    public bool IsDeliverZone(Vector3 playerPos)
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
