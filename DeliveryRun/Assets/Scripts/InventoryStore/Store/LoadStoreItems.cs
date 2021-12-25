using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class LoadStoreItems : LoadItems
{
    private GameObject[] goods;
    private SelectIndex selectIndex;
    private ItemCount itemCount;
    private int[] outfitIDBeforeStore;

    public void Awake()
    {
        selectIndex = GetComponent<SelectIndex>();
    }
    public void Start()
    {
        Refresh();
        outfitIDBeforeStore = new int[2];
        outfitIDBeforeStore[0] = PlayerInfo.hair;
        outfitIDBeforeStore[1] = PlayerInfo.outfit;
    }

    //스토어 아이템 로드
    public override void Refresh()
    {
        goods = GameObject.FindGameObjectsWithTag(selectIndex.index.ToString());
        itemCount = GetComponent<ItemSaveLoad>().GetItemCount();

        ResetGoods(((int)selectIndex.index));

        int selectIndexNum = (int)selectIndex.index;

        if (selectIndexNum == ((int)InventoryIndex.Item))
        {
            for (int i = 0; i < goods.Length; i++)
            {
                goods[i].transform.SetParent(inventorySlotBox.transform);
            }
        }
        else
        {
            for (int i = 0; i < goods.Length; i++)
            {
                int id = goods[i].GetComponent<ItemInfo>().id - 1;
                if (!itemCount.have[selectIndexNum -1].haveList[id])
                {
                    goods[i].transform.SetParent(inventorySlotBox.transform);
                }

            }
        }
        ExpandInventory();
    }

    //현재 입고 있는 의상 정보
    public void InitializeCostume()
    {
        PlayerInfo.hair = outfitIDBeforeStore[0];
        PlayerInfo.outfit = outfitIDBeforeStore[1];
    }
}
