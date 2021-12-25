using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMapMenu : MonoBehaviour
{
    GameObject startMapItemPanel;
    public GameObject[] startMapItems;
    public Sprite[] startMapItemsImg;
    GameObject[] itemObj;
    Sprite[] itemObjImg;
    public int[] storeIdArr;
    int[] itemIdIdx;
    // Start is called before the first frame update
    void Start()
    {
        startMapItemPanel = GameObject.Find("StartMapItemPanel");
        startMapItems = GetComponent<MakeReceipt>().GetChildren(startMapItemPanel);

        itemObj = GetComponent<MakeReceipt>().totalMenuObj;
        itemIdIdx = GetComponent<MakeReceipt>().selectedMenuIndex;
        storeIdArr = GetComponent<MakeReceipt>().selectedStoreIndex;
        /*
        for (int i = 0; i < 9; i++)
        {
            startMapItemsImg[i] = startMapItems[i].GetComponent<Image>().sprite;
        }

        for( int i = 0; i< 27; i++)
        {
            itemObjImg[i] = itemObj[i].GetComponent<Image>().sprite;
        }
        */
        for (int i=0; i<itemIdIdx.Length; i++)
        {
            Debug.Log("아이템 인덱스" + itemIdIdx[i]);
        }
        SetStartMapImg();

    }

    void SetStartMapImg() {
        // index 같은 곳에 해당 이미지 넣기
        // 아닌 곳은 비활성화
        for (int i = 0; i < 9; i++)
        {
            for(int num = 0; num<storeIdArr.Length; num++)
            {
                if( i == storeIdArr[num] )
                {
                    //startMapItems[i].GetComponent<Image>().color = Color.black;
                    startMapItems[i].GetComponent<Image>().sprite = itemObj[itemIdIdx[i]].GetComponent<Image>().sprite;

                    //itemObj[itemIdIdx[i]].transform.SetParent(startMapItems[i].transform);
                }
                else
                {

                }
            }
        }


    }
}
