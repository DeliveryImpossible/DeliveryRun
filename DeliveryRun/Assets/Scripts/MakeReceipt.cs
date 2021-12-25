using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;

//영수증 생성
public class MakeReceipt : MonoBehaviour
{
    public GameObject[] totalStoreObj;
    public int[] selectedStoreIndex;
    public GameObject[] selectedStoreObj;
    public int[] selectedMenuIndex;

    int storeToDeliverNum;
    int totalStoreNum;
    
    public GameObject[] menuPanel;
    public Transform missionMenuPanel;
    public GameObject[] totalMenuObj;

    private void Start()
    {
        totalStoreNum = GetComponent<DatabaseManager>().getTotalStoreNum();
        storeToDeliverNum = NowGameMap.nowPlayingDifficulty + 2;

        selectedStoreIndex = new int[storeToDeliverNum];
        selectedMenuIndex = new int[storeToDeliverNum];
        selectedStoreObj = new GameObject[storeToDeliverNum];
        
        makeRandomStoreIndex();
        makeRandomStoreObject();
        makeRandomGoods(selectedStoreIndex);
        
    }

    private void makeRandomStoreObject()
    {
        totalStoreObj = GetChildren(GameObject.FindGameObjectWithTag("Target"));
        for (int i = 0; i < storeToDeliverNum; i++)
        {
            selectedStoreObj[i] = totalStoreObj[selectedStoreIndex[i]];
        }
        Debug.Log("MR에서 .. " + totalStoreObj.Length);
    }

    public GameObject[] GetChildren(GameObject parent)
    {
        GameObject[] children = new GameObject[parent.transform.childCount];

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            children[i] = parent.transform.GetChild(i).gameObject;
        }

        return children;
    }

    public void makeRandomStoreIndex() // 랜덤으로 가게 인덱스 뽑기
    {
        bool isSame;
        for (int i = 0; i < storeToDeliverNum; i++)
        {
            while (true)
            {
                selectedStoreIndex[i] = Random.Range(0, totalStoreNum);
                isSame = false;

                for (int j = 0; j < i; j++)
                {
                    if (selectedStoreIndex[j] == selectedStoreIndex[i])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame) break;
            }
        }
    }
    
    public void makeRandomGoods(int [] DeliverTargetArr)
    {
        totalMenuObj = GetChildren(GameObject.FindGameObjectWithTag("Goods"));
        int menu = Random.Range(0, 3);

        for (int i = 0; i < storeToDeliverNum; i++)
        { 
            int selectedMenu = DeliverTargetArr[i] * 3 + menu;
            selectedMenuIndex[i] = selectedMenu;
            totalMenuObj[selectedMenu].transform.SetParent(missionMenuPanel);
            menuPanel[DeliverTargetArr[i]].GetComponent<Image>().sprite = totalMenuObj[selectedMenuIndex[i]].GetComponent<Image>().sprite;
        }
    }
}
