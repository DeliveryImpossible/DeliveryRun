using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemIndexInfo;

//플레이어가 가진 아이템 인벤토리에 로드
public class LoadItems : MonoBehaviour
{
    const int inventoryWidth = 380;
    const int inventoryHeightOri = 400;
    const int goodsMaxWatch = 9;
    const int goodsOneLine = 3;

    private GameObject[] goods;
    public GameObject inventorySlotBox;  //인벤토리 내부
    public GameObject itemInitPosition;  //아이템들 제자리  

    private int inventoryHeight = 400;

    private void Start()
    {
        inventoryHeight = 400;
    }

    public virtual void Refresh() { }

    //물건 위치 초기화
    public void ResetGoods(int indexNumToReset)
    {
        goods = GameObject.FindGameObjectsWithTag(ItemIndex.itemsIndexString[indexNumToReset]);
        for (int i = 0; i < goods.Length; i++)
        {
            goods[i].transform.SetParent(itemInitPosition.transform.GetChild(ItemIndex.itemsIndexInt[indexNumToReset]));
            goods[i].transform.position = new Vector3(-1000, 0, 0);
        }
    }

    //아이템 개수에 맞춰 인벤토리 확장 메소드
    public void ExpandInventory()
    {
        if (inventorySlotBox.transform.childCount > goodsMaxWatch)
        {
            {
                int goodsNeedExpand = goods.Length - goodsMaxWatch;
                for (; goodsNeedExpand > 0; goodsNeedExpand -= goodsOneLine)
                {
                    inventorySlotBox.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(inventoryWidth, inventoryHeight += 130);
                }
            }
        }
        else
        {
            inventorySlotBox.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(inventoryWidth, inventoryHeightOri);
            inventoryHeight = 400;
        }
    }
}
