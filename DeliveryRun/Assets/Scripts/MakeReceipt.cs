using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;

public class MakeReceipt : MonoBehaviour
{
    public GameObject[] totalStoreObj;
    int[] selectedStoreIndex;
    public GameObject[] selectedStoreObj;
    public int[] selectedMenuIndex;

    protected int storeToDeliverNum;
    int totalStoreNum;
    int selectedMenu;

    Transform missionMenuPanel;
    public GameObject[] totalMenuObj;
    GameObject itemPanelObj;
    GameObject goodsPanel;

    GameObject startMapItemPanel;
    public GameObject[] startMapItems;

    private void Awake()
    {

        itemPanelObj = GameObject.FindGameObjectWithTag("Goods");
        goodsPanel = GameObject.FindGameObjectWithTag("GoodsPanel");
    }
    private void Start()
    {
        totalStoreNum = GetComponent<DatabaseManager>().getTotalStoreNum();
        storeToDeliverNum = NowGameMap.nowPlayingDifficulty + 2;

        selectedStoreIndex = new int[storeToDeliverNum];
        selectedMenuIndex = new int[storeToDeliverNum];
        selectedStoreObj = new GameObject[storeToDeliverNum];

        startMapItemPanel = GameObject.FindGameObjectWithTag("TargetPanel");
        startMapItems = GetChildren(startMapItemPanel);

        makeRandomStoreIndex();
        makeRandomStoreObject();
        InitStartMapImg();
        SetStartMapImg();
    }

    private void InitStartMapImg()
    {
        for(int i=0; i<9; i++)
        {
            for(int j=0; j < storeToDeliverNum; j++)
            {
                if (i == selectedStoreIndex[j])
                    startMapItems[i].SetActive(true);
            }
        }
    }
    private void SetStartMapImg()
    {
        makeRandomGoods(selectedStoreIndex);
        for (int num = 0; num < storeToDeliverNum; num++)
        {
            startMapItems[selectedStoreIndex[num]].GetComponent<Image>().sprite = totalMenuObj[selectedMenuIndex[num]].GetComponent<Image>().sprite;
            totalMenuObj[selectedMenuIndex[num]].GetComponent<Image>().transform.parent = goodsPanel.transform;
        }
        
    }

    private void makeRandomStoreObject()
    {
        totalStoreObj = GetChildren(GameObject.FindGameObjectWithTag("Target"));
        for (int i = 0; i < storeToDeliverNum; i++)
        {
            selectedStoreObj[i] = totalStoreObj[selectedStoreIndex[i]];
        }
    }

    private GameObject[] GetChildren(GameObject parent)
    {
        GameObject[] children = new GameObject[parent.transform.childCount];

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            children[i] = parent.transform.GetChild(i).gameObject;
        }

        return children;
    }

    private void makeRandomStoreIndex()
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

    private void makeRandomGoods(int [] DeliverTargetArr)
    {
        totalMenuObj = GetChildren(itemPanelObj);
        int menu = Random.Range(0, 3);

        for (int i = 0; i < storeToDeliverNum; i++)
        { 
            selectedMenu = DeliverTargetArr[i] * 3 + menu;
            selectedMenuIndex[i] = selectedMenu;
        }
    }
}
